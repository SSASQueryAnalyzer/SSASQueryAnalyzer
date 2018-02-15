$basePath = 'C:\Users\Administrator\Source\Repos\ssas-tester'
$serverPath = 'SSASQueryAnalyzer.Server\bin\Debug'
$addinPath = 'SSASQueryAnalyzer.Client.SSMSAddIn\bin\Debug'
$file = 'SSASQueryAnalyzer.Server2012.*'


$path = [IO.Path]::Combine($basePath, $serverPath, $file)
$destination = [IO.Path]::Combine($basePath, $addinPath)

Copy-Item -Path $path -Destination $destination
