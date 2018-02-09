using System.Reflection;
using System.Runtime.InteropServices;
using GhprMSTestTestContext.SpecFlowPlugin;
using TechTalk.SpecFlow.Infrastructure;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Ghpr.MSTest.TestContext.SpecFlowPlugin")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Evgeniy Kosjakov")]
[assembly: AssemblyProduct("Ghpr.MSTest.TestContext.SpecFlowPlugin")]
[assembly: AssemblyCopyright("Copyright © Evgeniy Kosjakov 2016-2018")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("c947bbb6-7abf-4c10-82a4-0b53ab2308d3")]

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
[assembly: AssemblyVersion("0.8.1.0")]
[assembly: AssemblyFileVersion("0.8.1.0")]

[assembly: GeneratorPlugin(typeof(GhprMSTestTestContextSpecFlowPlugin))]