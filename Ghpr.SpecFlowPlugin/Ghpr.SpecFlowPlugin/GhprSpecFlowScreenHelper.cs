using GhprSpecFlow.Common;

namespace Ghpr.SpecFlowPlugin
{
    public class GhprSpecFlowScreenHelper : IGhprSpecFlowScreenHelper
    {
        public void SaveScreenshot(byte[] screenBytes, string format)
        {
            throw new System.NotImplementedException("This feature is not supported for Ghpr.SpecFlowPlugin. " +
                                                     "Please use GhprMSTest.SpecFlowPlugin or GhprNUnit.SpecFlowPlugin");
        }
    }
}