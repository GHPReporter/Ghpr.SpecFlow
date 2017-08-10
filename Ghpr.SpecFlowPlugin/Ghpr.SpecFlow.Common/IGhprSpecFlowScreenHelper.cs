using System.Collections.Generic;
using Ghpr.Core.Interfaces;

namespace GhprSpecFlow.Common
{
    public interface IGhprSpecFlowScreenHelper
    {
        void SaveScreenshot(byte[] screenBytes);
        List<ITestScreenshot> GetScreenshots();
    }
}