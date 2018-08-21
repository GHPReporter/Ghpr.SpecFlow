// ReSharper disable InconsistentNaming

using Ghpr.Core;
using GhprSpecFlow.Common;

namespace GhprMSTest.SpecFlowPlugin
{
    public class GhprMSTestSpecFlowScreenHelper : IGhprSpecFlowScreenHelper
    {
        public void SaveScreenshot(byte[] screenBytes, string format)
        {
            ReporterManager.SaveScreenshot(screenBytes, format);
        }
    }
}