
# [SSASQueryAnalyzer](https://github.com/SSASQueryAnalyzer/)

This is an extension for SQL Server Management Studio 2012, 2014 and 2016.

Source code, documentation and issues can be found at <https://github.com/SSASQueryAnalyzer/>

## Install

Copy this folder into the SSMS extension folder. Remove or replace any previous version.
Run the included reg file to skip the load error.

* 2012 - `C:\Program Files (x86)\Microsoft SQL Server\110\Tools\Binn\ManagementStudio\Extensions`
* 2014 - `C:\Program Files (x86)\Microsoft SQL Server\120\Tools\Binn\ManagementStudio\Extensions`
* 2016 - `C:\Program Files (x86)\Microsoft SQL Server\130\Tools\Binn\ManagementStudio\Extensions`
* 2017 - `C:\Program Files (x86)\Microsoft SQL Server\140\Tools\Binn\ManagementStudio\Extensions`

Depending on your web browser, you may need to unblock the zip file before extracting.
Right click on the zip file and select Properties. 
If you see an `Unblock` button or checkbox then click it. 
If you don't see this then continue as above.

## Known Issues

### Load error
The first time SSMS is run with the extension it will show an error message. Click 'No' and restart SSMS. 
The included reg file sets the same registry setting as when you click the no button.
This should be fixed when there is official support for SSMS extensions.

## Change Log

### v0.1 (2017-08-18)
* Added output window pane for debug messages.
