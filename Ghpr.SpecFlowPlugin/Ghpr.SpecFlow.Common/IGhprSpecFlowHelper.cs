﻿using System;
using Ghpr.Core.Interfaces;
using TechTalk.SpecFlow;

namespace GhprSpecFlow.Common
{
    public interface IGhprSpecFlowHelper
    {
        IGhprSpecFlowScreenHelper ScreenHelper { get; }

        ITestRun GetTestRunOnScenarioStart(FeatureInfo fi, ScenarioInfo si);
        ITestRun UpdateTestRunOnScenarioEnd(ITestRun tr, Exception testError, string testOutput);
    }
}
