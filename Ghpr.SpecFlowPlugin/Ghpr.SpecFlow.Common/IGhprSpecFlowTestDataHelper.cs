using System.Collections.Generic;
using Ghpr.Core.Common;

namespace GhprSpecFlow.Common
{
    public interface IGhprSpecFlowTestDataHelper
    {
        void AddTestData(string actual, string expected, string comment);
        List<TestDataDto> GetTestData();
    }
}