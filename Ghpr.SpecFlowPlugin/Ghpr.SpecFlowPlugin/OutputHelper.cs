using System;
using System.IO;
using TechTalk.SpecFlow;

namespace Ghpr.SpecFlowPlugin
{
    public static class OutputHelper
    {
        private static StringWriter _sw;
        private static TextWriter _tw;

        public static void Initialize()
        {
            _tw = Console.Out;
            _sw = new StringWriter();
            Console.SetOut(_sw);
        }

        public static void Flush() {
            if (_sw != null) {
                _tw.Write(_sw.ToString());
                _sw.Flush();
                var sb = _sw.GetStringBuilder();
                sb.Remove(0, sb.Length);
            }
        }

        public static void Dispose()
        {
            _sw?.Dispose();
            Console.SetOut(_tw);
        }

        public static void WriteLine(string s)
        {
            _sw?.WriteLine(s);
        }

        public static void WriteFeature(FeatureInfo featureInfo)
        {
            _sw.WriteLine($"{featureInfo.Title}:");
            _sw.WriteLine($"{featureInfo.Description}");
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