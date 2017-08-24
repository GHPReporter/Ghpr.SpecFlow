using System.Collections.Generic;
using Ghpr.Core.Interfaces;
using GhprSpecFlow.Common;

namespace Ghpr.SpecFlowPlugin
{
    public class GhprSpecFlowScreenHelper : IGhprSpecFlowScreenHelper
    {
        public void SaveScreenshot(byte[] screenBytes)
        {
            throw new System.NotImplementedException("This feature is not supported for Ghpr.SpecFlowPlugin. " +
                                                     "Please use GhprMSTest.SpecFlowPlugin or GhprNUnit.SpecFlowPlugin");
        }

        public List<ITestScreenshot> GetScreenshots()
        {
            throw new System.NotImplementedException("This feature is not supported for Ghpr.SpecFlowPlugin. " +
                                                     "Please use GhprMSTest.SpecFlowPlugin or GhprNUnit.SpecFlowPlugin");
        }
    }
}