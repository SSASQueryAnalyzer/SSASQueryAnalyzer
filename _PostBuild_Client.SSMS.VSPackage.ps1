cls

$extensionPath110 = 'C:\Program Files (x86)\Microsoft SQL Server\110\Tools\Binn\ManagementStudio\Extensions\SSASQueryAnalyzer.Client.SSMS\'
$extensionPath120 = 'C:\Program Files (x86)\Microsoft SQL Server\120\Tools\Binn\ManagementStudio\Extensions\SSASQueryAnalyzer.Client.SSMS\'
$extensionPath130 = 'C:\Program Files (x86)\Microsoft SQL Server\130\Tools\Binn\ManagementStudio\Extensions\SSASQueryAnalyzer.Client.SSMS\'
$extensionPath140 = 'C:\Program Files (x86)\Microsoft SQL Server\140\Tools\Binn\ManagementStudio\Extensions\SSASQueryAnalyzer.Client.SSMS\'

$commonPath  = "C:\Users\$env:USERNAME\Source\Repos\ssas-tester\SSASQueryAnalyzer.Client.Common\bin\Debug"
$packagePath = "C:\Users\$env:USERNAME\Source\Repos\ssas-tester\SSASQueryAnalyzer.Client.SSMS.VSPackage\bin\Debug"
$serverPath  = "C:\Users\$env:USERNAME\Source\Repos\ssas-tester\SSASQueryAnalyzer.Server\bin\Debug"

# 110
Remove-Item $extensionPath110 -Force -Recurse -ErrorAction Ignore
New-Item -Path $extensionPath110 -ItemType Directory | Out-Null
Set-Location $serverPath
Copy-Item -Path SSASQueryAnalyzer.Server*.dll -Destination $extensionPath110
Copy-Item -Path SSASQueryAnalyzer.Server*.pdb -Destination $extensionPath110
Set-Location $packagePath
Copy-Item -Path Microsoft.Threading.Tasks.dll -Destination $extensionPath110
Copy-Item -Path SSASQueryAnalyzer.Client.Common2012.dll -Destination $extensionPath110
Copy-Item -Path SSASQueryAnalyzer.Client.Common2012.pdb -Destination $extensionPath110
Copy-Item -Path SSASQueryAnalyzer.Client.SSMS.VSPackage110.dll -Destination $extensionPath110
Copy-Item -Path SSASQueryAnalyzer.Client.SSMS.VSPackage110.pdb -Destination $extensionPath110
Copy-Item -Path SSASQueryAnalyzer.Client.SSMS.VSPackage110.pkgdef -Destination $extensionPath110
Copy-Item -Path SSASQueryAnalyzer.Client.SSMS.VSPackage110.dll.config -Destination $extensionPath110
Copy-Item -Path SSASQueryAnalyzer.Client.Common.Reporting2012.dll -Destination $extensionPath110
Copy-Item -Path SSASQueryAnalyzer.Client.Common.Reporting2012.pdb -Destination $extensionPath110
Copy-Item -Path itext.*.dll -Destination $extensionPath110
Copy-Item -Path MDXParser.dll -Destination $extensionPath110

# 120
Remove-Item $extensionPath120 -Force -Recurse -ErrorAction Ignore
New-Item -Path $extensionPath120 -ItemType Directory | Out-Null
Set-Location $serverPath
Copy-Item -Path SSASQueryAnalyzer.Server*.dll -Destination $extensionPath120
Copy-Item -Path SSASQueryAnalyzer.Server*.pdb -Destination $extensionPath120
Set-Location $packagePath
Copy-Item -Path Microsoft.Threading.Tasks.dll -Destination $extensionPath120
Copy-Item -Path SSASQueryAnalyzer.Client.Common2014.dll -Destination $extensionPath120
Copy-Item -Path SSASQueryAnalyzer.Client.Common2014.pdb -Destination $extensionPath120
Copy-Item -Path SSASQueryAnalyzer.Client.SSMS.VSPackage120.dll -Destination $extensionPath120
Copy-Item -Path SSASQueryAnalyzer.Client.SSMS.VSPackage120.pdb -Destination $extensionPath120
Copy-Item -Path SSASQueryAnalyzer.Client.SSMS.VSPackage120.pkgdef -Destination $extensionPath120
Copy-Item -Path SSASQueryAnalyzer.Client.SSMS.VSPackage120.dll.config -Destination $extensionPath120
Copy-Item -Path SSASQueryAnalyzer.Client.Common.Reporting2014.dll -Destination $extensionPath120
Copy-Item -Path SSASQueryAnalyzer.Client.Common.Reporting2014.pdb -Destination $extensionPath120
Copy-Item -Path itext.*.dll -Destination $extensionPath120
Copy-Item -Path MDXParser.dll -Destination $extensionPath120

# 130
Remove-Item $extensionPath130 -Force -Recurse -ErrorAction Ignore
New-Item -Path $extensionPath130 -ItemType Directory | Out-Null
Set-Location $serverPath
Copy-Item -Path SSASQueryAnalyzer.Server*.dll -Destination $extensionPath130
Copy-Item -Path SSASQueryAnalyzer.Server*.pdb -Destination $extensionPath130
Set-Location $packagePath
Copy-Item -Path Microsoft.Threading.Tasks.dll -Destination $extensionPath130
Copy-Item -Path SSASQueryAnalyzer.Client.Common2016.dll -Destination $extensionPath130
Copy-Item -Path SSASQueryAnalyzer.Client.Common2016.pdb -Destination $extensionPath130
Copy-Item -Path SSASQueryAnalyzer.Client.SSMS.VSPackage130.dll -Destination $extensionPath130
Copy-Item -Path SSASQueryAnalyzer.Client.SSMS.VSPackage130.pdb -Destination $extensionPath130
Copy-Item -Path SSASQueryAnalyzer.Client.SSMS.VSPackage130.pkgdef -Destination $extensionPath130
Copy-Item -Path SSASQueryAnalyzer.Client.SSMS.VSPackage130.dll.config -Destination $extensionPath130
Copy-Item -Path SSASQueryAnalyzer.Client.Common.Reporting2016.dll -Destination $extensionPath130
Copy-Item -Path SSASQueryAnalyzer.Client.Common.Reporting2016.pdb -Destination $extensionPath130
Copy-Item -Path itext.*.dll -Destination $extensionPath130
Copy-Item -Path MDXParser.dll -Destination $extensionPath130

# 140
Remove-Item $extensionPath140 -Force -Recurse -ErrorAction Ignore
New-Item -Path $extensionPath140 -ItemType Directory | Out-Null
Set-Location $serverPath
Copy-Item -Path SSASQueryAnalyzer.Server*.dll -Destination $extensionPath140
Copy-Item -Path SSASQueryAnalyzer.Server*.pdb -Destination $extensionPath140
Set-Location $packagePath
#Copy-Item -Path Microsoft.Threading.Tasks.dll -Destination $extensionPath140
Copy-Item -Path SSASQueryAnalyzer.Client.Common2017.dll -Destination $extensionPath140
Copy-Item -Path SSASQueryAnalyzer.Client.Common2017.pdb -Destination $extensionPath140
Copy-Item -Path SSASQueryAnalyzer.Client.SSMS.VSPackage140.dll -Destination $extensionPath140
Copy-Item -Path SSASQueryAnalyzer.Client.SSMS.VSPackage140.pdb -Destination $extensionPath140
Copy-Item -Path SSASQueryAnalyzer.Client.SSMS.VSPackage140.pkgdef -Destination $extensionPath140
Copy-Item -Path SSASQueryAnalyzer.Client.SSMS.VSPackage140.dll.config -Destination $extensionPath140
Copy-Item -Path SSASQueryAnalyzer.Client.Common.Reporting2017.dll -Destination $extensionPath140
Copy-Item -Path SSASQueryAnalyzer.Client.Common.Reporting2017.pdb -Destination $extensionPath140
Copy-Item -Path itext.*.dll -Destination $extensionPath140
Copy-Item -Path MDXParser.dll -Destination $extensionPath140

Write-Output 'done' 
Get-Date