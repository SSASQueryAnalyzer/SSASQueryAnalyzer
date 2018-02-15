#*******************************************************************************************************************************************#
# This is a Powershell script demo to execute ASQA analysis and create the related PdF ASQA report on all MDX queries contained in a folder #
# 										ATTENTION: the analysis results will not be stored on the ASQA database								#
#*******************************************************************************************************************************************#

<# SCRIPT INFO

	.SYNOPSIS
		This is a Powershell script demo that execute an MDX query analysis and create a related ASQA PdF report for all MDX query files (.mdx) contained in a folder 
		
	.DESCRIPTION
		The script iterates on all .mdx file contained in the specified folder
		For every file the script call the CreateReportInConsoleMode method of the execute the analysis calling the "CreateReportInConsoleMode()"
		This method is contained in the "SSASQueryAnalyzer.Client.Common.ReportingXXXX.dll" that need to be load by this script
		XXXX = 2012 or 2014 or 2016 depending on the version of the SSAS instance you need to use to analyse the MDX queries
	
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
		
	.VARIABLE: $global:PdfFilesFolder
		It is the path of the folder where the Pdf files will be created
		
	.VARIABLE: $global:SSASInstance
		The SSAS instance where to execute the analysis (and where ASQA Assembly has to be installed)
		
	.VARIABLE: $global:SSASDatabase
		The SSAS database where the MDX queries will be executed		
	
	Following are the parameters used to execute the "CreateReportInConsoleMode()" method 
	
	.PARAMETER PdfFileName (VARIABLE: $global:PdfFileName)
		The full name (with path) automatically created merging the string contained in the VARIABLE $global:PdfFilesFolder and the name (without suffix) of the MDX file
		
	.PARAMETER SSASInstance (VARIABLE: $global:SSASInstance)
		See Custom Variables above
		
	.PARAMETER SSASDatabase (VARIABLE: $global:SSASDatabase)
		See Custom Variables above

	.PARAMETER MDXStatement (VARIABLE: $global:MDXstatement)
		The text of MDX query that will be executed and analyzed
		In this script the text is taken by the MDX editor of SSMS when the script has been created 
	

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
	
	function LoadAssemblies()	
	{
        try
        {
        [System.IO.Directory]::SetCurrentDirectory("c:\asqa-v0.1.0-preview3\asqa-v0.1.0-preview3\bin\120\")
        [Reflection.Assembly]::LoadFrom("SSASQueryAnalyzer.Client.Common.Reporting2014.dll")
        }
        catch [Exception] 
        {
            $error[0].Exception.LoaderExceptions
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
		$global:MDXstatement = $global:MDXstatement.Replace("""","""""")
			
		CheckPSVersion 
			
		LoadAssemblies

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

                    #region check pdf reports folder
                    $date = Get-Date
                    $dateString = $date.ToString("yyyyMMdd")
                    $timeString = $date.ToString("HHmmss")
                    $pdfDestinationFolderName = $dateString + "_" + $timeString
                    $pdfDestinationFolderPath = $global:PdfFilesFolder + '\' + $pdfDestinationFolderName

					$global:StepCounter++
					$CurrentTabs = 2
					WriteLog 0 ""
					WriteLog $CurrentTabs "Step $global:StepCounter) Start checking folder for pdf reports: [$pdfDestinationFolderPath]"
					$CurrentTabs = 3
					WriteLog 0 ""
                    $existingFolder = Test-Path -Path $pdfDestinationFolderPath -PathType Container
                    if(!$existingFolder)
                    {
					    # Create a new subfolder named yyyyMMdd-HHmmss
					    try
					    {
                            WriteLog $CurrentTabs "Creating a new folder for pdf reports..."
                            $newFolder = New-Item -Path $pdfDestinationFolderPath  -ItemType directory 
                        }
                        catch [Exception]
					    {
						    $errorLine = Get-CurrentLine
						    WriteLog $CurrentTabs "Error creating folder!" "red"
						    WriteLog $CurrentTabs "Code line where error raises: $errorLine" "red"
						    WriteLog 0 ""
						    LogException $_.Exception $true
					    }
					    if($newFolder)
					    {
						    WriteLog $CurrentTabs "Folder '$newFolder' created." "green"
					    }
                    }
					else
						{
                            WriteLog $CurrentTabs "Folder [$pdfDestinationFolderPath] founded!" "green"
                        } 
					$CurrentTabs = 2
					WriteLog 0 ""
					WriteLog $CurrentTabs "Step $global:StepCounter) End checking folder: [$pdfDestinationFolderPath]"
                    #endregion

                    #region generate pdf reports
					$global:StepCounter++
					$CurrentTabs = 2
					WriteLog 0 ""
					if ($MDXFileFounded -eq 1)
						{WriteLog $CurrentTabs "Step $global:StepCounter) Start creation of $MDXFileFounded pdf report"} 
					else
						{WriteLog $CurrentTabs "Step $global:StepCounter) Start creation of $MDXFileFounded pdf reports"} 
				
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
							
						$global:PdfFileName = $pdfDestinationFolderPath + '\' + $_.Name.Replace($_.extension,".pdf")

						# Execute analysis and create Pdf report
                        try
                        {
							[SSASQueryAnalyzer.Client.Common.Reporting.Infrastructure.Pdf.PdfReportBuilder]::CreateReportInConsoleMode($global:PdfFileName, $global:SSASInstance, $global:SSASDatabase, $global:MDXstatement)
                            WriteLog $CurrentTabs "Report [$global:PdfFileName] created!" "green"
                        }
                        catch [Exception]
                        {
                            $_.Exception | Format-List -Force
                        }
						$CurrentTabs = 3
						WriteLog 0 ""
						$LogText = "Task $global:TaskCounter) End processing file $FileCounter): [$Filename]"
						WriteLog $CurrentTabs $LogText 							
						WriteLog 0 ""
					}
						
					$CurrentTabs = 2
					WriteLog 0 ""
					if ($MDXFileFounded -eq 1)
						{WriteLog $CurrentTabs "Step $global:StepCounter) End creation of $MDXFileFounded pdf report"} 
					else
						{WriteLog $CurrentTabs "Step $global:StepCounter) End creation of $MDXFileFounded pdf reports"} 
                        
                    #endregion
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

	$global:MDXstatement = ""
	
	$global:ReturnErrors = $false
	#endregion GV-Script

#endregion Global Variables

#region Custom Variables
	$global:LogEnabled = $true
	$global:MDXQueriesFileExtension = ".mdx";
	$global:InputMDXQueriesFolder = "<YOUR INPUT MDX QUERIES FOLDER>"; #Do not insert "\" at the end of the path. Ex: "C:\ASQA\MDX"
	$global:PdfFilesFolder = "<YOUR OUTPUT PDF FILES FOLDER>"; #Do not insert "\" at the end of the path. Ex: "C:\ASQA\pdf"
	$global:SSASInstance = "<YOUR SSAS INSTANCE>"		
	$global:SSASDatabase = "<YOUR SSAS DATABASE>"
#endregion Custom Variables

#SCRIPT START HERE

	Main #--> The script only call the Main function

#SCRIPT END HERE