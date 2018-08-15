using System;
using Ghpr.Core.Interfaces;
// ReSharper disable InconsistentNaming

namespace GhprMSTest.SpecFlowPlugin
{
    public class GhprMSTestSpecFlowTestDataProvider : ITestDataProvider
    {
        public Guid GetCurrentTestRunGuid()
        {
            throw new NotImplementedException();
        }

        public string GetCurrentTestRunFullName()
        {
            throw new NotImplementedException();
        }
    }
}