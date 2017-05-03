namespace Ghpr.SpecFlowPlugin
{
    public static class GhprPluginHelper
    {
        private static readonly object Lock;
        public static int GhprTestRunnerCount;

        static GhprPluginHelper()
        {
            Lock = new object();
            TestsAreRunningInParallel = false;
        }

        public static void Init()
        {
            lock (Lock)
            {
                GhprTestRunnerCount = 0;
            }
        }

        public static void TestRunnerInitialized()
        {
            lock (Lock)
            {
                GhprTestRunnerCount++;
                if (GhprTestRunnerCount > 1)
                {
                    TestsAreRunningInParallel = true;
                }
            }
        }

        public static bool TestsAreRunningInParallel { get; private set; }
    }
}