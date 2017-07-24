using System.Reflection;
using System.Runtime.InteropServices;
using GhprMSTest.SpecFlowPlugin;
using TechTalk.SpecFlow.Plugins;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Ghpr.MSTest.SpecFlowPlugin")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Evgeniy Kosjakov")]
[assembly: AssemblyProduct("Ghpr.MSTest.SpecFlowPlugin")]
[assembly: AssemblyCopyright("Copyright © Evgeniy Kosjakov 2016-2017")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("e3c92b3b-4e07-413a-b3dd-5614c1d6f736")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("0.5.0.5")]
[assembly: AssemblyFileVersion("0.5.0.5")]

[assembly: RuntimePlugin(typeof(GhprMSTestSpecFlowPlugin))]