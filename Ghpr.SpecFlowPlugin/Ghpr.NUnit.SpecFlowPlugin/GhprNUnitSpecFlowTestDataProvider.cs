using System;
using Ghpr.Core.Extensions;
using Ghpr.Core.Interfaces;
using NUnit.Framework;

// ReSharper disable InconsistentNaming

namespace GhprNUnit.SpecFlowPlugin
{
    public class GhprNUnitSpecFlowTestDataProvider : ITestDataProvider
    {
        public Guid GetCurrentTestRunGuid()
        {
            var guid = TestContext.CurrentContext.Test.Properties.Get("TestGuid")?.ToString();
            var testGuid = guid != null ? Guid.Parse(guid) : GetCurrentTestRunFullName().ToMd5HashGuid();
            return testGuid;
        }

        public string GetCurrentTestRunFullName()
        {
            var fullName = TestContext.CurrentContext.Test.FullName;
            return fullName;
        }
    }
}