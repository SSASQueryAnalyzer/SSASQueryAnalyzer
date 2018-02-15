using System;
using System.Reflection;

///
/// http://semver.org/ 
/// 
[assembly: AssemblyVersion(AssemblyInfo.AssemblyFileVersionString)]               // Assembly.Version
[assembly: AssemblyFileVersion(AssemblyInfo.AssemblyFileVersionString)]           // FileVersionInfo.FileVersion
[assembly: AssemblyInformationalVersion(AssemblyInfo.AssemblyFileVersionString)]  // FileVersionInfo.ProductVersion

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif

[assembly: AssemblyProduct("SSASQueryAnalyzer")]
[assembly: AssemblyCopyright("Copyright © 2017")]
//[assembly: AssemblyCompany("")]
//[assembly: AssemblyTrademark("")]

internal static class AssemblyInfo
{
    internal const string AssemblyFileVersionString = "0.1.0";
    internal static Version AssemblyFileVersion = new Version(AssemblyFileVersionString);
}