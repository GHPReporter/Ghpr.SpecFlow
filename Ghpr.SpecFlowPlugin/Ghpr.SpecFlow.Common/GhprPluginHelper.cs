namespace Ghpr.SpecFlow.Common
{
    public static class GhprPluginHelper
    {
        public static int GhprTestRunnerCount;
        public static IGhprSpecFlowHelper TestExecutionEngineHelper;

        private static readonly object Lock;

        static GhprPluginHelper()
        {
            Lock = new object();
            TestsAreRunningInParallel = false;
        }

        public static void Init(IGhprSpecFlowHelper helper)
        {
            lock (Lock)
            {
                GhprTestRunnerCount = 0;
                TestExecutionEngineHelper = helper;
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