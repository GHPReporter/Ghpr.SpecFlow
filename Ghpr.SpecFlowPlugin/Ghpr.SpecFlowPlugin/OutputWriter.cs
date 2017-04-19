using System;
using System.IO;
using TechTalk.SpecFlow;

namespace Ghpr.SpecFlowPlugin
{
    public class OutputWriter
    {
        private readonly StringWriter _sw;
        private readonly TextWriter _tw;

        public OutputWriter()
        {
            _tw = Console.Out;
            _sw = new StringWriter();
            Console.SetOut(_sw);
        }

        public void Flush()
        {
            if (_sw != null)
            {
                _tw.Write(_sw.ToString());
                _tw.Flush();
                _sw.Flush();
                var sb = _sw.GetStringBuilder();
                sb.Remove(0, sb.Length);
            }
        }

        public void Dispose()
        {
            _sw?.Dispose();
            Console.SetOut(_tw);
        }

        public void WriteLine(string s)
        {
            _sw?.WriteLine(s);
        }

        public void WriteFeature(FeatureInfo featureInfo)
        {
            _sw.WriteLine($"{featureInfo.Title}:");
            _sw.WriteLine($"{featureInfo.Description}");
        }

        public void WriteScenario(ScenarioInfo scenarioInfo)
        {
            _sw.WriteLine($"{scenarioInfo.Title}");
        }

        public void WriteStep(string text)
        {
            _sw.WriteLine($"Step: {text}");
        }

        public string GetOutput()
        {
            return _sw.ToString();
        }
    }
}