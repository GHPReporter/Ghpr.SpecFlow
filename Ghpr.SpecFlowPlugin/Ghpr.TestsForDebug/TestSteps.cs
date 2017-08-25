using System;
using GhprMSTest.SpecFlowPlugin;
using GhprNUnit.SpecFlowPlugin;
using TechTalk.SpecFlow;

namespace Ghpr.TestsForDebug
{
    [Binding]
    public class TestSteps
    {
        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            ScenarioContext.Current.Add(ScenarioContext.Current.ContainsKey("first") ? "second" : "first", p0);
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
        }

        [When(@"I add test data")]
        public void WhenIAddTestData()
        {
            //GhprMSTestSpecFlowPlugin.TestDataHelper.AddTestData("This is actual", "This is expected", "Comparing...");
            GhprNUnitSpecFlowPlugin.TestDataHelper.AddTestData("This is actual", "This is expected", "Comparing...");
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            if (p0 != (int)ScenarioContext.Current["first"] + (int)ScenarioContext.Current["second"])
            {
                throw new Exception("sum is wrong");
            }
        }

        [Given(@"I take '(.*)' from table")]
        public void GivenITakeFromTable(int p0)
        {
            ScenarioContext.Current.Add(ScenarioContext.Current.ContainsKey("first") ? "second" : "first", p0);
        }

        [Then(@"the sum should be '(.*)'")]
        public void ThenTheSumShouldBe(int p0)
        {
            if (p0 != (int)ScenarioContext.Current["first"] + (int)ScenarioContext.Current["second"])
            {
                throw new Exception("sum is wrong");
            }
        }

    }
}
