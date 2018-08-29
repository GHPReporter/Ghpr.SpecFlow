using System.Collections.Generic;
using Ghpr.Core.Common;
using GhprSpecFlow.Common;

namespace Ghpr.SpecFlowPlugin
{
    public class GhprSpecFlowPluginTestDataHelper : IGhprSpecFlowTestDataHelper
    {
        public void AddTestData(string actual, string expected, string comment)
        {
            throw new System.NotImplementedException("This feature is not supported for Ghpr.SpecFlowPlugin. " +
                                                     "Please use GhprMSTest.SpecFlowPlugin or GhprNUnit.SpecFlowPlugin");
        }

        List<TestDataDto> IGhprSpecFlowTestDataHelper.GetTestData()
        {
            throw new System.NotImplementedException("This feature is not supported for Ghpr.SpecFlowPlugin. " +
                                                     "Please use GhprMSTest.SpecFlowPlugin or GhprNUnit.SpecFlowPlugin");
        }
    }
}