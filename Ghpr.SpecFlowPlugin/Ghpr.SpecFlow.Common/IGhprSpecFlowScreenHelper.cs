namespace GhprSpecFlow.Common
{
    public interface IGhprSpecFlowScreenHelper
    {
        void SaveScreenshot(byte[] screenBytes, string format = "png");
    }
}