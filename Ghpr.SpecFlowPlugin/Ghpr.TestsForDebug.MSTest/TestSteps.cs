using System;
//using System.Drawing;
//using System.Windows.Forms;
using GhprMSTest.SpecFlowPlugin;
using GhprSpecFlow.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Ghpr.TestsForDebug.MSTest
{
    [Binding]
    public class TestSteps : Steps
    {
        public static byte[] TakeScreen()
        {
            //var b = Screen.PrimaryScreen.Bounds;
            //var ic = new ImageConverter();
            //using (var btm = new Bitmap(b.Width, b.Height))
            //using (var g = Graphics.FromImage(btm))
            //{
            //    g.CopyFromScreen(b.X, b.Y, 0, 0, btm.Size, CopyPixelOperation.SourceCopy);
            //    return (byte[])ic.ConvertTo(btm, typeof(byte[]));
            //}
            return null;
        }

        private TestContext _testContext;
        private ScenarioContext _scenarioContext;

        public TestSteps(TestContext testContext, ScenarioContext scenarioContext)
        {
            _testContext = testContext;
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Given($"I have number {10}");
        }
        
        [Given(@"I have number (.*)")]
        public void GivenIHaveNumber(int p0)
        {
            Console.WriteLine("I have the number" + p0);
        }

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            _scenarioContext.Add(_scenarioContext.ContainsKey("first") ? "second" : "first", p0);
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
        }

        [When(@"I add test data")]
        public void WhenIAddTestData()
        {
            GhprMSTestSpecFlowPlugin.TestDataHelper.AddTestData("This is actual", "This is expected", "Comparing...");
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            Assert.AreEqual(p0, (int)_scenarioContext["first"] + (int)_scenarioContext["second"], "Wrong sum");
        }

        [Given(@"I take '(.*)' from table")]
        public void GivenITakeFromTable(int p0)
        {
            _scenarioContext.Add(_scenarioContext.ContainsKey("first") ? "second" : "first", p0);
        }

        [Then(@"the sum should be '(.*)'")]
        public void ThenTheSumShouldBe(int p0)
        {
            if (p0 != (int)_scenarioContext["first"] + (int)_scenarioContext["second"])
            {
                throw new Exception("sum is wrong");
            }
        }

        [When(@"I take screenshot")]
        public void WhenITakeScreenshot()
        {
            var bytes = TakeScreen();
            GhprPluginHelper.TestExecutionEngineHelper.ScreenHelper.SaveScreenshot(bytes);
        }

        [AfterScenario]
        public void WrapUpReport()
        {
            Console.WriteLine("After Scenario!");
            switch (_testContext.CurrentTestOutcome)
            {
                case UnitTestOutcome.Failed:
                case UnitTestOutcome.Error:
                    var bytes = TakeScreen();
                    GhprPluginHelper.TestExecutionEngineHelper.ScreenHelper.SaveScreenshot(bytes);
                    break;
            
                default:
                    break;
            }
        }

    }
}
