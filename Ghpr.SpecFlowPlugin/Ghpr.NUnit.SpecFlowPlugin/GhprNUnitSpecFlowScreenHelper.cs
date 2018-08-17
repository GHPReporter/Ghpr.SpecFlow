using Ghpr.Core;
using GhprSpecFlow.Common;

namespace GhprNUnit.SpecFlowPlugin
{
    public class GhprNUnitSpecFlowScreenHelper : IGhprSpecFlowScreenHelper
    {
        public void SaveScreenshot(byte[] screenBytes, string format = "png")
        {
            ReporterManager.SaveScreenshot(screenBytes, format);
        }
    }
}