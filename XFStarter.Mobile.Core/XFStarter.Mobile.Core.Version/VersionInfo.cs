using System.Reflection;
using System.Runtime.InteropServices;
[assembly: AssemblyCompany(AssemblyInfo.AssemblyCompany)]
[assembly: AssemblyCopyright(AssemblyInfo.AssemblyCopyright)]
[assembly: AssemblyTrademark("none")]
[assembly: AssemblyProduct(AssemblyInfo.AssemblyProduct)]

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif
//
// Version information for an assembly consists of the following four values:
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion(AssemblyInfo.AssemblyVersion)]
[assembly: AssemblyFileVersion(AssemblyInfo.AssemblyFileVersion)]

internal class AssemblyInfo
{
    public const string AssemblyProduct = "Mobile Core Library";
    public const string AssemblyCompany = "Bla Bla Enterprises Ltd";
    public const string AssemblyCopyright = "Bla Bla, Inc. © 1981-2017";

    public const string AssemblyVersion = "1.0.0.0";
    public const string AssemblyFileVersion = "1.0.0.0";
}