using System;
using Ghpr.Core.Interfaces;

namespace Ghpr.SpecFlowPlugin
{
    public class GhprSpecFlowTestDataProvider : ITestDataProvider
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