using System.Reflection;
using System.Runtime.InteropServices;
using Ghpr.SpecFlowPlugin;
using TechTalk.SpecFlow.Plugins;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Ghpr.SpecFlowPlugin")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Evgeniy Kosjakov")]
[assembly: AssemblyProduct("Ghpr.SpecFlowPlugin")]
[assembly: AssemblyCopyright("Copyright © Evgeniy Kosjakov 2016")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("84e12915-13cb-4150-8f87-b6ddfdddfb46")]

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
[assembly: AssemblyVersion("0.2.5.1")]
[assembly: AssemblyFileVersion("0.2.5.1")]

[assembly: RuntimePlugin(typeof(GhprPlugin))]