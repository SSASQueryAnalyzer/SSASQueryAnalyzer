#region Legenda SQL Server versions 

    #  80 = SQL Server 2000    =  8.00.xxxx
    #  90 = SQL Server 2005    =  9.00.xxxx
    # 100 = SQL Server 2008    = 10.00.xxxx
    # 105 = SQL Server 2008 R2 = 10.50.xxxx
    # 110 = SQL Server 2012    = 1100.xxxx
    # 120 = SQL Server 2014    = 1200.xxxx
    # 130 = SQL Server 2016    = 1300.xxxx
    # 140 = SQL Server 2017    = 1400.xxxx

#endregion Legenda SQL Server versions

#region Utility Functions --> This region contains all the "Utility Functions" used by the script   
	
	#region UF-Environment --> Utility functions related to the Environment

	function CheckPSVersion()
	{
		[string]$PSMinimalVersion = [string]$global:PSMinimalMajorVersion + '.' + [string]$global:PSMinimalMinorVersion
		$Major = $PSVersionTable.PSVersion.Major
		$Minor = $PSVersionTable.PSVersion.Minor
		[string]$global:PSVersion = [string]$Major + '.' + [string]$Minor
		if( ($Major -lt $global:PSMinimalMajorVersion) -or (($Major -ge $global:PSMinimalMajorVersion) -and ($Minor -lt $global:PSMinimalMinorVersion)) )
		{
			WriteLog 0 "Error:" "red"
			WriteLog 1 "Current Powershell Version: $PSVersion" "red"
			WriteLog 1 "Minimal Powershell Version required by '$global:CurrentScriptName': $PSMinimalVersion" "red"
			WriteLog 1 "Quit execution" "red"
			Exit 1
		}
	}

    function UpdateRegistrySkipLoadingProperty([string]$SSMSPackagesRegistryKey, [boolean]$CreateIfNotExists)
    {
        $PropertyName = "SkipLoading"
        $PropertyValue = "00000001"

        # Create "Packages" entry if not exists
        if( ($CreateIfNotExists) -and !(Test-Path $SSMSPackagesRegistryKey) )
        {
            New-Item -Path $SSMSPackagesRegistryKey | Out-Null
        }

        $ASQAPackageRegistryKey = $SSMSPackagesRegistryKey + "\" + $global:ASQAPackageGUID

        # Create ASQA package entry if not exists
        if( ($CreateIfNotExists) -and !(Test-Path $ASQAPackageRegistryKey) )
        {
            New-Item -Path $ASQAPackageRegistryKey | Out-Null
        }

        # Set "SkipLoading" property
        Set-ItemProperty -Path $ASQAPackageRegistryKey -Name $PropertyName -Value $PropertyValue -Type DWord
    }

    function UpdateRegistry()
    {
		$global:StepCounter++;
		$CurrentTabs = 2
		WriteLog 0 ""
		WriteLog 0 ""
		WriteLog $CurrentTabs "BEGIN step $global:StepCounter) Update Registry" 

        #region ASQA SSMSV SPackage2012
        if( $global:ASQASSMSVSPackage2012IsInstalled )
        {
            $SSMSPackagesRegistryKey = "Microsoft.PowerShell.Core\Registry::HKEY_CURRENT_USER\SOFTWARE\Microsoft\SQL Server Management Studio\11.0\Packages"
            UpdateRegistrySkipLoadingProperty $SSMSPackagesRegistryKey $true
            $CurrentTabs = 3
            WriteLog $CurrentTabs "--> Updated registry for ASQA SSMS VSPackage 2012" "green"
        }
        #endregion ASQA SSMSV SPackage2012

        #region ASQA SSMSV SPackage2014
        if( $global:ASQASSMSVSPackage2014IsInstalled )
        {
            $SSMSPackagesRegistryKey = "Microsoft.PowerShell.Core\Registry::HKEY_CURRENT_USER\SOFTWARE\Microsoft\SQL Server Management Studio\12.0\Packages"
            UpdateRegistrySkipLoadingProperty $SSMSPackagesRegistryKey $true
            $CurrentTabs = 3
            WriteLog $CurrentTabs "--> Updated registry for ASQA SSMS VSPackage 2014" "green"
        }
        #endregion ASQA SSMSV SPackage2014

        #region ASQA SSMSV SPackage2016
        if( $global:ASQASSMSVSPackage2016IsInstalled )
        {
            $SSMSPackagesRegistryKey = "Microsoft.PowerShell.Core\Registry::HKEY_CURRENT_USER\SOFTWARE\Microsoft\SQL Server Management Studio\13.0\Packages"
            UpdateRegistrySkipLoadingProperty $SSMSPackagesRegistryKey $true
            $CurrentTabs = 3
            WriteLog $CurrentTabs "--> Updated registry for ASQA SSMS VSPackage 2016" "green"
        }
        #endregion ASQA SSMSV SPackage2016

        #region ASQA SSMSV SPackage2017
        if( $global:ASQASSMSVSPackage2017IsInstalled )
        {
            $SSMSPackagesRegistryKey = "Microsoft.PowerShell.Core\Registry::HKEY_CURRENT_USER\SOFTWARE\Microsoft\SQL Server Management Studio\14.0\Packages"
            UpdateRegistrySkipLoadingProperty $SSMSPackagesRegistryKey $true
            $CurrentTabs = 3
            WriteLog $CurrentTabs "--> Updated registry for ASQA SSMS VSPackage 2017" "green"
        }
        #endregion ASQA SSMSV SPackage2017

        $CurrentTabs = 2
		WriteLog $CurrentTabs "END step $global:StepCounter) Update Registry"
    }

    function RetrieveSSMSInstalledFolders()
    {
        #region SSMS 2012
        if (Test-Path $global:SSMS2012_RegistryConfigKey)
	        {
                $RegistryKey = Get-ItemProperty -Path $global:SSMS2012_RegistryConfigKey -Name InstallDir
        
                $global:SSMS2012_InstallationFolder = $RegistryKey.InstallDir

            } 
        #endregion SSMS 2012

        #region SSMS 2014
        if (Test-Path $global:SSMS2014_RegistryConfigKey)
	        {
                $RegistryKey = Get-ItemProperty -Path $global:SSMS2014_RegistryConfigKey -Name InstallDir
        
                $global:SSMS2014_InstallationFolder = $RegistryKey.InstallDir

            } 
        #endregion SSMS 2014

        #region SSMS 2016
        if (Test-Path $global:SSMS2016_RegistryConfigKey)
	        {
                $RegistryKey = Get-ItemProperty -Path $global:SSMS2016_RegistryConfigKey -Name InstallDir
        
                $global:SSMS2016_InstallationFolder = $RegistryKey.InstallDir

            } 
        #endregion SSMS 2016

        #region SSMS 2017
        if (Test-Path $global:SSMS2017_RegistryConfigKey)
	        {
                $RegistryKey = Get-ItemProperty -Path $global:SSMS2017_RegistryConfigKey -Name InstallDir
        
                $global:SSMS2017_InstallationFolder = $RegistryKey.InstallDir

            } 
        #endregion SSMS 2017
    }

	function CheckInstalledSSMS()
	{
		$global:StepCounter++;
		$CurrentTabs = 2
		WriteLog 0 ""
		WriteLog 0 ""
		WriteLog $CurrentTabs "BEGIN step $global:StepCounter) Check ASQA SSMS VSPackages to install" 
		$global:CounterSSMSFounded = 0

        # Retrieve installation folder for all the installed SSMS
        RetrieveSSMSInstalledFolders

        #region ASQA SSMS 2012
        if ( (![string]::IsNullOrEmpty($global:SSMS2012_InstallationFolder)) -and (Test-Path $global:SSMS2012_InstallationFolder) )
		    {
	            $global:SSMS2012_ExtensionsFolder = $global:SSMS2012_InstallationFolder + $global:SSMSExtensionsFolder
			    $global:SSMS2012IsInstalled = $true
			    $global:CounterSSMSFounded++
			    $CurrentTabs = 3
			    WriteLog $CurrentTabs "--> SSMS 2012 founded! ASQA SSMS VSPackage 2012 will be installed!" "green"
		    }
		    else
			    {
				    $CurrentTabs = 3
				    WriteLog $CurrentTabs "--> SSMS 2012 not founded! ASQA SSMS VSPackage 2012 will NOT be installed!" "red"
			    }
        #endregion ASQA SSMS 2012

        #region ASQA SSMS 2014
 		if ( (![string]::IsNullOrEmpty($global:SSMS2014_InstallationFolder)) -and (Test-Path $global:SSMS2014_InstallationFolder) )
		{
	        $global:SSMS2014_ExtensionsFolder = $global:SSMS2014_InstallationFolder + $global:SSMSExtensionsFolder
			$global:SSMS2014IsInstalled = $true
			$global:CounterSSMSFounded++
			$CurrentTabs = 3
			WriteLog $CurrentTabs "--> SSMS 2014 founded! ASQA SSMS VSPackage 2014 will be installed!" "green"
		}
		else
			{
				$CurrentTabs = 3
				WriteLog $CurrentTabs "--> SSMS 2014 not founded! ASQA SSMS VSPackage 2014 will NOT be installed!" "red"
			}
        #endregion ASQA SSMS 2014

        #region ASQA SSMS 2016
 		if ( (![string]::IsNullOrEmpty($global:SSMS2016_InstallationFolder)) -and (Test-Path $global:SSMS2016_InstallationFolder) )
		{
	        $global:SSMS2016_ExtensionsFolder = $global:SSMS2016_InstallationFolder + $global:SSMSExtensionsFolder
			$global:SSMS2016IsInstalled = $true
			$global:CounterSSMSFounded++
			$CurrentTabs = 3
			WriteLog $CurrentTabs "--> SSMS 2016 founded! ASQA SSMS VSPackage 2016 will be installed!" "green"
		}
		else
			{
				$CurrentTabs = 3
				WriteLog $CurrentTabs "--> SSMS 2016 not founded! ASQA SSMS VSPackage 2016 will NOT be installed!" "red"
			}
        #endregion ASQA SSMS 2016

        #region ASQA SSMS 2017
 		if ( (![string]::IsNullOrEmpty($global:SSMS2017_InstallationFolder)) -and (Test-Path $global:SSMS2017_InstallationFolder) )
		{
	        $global:SSMS2017_ExtensionsFolder = $global:SSMS2017_InstallationFolder + $global:SSMSExtensionsFolder
			$global:SSMS2017IsInstalled = $true
			$global:CounterSSMSFounded++
			$CurrentTabs = 3
			WriteLog $CurrentTabs "--> SSMS 2017 founded! ASQA SSMS VSPackage 2017 will be installed!" "green"
		}
		else
			{
				$CurrentTabs = 3
				WriteLog $CurrentTabs "--> SSMS 2017 not founded! ASQA SSMS VSPackage 2017 will NOT be installed!" "red"
			}
        #endregion ASQA SSMS 2017

		$CurrentTabs = 2
		WriteLog $CurrentTabs "END step $global:StepCounter) Check ASQA SSMS VSPackages to install"
	}

	function InstallVSPackages()
	{
		$global:CurrentTabs = 2
		$global:StepCounter++
		$global:TaskCounter = 0
		WriteLog 0 ""
		WriteLog 0 ""
		WriteLog $global:CurrentTabs "BEGIN step $global:StepCounter) Install all ASQA SSMS VSPackages" 
		WriteLog 0 ""

        #region ASQA SSMSV SPackage2012
		if  ($global:SSMS2012IsInstalled) 
		{
			$global:CurrentTabs = 4
            $global:TaskCounter = 0
		    WriteLog $global:CurrentTabs "BEGIN ASQA SSMS VSPackage 2012" 
			if (!(Test-Path $global:SSMS2012_ExtensionsFolder))
			{
				$global:CurrentTabs = 4
				if(!(CreateFolder $global:SSMS2012_ExtensionsFolder $false))
				{
					WriteLog $global:CurrentTabs "--> Quit installation" "red"
					$global:CurrentTabs = 4
					Exit	
				}
				$global:CurrentTabs = 4
			}
		
            $ASQA2012_InstallFolder_Bin = $global:ASQA_InstallFolder_Bin + "\110"

			Get-ChildItem $ASQA2012_InstallFolder_Bin | foreach {
                CopyFile $_.FullName $global:SSMS2012_ExtensionsFolder
            }		
            
            $global:ASQASSMSVSPackage2012IsInstalled = $true	
		    WriteLog $global:CurrentTabs "END ASQA SSMS VSPackage 2012" 
			WriteLog 0 ""	
		}
        #endregion ASQA SSMSV SPackage2012

        #region ASQA SSMSV SPackage2014
		if ($global:SSMS2014IsInstalled) 
		{
			$global:CurrentTabs = 4
            $global:TaskCounter = 0
            WriteLog $global:CurrentTabs "BEGIN ASQA SSMS VSPackage 2014" 
			if (!(Test-Path $global:SSMS2014_ExtensionsFolder))
			{
				$global:CurrentTabs = 4
				if(!(CreateFolder $global:SSMS2014_ExtensionsFolder $false))
				{
					WriteLog $global:CurrentTabs "--> Quit installation" "red"
					$global:CurrentTabs = 4
					Exit	
				}
				$global:CurrentTabs = 4
			}
		
            $ASQA2014_InstallFolder_Bin = $global:ASQA_InstallFolder_Bin + "\120"
			Get-ChildItem $ASQA2014_InstallFolder_Bin | foreach {
                CopyFile $_.FullName $global:SSMS2014_ExtensionsFolder
            }		
            	
            $global:ASQASSMSVSPackage2014IsInstalled = $true	
		    WriteLog $global:CurrentTabs "END ASQA SSMS VSPackage 2014" 
			WriteLog 0 ""	
		}
        #endregion ASQA SSMSV SPackage2014
		
        #region ASQA SSMSV SPackage2016
		if ($global:SSMS2016IsInstalled) 
		{
			$global:CurrentTabs = 4
            $global:TaskCounter = 0
            WriteLog $global:CurrentTabs "BEGIN ASQA SSMS VSPackage 2016" 
			if (!(Test-Path $global:SSMS2016_ExtensionsFolder))
			{
				$global:CurrentTabs = 4
				if(!(CreateFolder $global:SSMS2016_ExtensionsFolder $false))
				{
					WriteLog $global:CurrentTabs "--> Quit installation" "red"
					$global:CurrentTabs = 4
					Exit	
				}
				$global:CurrentTabs = 4
			}
		
            $ASQA2016_InstallFolder_Bin = $global:ASQA_InstallFolder_Bin + "\130"
			Get-ChildItem $ASQA2016_InstallFolder_Bin | foreach {
                CopyFile $_.FullName $global:SSMS2016_ExtensionsFolder
            }		
            	
            $global:ASQASSMSVSPackage2016IsInstalled = $true	
		    WriteLog $global:CurrentTabs "END ASQA SSMS VSPackage 2016" 
			WriteLog 0 ""	
		}
        #endregion ASQA SSMSV SPackage2016

        #region ASQA SSMSV SPackage2017
		if ($global:SSMS2017IsInstalled) 
		{
			$global:CurrentTabs = 4
            $global:TaskCounter = 0
		    WriteLog $global:CurrentTabs "BEGIN ASQA SSMS VSPackage 2017" 
			if (!(Test-Path $global:SSMS2017_ExtensionsFolder))
			{
				$global:CurrentTabs = 4
				if(!(CreateFolder $global:SSMS2017_ExtensionsFolder $false))
				{
					WriteLog $global:CurrentTabs "--> Quit installation" "red"
					$global:CurrentTabs = 4
					Exit	
				}
				$global:CurrentTabs = 4
			}
		
            $ASQA2017_InstallFolder_Bin = $global:ASQA_InstallFolder_Bin + "\140"
			Get-ChildItem $ASQA2017_InstallFolder_Bin | foreach {
                CopyFile $_.FullName $global:SSMS2017_ExtensionsFolder
            }		
            	
            $global:ASQASSMSVSPackage2017IsInstalled = $true	
		    WriteLog $global:CurrentTabs "END ASQA SSMS VSPackage 2017" 
			WriteLog 0 ""	
		}
        #endregion ASQA SSMSV SPackage2017

		$global:CurrentTabs = 2
		WriteLog $global:CurrentTabs "END    step $global:StepCounter) Install all ASQA SSMS VSPackages" 
	}
	
	#endregion UF-Environment
	
	#region UF-Script --> Utility functions related to the Powershell script

	function Get-ScriptDirectory
	{
			$Invocation = (Get-Variable MyInvocation -Scope 1).Value
			Split-Path $Invocation.MyCommand.Path
		}

	#endregion UF-Script

	#region UF-Log  --> Utility functions related to the management of the Log 

	function CreateLogFile()
	{
			WriteLog $global:CurrentTabs "BEGIN step $global:StepCounter) Create log file" 

			$global:CurrentTabs++
			$global:TaskCounter++
			WriteLog $global:CurrentTabs "Task $global:TaskCounter) Creating log file '$global:LogFileFullName' ..." 

			try
			{
				New-Item -Path $global:LogFilePath -Name $global:LogFileName -ItemType File | out-null
				
				# Log only on file
				$global:logOnFile = $true
				$global:logOnVideo = $false
				WriteLogHeader
				WriteLog $global:CurrentTabs "Task $TaskCounter) Creating log file '$global:LogFileFullName' ..." 
				
				$global:CurrentTabs++			
				# Log on both (file & video)
				$global:logOnFile = $true
				$global:logOnVideo = $true
				WriteLog $global:CurrentTabs "--> The file was created successfully!" "green"	
			
				$global:CurrentTabs = 2
				WriteLog $global:CurrentTabs "END   step $global:StepCounter) Create log file" 
			}
			catch
			{
				$global:CurrentTabs++
				$CustomText = "The process failed!" 
				WriteLogError $_ $CustomText $global:CurrentTabs $true
				Exit
			}

		}

	function WriteLogHeader()
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
			WriteLog 0 ""
		}

	function WriteLogFooter()
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
		
	function WriteLog([Int]$Tabs, [String]$Message, [String]$TextColor="white", [Boolean]$ResizeLog=$true)
	{
			$LogText = "";
			for ($i=1;$i -le $Tabs; $i++) 
				{	
					$LogText = $LogText + "`t"
				}
			$LogText = $LogText + $Message
			$ResizedLogText = "$LogText"
			if($ResizeLog -eq $true)
			{
				$ResizedLogText = ResizeLog $LogText
			}

			OutputLog $LogText $ResizedLogText $TextColor
		}

	function WriteLogCentered([String]$Message, [String]$TextColor="white")
	{
			$LogText = "";
			if($global:WindowWidth -lt $Message.Length)
			{
				OutputLog "Shell screen width is smaller then text to output!" "red"
				return
			}
			$StartText = ($global:WindowWidth - $Message.Length) / 2
			for ($i=1;$i -le $StartText; $i++) 
				{	
					$LogText = $LogText + " "
				}
			$LogText = $LogText + $Message
			$ResizedLogText = ResizeLog $LogText
			OutputLog $LogText $ResizedLogText $TextColor
		}	
		
	function ResizeLog([String]$Message)
	{
			$Continue = "..."
			$SingleTabLength = 8
			$UpdatedText = $Message;
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
			return $UpdatedText
		}

	function WriteLogError([String]$ErrorText, [String]$CustomText, [Int]$Tabs, [Boolean]$Exit)
	{
			$ErrorDetails = "$ErrorText"
			if(!($ErrorDetails))
			{
				$ErrorDetails = "$CustomText"
				$CustomText = "Failed with error"
			}
			WriteLog $Tabs "--> $CustomText!" "red"
			if($ErrorDetails)
			{
				WriteLog $Tabs "--> Details: $ErrorDetails" "red" $false
			}
						
			if ($Exit -eq $true)
			{
				WriteLog 1 "Quit installation" "red"
				Exit 3
			}
		}
		
	function OutputLog([String]$Message, [String]$ResizedMessage, [String]$TextColor="white")
	{
			if ($global:logOnVideo -and $global:logOnFile)
			{
				Write-Host $ResizedMessage -foregroundcolor $TextColor 
				Out-File -FilePath $global:LogFileFullName -InputObject $Message -Append		
			}
			else 
				{
					if ($global:logOnVideo)
					{
						Write-Host $ResizedMessage -foregroundcolor $TextColor
					}
					else 
						{
							if ($global:logOnFile)
							{
								Out-File -FilePath $global:LogFileFullName -InputObject $Message -Append
							}
						}
				}
		}

	#endregion UF-Log

    #region File System Functions --> This region contains all the "File System" used by the script

	function CopyFile([String]$SourceFileFullName, [String]$DestinationFolderFullName)
	{
			$global:TaskCounter++
			WriteLog $global:CurrentTabs "Task $global:TaskCounter) Copying file: '$SourceFileFullName' ..." 
			WriteLog $global:CurrentTabs "     to folder '$DestinationFolderFullName' ..." 
			try
			{
				copy-item -path $SourceFileFullName -destination $DestinationFolderFullName  
				WriteLog $global:CurrentTabs "--> The file was copied successfully!!"	"green"
			}
			catch
			{
				$CustomText = "The process failed!" 
				WriteLogError $_ $CustomText $global:CurrentTabs $true
				Exit
			}
	}
	
	function CheckThatFolderExist([String]$FolderFullName, [Boolean]$Exit)
	{
		$global:CurrentTabs = 3 
		$global:TaskCounter++
		WriteLog $global:CurrentTabs "Task $global:TaskCounter) Checking folder '$FolderFullName' ..." 

		$global:CurrentTabs = 4 	
		try
		{
			if (!(Test-Path $FolderFullName))
				{
					$CustomText = "The folder was not found" 
					WriteLogError $_ $CustomText $global:CurrentTabs $Exit
					return $false
				}
			else
				{
					WriteLog $global:CurrentTabs "--> The folder was found!"	"green" 
					return $true
				}  
		}
		catch
		{
			$CustomText = "The process failed!" 
			WriteLogError $_ $CustomText $global:CurrentTabs $true
			Exit
		}
	}
	
	function CheckSourceFolders()
	{
		$global:CurrentTabs = 2
		$global:StepCounter++;
		$global:TaskCounter = 0
		WriteLog 0 ""
		WriteLog 0 ""
		WriteLog $global:CurrentTabs "BEGIN step $global:StepCounter) Check that source folder exist" 

		if(!(CheckThatFolderExist $global:ASQA_InstallFolder_Bin $false))		
		{
			WriteLog $global:CurrentTabs "--> Quit installation" "red"
			$global:CurrentTabs = 2
			WriteLog $global:CurrentTabs "END   step $global:StepCounter) Check that source folder exist" 
			Exit		
		}

		$global:CurrentTabs = 2
		WriteLog $global:CurrentTabs "END   step $global:StepCounter) Check that source folder exist" 	
	}

	function CreateFolder([String]$FolderFullName, [Boolean]$Exit)
	{
			$global:CurrentTabs = 4
			$global:TaskCounter++
			WriteLog $global:CurrentTabs "Task $global:TaskCounter) Creating folder '$FolderFullName' ..." 
			try
			{
				if (Test-Path $FolderFullName)
					{
						$global:CurrentTabs = 5
						$CustomText = "The folder already exists" 
						WriteLogError $_ $CustomText $global:CurrentTabs $Exit
						return $false
					}
				else
					{
						$global:CurrentTabs = 5
						mkdir -Force $FolderFullName | out-null
						WriteLog $global:CurrentTabs "--> The folder was created successfully!"	"green"
						return $true
					}  
				$global:CurrentTabs--
			}
			catch
			{
				$CustomText = "The process failed!" 
				WriteLogError $_ $CustomText $global:CurrentTabs $true
				Exit
			}
		}
	
#endregion File System Functions

#endregion Utility Functions

#region Main function --> This region contains the Main function of the Powershell script

	function Main()
	{	
			$ErrorActionPreference = "Stop"
			$VerbosePreference = "SilentlyContinue"
			$WarningPreference = "SilentlyContinue"			
			$global:StartTime = Get-Date
			
			CheckPSVersion 

			$global:logOnFile = $false
			$global:logOnVideo = $true
			
			WriteLogHeader

			try
			{
				$global:CurrentTabs = 2
				$global:StepCounter = 1
				$global:TaskCounter = 0
				
				# STEP 1
				CreateLogFile
				
				# STEP 2
				CheckSourceFolders

				# STEP 3
				CheckInstalledSSMS
				
				# STEP 4
				InstallVSPackages

				# STEP 5
				UpdateRegistry
			}
			finally
			{
				WriteLogFooter
			}
		}

#endregion

#region Global Variables --> This region contains all the "Global Variable" used by the script
	
    #region GV-Environment --> Global Variables related to the Environment

	$global:PSVersion = $null
	$pshost = Get-Host              
	$pswindow = $pshost.UI.RawUI    
	$global:WindowWidth = $pswindow.windowsize.width
    if($global:WindowWidth -lt 100)
    {
        $global:WindowWidth = 100
    }

	#endregion GV-Environment
	
	#region GV-Script --> Global Variables related to the Powershell script

	$global:CurrentScriptName = $MyInvocation.MyCommand.Name
	$global:CurrentScriptPath = $PSScriptRoot
	$global:StepCounter = 0
	$global:TaskCounter = 0

	#endregion GV-Script
	
	#region GV-Execution --> Global Variables related to the Execution of the script

	$global:CurrentDateTime = Get-Date -format "yyyyMMddHHmmss" 
	$global:StartTime = $null

	#endregion GV-Execution

	#region GV-Log  --> Global Variables related to the management of the Log
 	
	$global:CurrentTabs = 0
	$global:logOnVideo = $true
	$global:logOnFile = $false #--> Cannot be true here
	$global:LogStarLine = ""
	for ($i=1;$i -lt $global:WindowWidth; $i++) 
	{	
		$global:LogStarLine = $global:LogStarLine + "*"
	}
	$global:LogFileExtension	= ".log"
	$global:LogFilePath			= "$(Get-ScriptDirectory)"
	$global:LogFileName			= "ASQAInstall_$global:CurrentDateTime$global:LogFileExtension"
	$global:LogFileFullName		= "$global:LogFilePath\$global:LogFileName"

	#endregion GV-Log
	
	#region GV-ASQA --> Global Variables related to ASQA SSMS VSPackage

	$global:SSMS2012IsInstalled = $false
	$global:SSMS2014IsInstalled = $false
	$global:SSMS2016IsInstalled = $false
	$global:SSMS2017IsInstalled = $false
	$global:CounterSSMSFounded = 0
	
    $global:ASQAPackageGUID = "{28672cc0-c8a7-4203-b4ce-d9c3e6216812}"
	$global:ASQASSMSVSPackage2012IsInstalled = $false
	$global:ASQASSMSVSPackage2014IsInstalled = $false
	$global:ASQASSMSVSPackage2016IsInstalled = $false
	$global:ASQASSMSVSPackage2017IsInstalled = $false
	
	$global:ASQA_InstallFolder 			= "$global:CurrentScriptPath"
	$global:ASQA_InstallFolder_Bin 		= "$global:ASQA_InstallFolder\Bin\"

    $global:SSMS2012_RegistryConfigKey = "Microsoft.PowerShell.Core\Registry::HKEY_CURRENT_USER\Software\Microsoft\SQL Server Management Studio\11.0_Config\"
    $global:SSMS2012_InstallationFolder = ""
    $global:SSMS2012_ExtensionsFolder = ""

    $global:SSMS2014_RegistryConfigKey = "Microsoft.PowerShell.Core\Registry::HKEY_CURRENT_USER\Software\Microsoft\SQL Server Management Studio\12.0_Config\"
    $global:SSMS2014_InstallationFolder = ""
    $global:SSMS2014_ExtensionsFolder = ""

    $global:SSMS2016_RegistryConfigKey = "Microsoft.PowerShell.Core\Registry::HKEY_CURRENT_USER\Software\Microsoft\SQL Server Management Studio\13.0_Config\"
    $global:SSMS2016_InstallationFolder = ""
    $global:SSMS2016_ExtensionsFolder = ""

    $global:SSMS2017_RegistryConfigKey = "Microsoft.PowerShell.Core\Registry::HKEY_CURRENT_USER\Software\Microsoft\SQL Server Management Studio\14.0_Config\"
    $global:SSMS2017_InstallationFolder = ""
    $global:SSMS2017_ExtensionsFolder = ""

    $global:SSMSExtensionsFolder = "\Extensions\SSASQueryAnalyzer.Client.SSMS\"


	#endregion GV-ASQA
	
#endregion Global Variables

# Script starts here

Main #--> call to the Main function

# Script ends here
