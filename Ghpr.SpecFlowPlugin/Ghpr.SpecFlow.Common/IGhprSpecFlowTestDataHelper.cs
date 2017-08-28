using System.Collections.Generic;
using Ghpr.Core.Interfaces;

namespace GhprSpecFlow.Common
{
    public interface IGhprSpecFlowTestDataHelper
    {
        void AddTestData(string actual, string expected, string comment);
        List<ITestData> GetTestData();
    }
}