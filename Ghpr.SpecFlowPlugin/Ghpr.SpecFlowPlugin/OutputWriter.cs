using System;
using System.IO;
using Ghpr.Core.Utils;
using TechTalk.SpecFlow;

namespace Ghpr.SpecFlowPlugin
{
    public class OutputWriter
    {
        private readonly StringWriter _sw;
        private readonly TextWriter _tw;
        private readonly bool _outputRedirected;

        public OutputWriter()
        {
            _outputRedirected = false;
            _tw = Console.Out;
            _sw = new StringWriter();
            StaticLog.Logger().Write($"OutputWriter Constr 1: {GhprPluginHelper.TestsAreRunningInParallel}");
            if (!GhprPluginHelper.TestsAreRunningInParallel)
            {
                StaticLog.Logger().Write($"OutputWriter Constr 2: {GhprPluginHelper.TestsAreRunningInParallel}");
                Console.SetOut(_sw);
                _outputRedirected = true;
            }
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
            if (_outputRedirected)
            {
                Console.SetOut(_tw);
            }
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
            _sw.WriteLine($"Step '{text}' is done.");
        }

        public string GetOutput()
        {
            return _sw.ToString();
        }
    }
}