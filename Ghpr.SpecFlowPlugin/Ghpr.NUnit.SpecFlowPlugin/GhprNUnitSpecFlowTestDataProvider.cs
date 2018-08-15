using System;
using Ghpr.Core.Interfaces;

// ReSharper disable InconsistentNaming

namespace GhprNUnit.SpecFlowPlugin
{
    public class GhprNUnitSpecFlowTestDataProvider : ITestDataProvider
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