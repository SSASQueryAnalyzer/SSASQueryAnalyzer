#****************************************************************************************************#
# This is a Powershell script demo to execute ASQA analysis on all MDX queries contained in a folder #
#****************************************************************************************************#

<# SCRIPT INFO

	.SYNOPSIS
		This is a Powershell script demo that execute an MDX query analysis using Analysis Services Query Analyzer (ASQA) in Batch mode for all MDX queriy files (.mdx) contained in a folder 
		
	.DESCRIPTION
		The script iterates on all .mdx file contained in the specified folder
		For every file the script execute the analysis calling 2 times the "AnalyzeBatch()" method of the ASQA assembly
		The first time the query will be executed with COLD cache
		The second time the query will be executed with WARM cache
		All data will be stored in the ASQA db and can be retrieved and analyzed alter using the SSMS ASQA Addin 
	
	.AUTHOR
		Francesco De Chirico

	.VERSION
		SSMS ASQA Addin version: "0.1.0"		
#>
		
<# VARIABLES & PARAMETERS

	Following are the variables that need to be set before the execution of the script.
	They  can be found in the Custom Variables region at the end of this script

	.VARIABLE: $global:LogEnabled
		It is a flag that enable/disable logging of this script
		If set to "True" the script logs on window all the activities. If set to "false" it does not.
		
	.VARIABLE: $global:MDXQueriesFileExtension (default value: ".mdx")
		It is the extension of the MDX files to analyze
		By default it is ".mdx"
		
	.VARIABLE: $global:InputMDXQueriesFolder
		It is the path of the folder containing all the MDX files to analyze
		
	.VARIABLE: $global:SSASInstance
		The SSAS instance where to execute the analysis (and where ASQA Assembly has to be installed)
		
	.VARIABLE: $global:SSASDatabase
		The SSAS database where the MDX queries will be executed
	
	.VARIABLE: $global:SQLConnectionString
		The Connection string used to connect to the SQL Server instance where the ASQA db (used to store all the analysis data) is installed.
	
	Following are the parameters used to execute the "AnalyzeBatch()" method of the ASQA assembly

	.PARAMETER MDXStatement (VARIABLE: $global:MDXstatement)
		The text of MDX query that will be executed and analyzed
		In this script the text is taken by the MDX editor of SSMS when the script has been created 
	
	.PARAMETER CacheMode (VARIABLE: $global:CacheMode)
		An integer value that indicate if (and in which way) the cache has to be cleared before executing the MDX query
		Possible values:	
						1 = Nothing
						2 = CurrentCube
						3 = CurrentDatabase
						4 = AllDatabases
						5 = FileSystemOnly
						6 = CurrentCubeAndFileSystem
						7 = CurrentDatabaseAndFileSystem
						8 = AllDatabasesAndFileSystem
		In this script the value is fixed to 8 (AllDatabasesAndFileSystem) for the COLD cache execution and to 1 (Nothing) for the WARM cache execution		

	.PARAMETER GUID (VARIABLE: $GUID) --> WARNING: DO NOT MANUALLY SET THIS VALUE!
		This value is used as unique value to identify single analysis execution
		It is autogenerated by Powershell calling "[GUID]::NewGuid()"

	.PARAMETER SQLConnectionString (VARIABLE: $global:SQLConnectionString)
		See Custom Variables above
		
	.PARAMETER ClientVersion (VARIABLE: $global:ClientVersion)
		The version of the client used to execute the analysis.
		In this script the value is retrieved by Powershell and represents the Powershell version  
		
	.PARAMETER ProcessName (VARIABLE: $global:ProcessName)
		This value indicate the process that execute the analysis
		In this script the value is fixed to "PowerShell script"

	.PARAMETER BatchName (VARIABLE: $global:BatchName)
		This value indicate the name of the analysis. Blank string ("") is admitted
		In this script the value is fixed to "PowerShell"

	.PARAMETER ReturnErrors (VARIABLE: $global:ReturnErrors)
		If set to "True" the assembly possibly returns raised error. If set to "false" it does not.
		In this script it is set to "false"

#>

#region Environment Functions --> This region contains functions related to the environment

	function CheckPSVersion()
	{
		[string]$PSMinimalVersion = [string]$global:PSMinimalMajorVersion + '.' + [string]$global:PSMinimalMinorVersion
		$Major = $PSVersionTable.PSVersion.Major
		$Minor = $PSVersionTable.PSVersion.Minor
		[string]$global:PSVersion = [string]$Major + '.' + [string]$Minor
		if( ($Major -lt $global:PSMinimalMajorVersion) -or (($Major -ge $global:PSMinimalMajorVersion) -and ($Minor -lt $global:PSMinimalMinorVersion)) )
		{
			if($global:LogEnabled -eq $true)
			{
				WriteLog 0 "Error:" "red"
				WriteLog 1 "Current Powershell Version: $PSVersion" "red"
				WriteLog 1 "Minimal Powershell Version required by '$global:CurrentScriptName': $PSMinimalVersion" "red"
			}
			Exit 1
		}
	}

#endregion Environment Functions

#region Log Functions --> This region contains all the functions used by the script	to log information

	function WriteLogHeader()
	{	
		if($global:LogEnabled -eq $true)
		{
			WriteLog 0 ""
			WriteLog 0 $global:LogStarLine 
			WriteLogCentered "INFO" 
			WriteLog 1 "ENVINRONMENT" 
			WriteLog 1 "         Powershell Version: $global:PSVersion" "yellow"
			WriteLog 0 "" 
			WriteLog 1 "SCRIPT" 
			WriteLog 1 "                       Path: $global:CurrentScriptPath" "yellow"
			WriteLog 1 "                  File name: $global:CurrentScriptName" "yellow"
			WriteLog 1 "                     Author: Francesco De Chirico" "yellow"
			WriteLog 0 "" 
			WriteLog 1 "CLIENT" 
			WriteLog 1 "            CurrentDateTime: $global:StartTime" "yellow"
			WriteLog 1 "               ComputerName: $env:ComputerName" "yellow"
			WriteLog 1 "                 UserDomain: $env:USERDOMAIN" "yellow"
			WriteLog 1 "                   UserName: $env:USERNAME" "yellow"
			WriteLog 0 "" 
			WriteLog 0 $global:LogStarLine 		
			WriteLog 0 ""
			WriteLog 0 ""
			WriteLog 1 "Script execution starts here" 
		}
	}

	function WriteLogFooter()
	{
		if($global:LogEnabled -eq $true)
		{
			$EndTime = Get-Date
			$ElapsedTimeSpan = New-TimeSpan -Start $global:StartTime -End $EndTime #"The timespan is {0:G}" -f $nts
			$ElapsedTimeSpanString = "{0:g}" -f $ElapsedTimeSpan
			$TotalMilliseconds = $ElapsedTimeSpan.TotalMilliseconds;
			
			WriteLog 0 ""
			WriteLog 1 "Script execution ends here" 
			WriteLog 0 ""
			WriteLog 0 ""
			WriteLog 0 $global:LogStarLine 
			WriteLogCentered "EXECUTION DETAILS" 
			WriteLog 1 "EXECUTION" 
			WriteLog 1 "                Start time: $global:StartTime" "yellow"
			WriteLog 1 "                  End time: $EndTime" "yellow"
			WriteLog 1 "        Total elapsed time: $ElapsedTimeSpanString" "yellow"
			WriteLog 0 "" 
			WriteLog 0 $global:LogStarLine 
			WriteLog 0 ""
		}
	}

	function ResizeLog([String]$Message)
	{
		$UpdatedText = ""
		if($global:LogEnabled -eq $true)
		{			
			$Continue = "..."
			$SingleTabLength = 8
			$UpdatedText = $Message;
			if(($Message -ne $null) -And ($Message.Length > 0))
			{
				$TabCount = [regex]::matches($UpdatedText,"\t").count;
				$TabLength = $TabCount * $SingleTabLength;
				$TextLength = ($UpdatedText.Length - $TabCount + $TabLength);
				if ($TextLength -ge $global:WindowWidth)
				{			
					while($TextLength + $Continue.Length -ge $global:WindowWidth) 
					{
						$UpdatedText = $UpdatedText.Substring(0,$UpdatedText.Length -1)
						$TabCount = [regex]::matches($UpdatedText,"\t").count
						$TabLength = $TabCount * $SingleTabLength;
						$TextLength = ($UpdatedText.Length - $TabCount + $TabLength);
					}
					$UpdatedText = $UpdatedText + $Continue;
				}
			}
		}
		return $UpdatedText
	}	
	
	function WriteLog([Int]$Tabs, [String]$Message, [String]$TextColor="white", [Boolean]$LogToResize=$true)
	{
		if($global:LogEnabled -eq $true)
		{
			$LogText = "";
			for ($i=1;$i -le $Tabs; $i++) 
				{	
					$LogText = $LogText + "`t"
				}
			$LogText = $LogText + $Message
			$ResizedLogText = "$LogText"
			if($LogToResize -eq $true)
			{
				$ResizedLogText = ResizeLog $LogText
			}
				
			Write-Host $ResizedLogText -foregroundcolor $TextColor
		}
	}

	function WriteLogCentered([String]$Message, [String]$TextColor="white")
	{
		if($global:LogEnabled -eq $true)
		{			
			$LogText = "";
			if($global:WindowWidth -lt $Message.Length)
			{
				Write-Host "Shell screen width is smaller then text to output!" -foregroundcolor "red"
				return
			}
			$StartText = ($global:WindowWidth - $Message.Length) / 2
			for ($i=1;$i -le $StartText; $i++) 
				{	
					$LogText = $LogText + " "
				}
			$LogText = $LogText + $Message
			$ResizedLogText = ResizeLog $LogText
				
			Write-Host $ResizedLogText -foregroundcolor $TextColor
		}
	}
	
#endregion Log Functions

#region Main function --> This region contains the Main function of the Powershell script
	
	function Main()
	{

		$ErrorActionPreference = "Stop"
		$VerbosePreference = "SilentlyContinue"
		$WarningPreference = "SilentlyContinue"			
		$global:StartTime = Get-Date
		$global:ClientVersion = $global:ClientVersion.Replace("""","""""")
		$global:BatchName = $global:BatchName.Replace("""","""""")
		$global:SQLConnectionString = $global:SQLConnectionString.Replace("""","""""")
		$global:MDXstatement = $global:MDXstatement.Replace("""","""""")
			
		CheckPSVersion 

		WriteLogHeader

		try
		{		
			if (Test-Path $global:InputMDXQueriesFolder)
			{
				$MDXFileFounded = @(Get-ChildItem $global:InputMDXQueriesFolder | where-object {($_.extension -eq $global:MDXQueriesFileExtension)}).Count;
					
				$global:StepCounter++
				$CurrentTabs = 2
				WriteLog 0 ""
				WriteLog $CurrentTabs "Step $global:StepCounter) Start checking folder: [$global:InputMDXQueriesFolder]"
				$CurrentTabs = 3
				WriteLog 0 ""
				if ($FileCounter -eq 1)
					{WriteLog $CurrentTabs "$MDXFileFounded MDX query file founded!"} 
				else
					{WriteLog $CurrentTabs "$MDXFileFounded MDX queries file founded!"} 
				$CurrentTabs = 2
				WriteLog 0 ""
				WriteLog $CurrentTabs "Step $global:StepCounter) End checking folder: [$global:InputMDXQueriesFolder]"
					
				if($MDXFileFounded -gt 0)
				{
					
					$global:StepCounter++
					$CurrentTabs = 2
					WriteLog 0 ""
					if ($MDXFileFounded -eq 1)
						{WriteLog $CurrentTabs "Step $global:StepCounter) Start analysis of $MDXFileFounded MDX query"} 
					else
						{WriteLog $CurrentTabs "Step $global:StepCounter) Start analysis of $MDXFileFounded MDX queries"} 
				
					$FileCounter = 0;

					# Loop on the folder
					Get-ChildItem $global:InputMDXQueriesFolder | where-object {($_.extension -eq $global:MDXQueriesFileExtension)} | foreach{							
						$FileCounter++
						$InputFilename = $_.FullName		
						
						$Filename = $_.Name		
							
						$global:TaskCounter++
						$CurrentTabs = 3
						WriteLog 0 ""
						$LogText = "Task $global:TaskCounter) Start processing file $FileCounter): [$Filename]"
						WriteLog $CurrentTabs $LogText 							
						WriteLog 0 ""
							
						# Load MDX statement
						$global:MDXstatement = [System.IO.File]::ReadAllText($InputFilename)							
						$global:MDXstatement = $global:MDXstatement.Replace("""","""""")
							
						# Initialize a new GUID to assign to the analysis
						$GUID = [GUID]::NewGuid()
							
						# COLD cache execution
						$CurrentTabs = 4
						WriteLog $CurrentTabs "Task $global:TaskCounter a) Begin COLD cache execution"  
						WriteLog 0 ""
						$global:CacheMode = 8 #--> AllDatabasesAndFileSystem 
						$global:ASQAstatement = $global:ASQAStatementTemplate -f $global:MDXstatement, $global:CacheMode, $GUID, $global:SQLConnectionString, $global:ClientVersion, $global:ProcessName, $global:BatchName, $global:ReturnErrors
							
                        try
                        {
							Invoke-ASCmd -Server:$global:SSASInstance -Database:$global:SSASDatabase -Query:$global:ASQAstatement | Out-Null
                            $CurrentTabs = 5
                            WriteLog $CurrentTabs "COLD cache execution completed!" "green"
							WriteLog 0 ""
                        }
                        catch [Exception]
                        {
                            $_.Exception | Format-List -Force
                        }

                        $CurrentTabs = 4
						WriteLog $CurrentTabs "Task $global:TaskCounter a) End COLD cache execution" 
						WriteLog 0 ""

						# WARM cache execution
						WriteLog $CurrentTabs "Task $global:TaskCounter b) Begin WARM cache execution"  
						WriteLog 0 ""
						$global:CacheMode = 1 #--> Nothing
						$global:ASQAstatement = $global:ASQAStatementTemplate -f $global:MDXstatement, $global:CacheMode, $GUID, $global:SQLConnectionString, $global:ClientVersion, $global:ProcessName, $global:BatchName, $global:ReturnErrors
							
                        try
                        {
							Invoke-ASCmd -Server:$global:SSASInstance -Database:$global:SSASDatabase -Query:$global:ASQAstatement | Out-Null
                            $CurrentTabs = 5
                            WriteLog $CurrentTabs "WARM cache execution completed!" "green"
							WriteLog 0 ""
                        }
                        catch [Exception]
                        {
                            $_.Exception | Format-List -Force
                        }

                        $CurrentTabs = 4
						WriteLog $CurrentTabs "Task $global:TaskCounter b) End WARM cache execution"  
						WriteLog 0 ""
							
						$CurrentTabs = 3
						$LogText = "Task $global:TaskCounter) End processing file $FileCounter): [$Filename]"
						WriteLog $CurrentTabs $LogText 							
						WriteLog 0 ""
					}
						
					$CurrentTabs = 2
					WriteLog 0 ""
					if ($MDXFileFounded -eq 1)
						{WriteLog $CurrentTabs "Step $global:StepCounter) End analysis of $MDXFileFounded MDX query"} 
					else
						{WriteLog $CurrentTabs "Step $global:StepCounter) End analysis of $MDXFileFounded MDX queries"} 
				}			
			}			
		}	
		finally
		{
			WriteLogFooter
		}
	}

#endregion Main function
		
#region Global Variables --> This region contains all the "Global Variable" used by the script
	
	#region GV-Environment --> Global Variables related to the Environment
	$pshost = Get-Host              
	$pswindow = $pshost.UI.RawUI    
	$global:WindowWidth = $pswindow.windowsize.width
    if($global:WindowWidth -lt 100)
    {
        $global:WindowWidth = 100
    }
	#endregion GV-Environment
	
	#region GV-Log  --> Global Variables related to the management of the Log
	$global:LogStarLine = ""
	for ($i=1;$i -lt $global:WindowWidth; $i++) 
	{	
		$global:LogStarLine = $global:LogStarLine + "*"
	}
	#endregion GV-Log
	
	#region GV-Script --> Global Variables related to the Powershell script
	$global:CurrentScriptName = $MyInvocation.MyCommand.Name	
	$global:CurrentScriptPath = $PSScriptRoot

	$global:StepCounter = 0
	$global:TaskCounter = 0

	$global:ProcessName = "PowerShell script multiple MDX queries"
		
	$global:MDXstatement = ""
	
	$global:CacheMode = 8 #--> AllDatabasesAndFileSystem
		
	$global:ClientVersion = $PSVersionTable.PSVersion.ToString()
		
	$global:BatchName = "Powershell"
	
	$global:ReturnErrors = $false
	
	$global:ASQAStatementTemplate = 'call ASQA.AnalyzeBatch("{0}", "{1}", "{2}", "{3}", "{4}", "{5}", "{6}", "{7}")'
	$global:ASQAStatement = ""
	#endregion GV-Script

#endregion Global Variables

#region Custom Variables
	$global:LogEnabled = $true
	$global:MDXQueriesFileExtension = ".mdx";
	$global:InputMDXQueriesFolder = "<YOUR INPUT MDX QUERIES FOLDER>"; #Do not insert "\" at the end of the path. Ex: "C:\ASQA\MDX"
	$global:SSASInstance = "<YOUR SSAS INSTANCE>"		
	$global:SSASDatabase = "<YOUR SSAS DATABASE>"
	$global:SQLConnectionString = "Data Source=<YOUR SQL INSTANCE>;Initial Catalog=ASQA;Integrated Security=True;MultipleActiveResultSets=False;Application Name=Powershell"
#endregion Custom Variables

#SCRIPT START HERE

	Main #--> The script only call the Main function

#SCRIPT END HERE