using System.IO;
using TechTalk.SpecFlow;

namespace Ghpr.SpecFlowPlugin
{
    public static class OutputHelper
    {
        private static StringWriter _sw;
        
        public static void Initialize()
        {
            _sw = new StringWriter();
        }

        public static void Flush()
        {
            _sw?.Flush();
        }

        public static void Dispose()
        {
            _sw?.Dispose();
        }

        public static void WriteLine(string s)
        {
            _sw?.WriteLine(s);
        }

        public static void WriteFeature(FeatureInfo featureInfo)
        {
            _sw.WriteLine($"{featureInfo.Title}: {featureInfo.Description}");
        }

        public static void WriteScenario(ScenarioInfo scenarioInfo)
        {
            _sw.WriteLine($"{scenarioInfo.Title}");
        }

        public static string GetOutput()
        {
            return _sw.ToString();
        }
    }
}