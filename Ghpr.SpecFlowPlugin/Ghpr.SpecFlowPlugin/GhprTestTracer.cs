using System;
using System.Collections.Generic;
using System.Globalization;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;
using TechTalk.SpecFlow.Bindings.Reflection;
using TechTalk.SpecFlow.Tracing;

namespace Ghpr.SpecFlowPlugin
{
    public class GhprTestTracer : ITestTracer
    {
        public void TraceStep(StepInstance stepInstance, bool showAdditionalArguments)
        {
            Log.Write("  TraceStep: " + stepInstance.Text + showAdditionalArguments);
        }

        public void TraceWarning(string text)
        {
            Log.Write("  TraceWarning: " + text);
        }

        public void TraceStepSkipped()
        {
            Log.Write("  TraceStepSkipped");
        }

        public void TraceStepPending(BindingMatch match, object[] arguments)
        {
            Log.Write("  TraceStepPending: " + match.Success);
        }

        public void TraceBindingError(BindingException ex)
        {
            Log.Write("  TraceBindingError: " + ex.Message);
        }

        public void TraceDuration(TimeSpan elapsed, string text)
        {
            Log.Write("  TraceDuration: " + elapsed);
        }

        public void TraceDuration(TimeSpan elapsed, IBindingMethod method, object[] arguments)
        {
            Log.Write("  TraceDuration: " + elapsed);
        }

        public void TraceNoMatchingStepDefinition(StepInstance stepInstance, ProgrammingLanguage targetLanguage,
            CultureInfo bindingCulture, List<BindingMatch> matchesWithoutScopeCheck)
        {
            Log.Write("  TraceNoMatchingStepDefinition: " + stepInstance.Text);
        }

        public void TraceError(Exception ex)
        {
            Log.Write("  TraceError: " + ex.Message);
        }

        public void TraceStepDone(BindingMatch match, object[] arguments, TimeSpan duration)
        {
            Log.Write("  TraceStepDone1: " + match.Success);
            Log.Write("  TraceStepDone2: " + match.StepBinding.Method.Name);
            Log.Write("  TraceStepDone3: " + match.StepBinding.Method.Type.Name);
            Log.Write("  TraceStepDone4: " + match.StepBinding.Method.Type.FullName);
        }
    }
}