using System.Collections.Generic;
using Ghpr.Core.Common;

namespace GhprSpecFlow.Common
{
    public interface IGhprSpecFlowScreenHelper
    {
        void SaveScreenshot(byte[] screenBytes);
        IEnumerable<SimpleItemInfoDto> GetScreenshots();
    }
}