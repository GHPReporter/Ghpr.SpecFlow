using System.Collections.Generic;
using Ghpr.Core.Interfaces;

namespace Ghpr.SpecFlow.Common
{
    public interface IGhprSpecFlowScreenHelper
    {
        void SaveScreenshot(byte[] screenBytes);
        List<ITestScreenshot> GetScreenshots();
    }
}