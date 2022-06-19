using RelevantCodes.ExtentReports;
using NUnit.Framework;
using SeleniumFramework.Common;
using SeleniumFramework.PageItems;
using SeleniumFramework.Tools;

namespace QASeleniumTasks
{
    [TestFixture]
    public class TestBase
    {
        protected ExtentReports Report;
        protected Pages Pages;
        protected Browser Browser;
        protected ExtentTest Test;
        private int testTry = 0;

        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            Report = ReportingManager.Instance;
            Browser = new Browser();
            Pages = new Pages(Browser);
        }

        [SetUp]
        public void SetUp()
        {
            testTry = TestContext.CurrentContext.CurrentRepeatCount;
            Logging.StartTestClass(TestContext.CurrentContext.Test.Name, TestContext.CurrentContext.Test.Name);
            Logging.StartTestMethod(TestContext.CurrentContext.Test.MethodName, TestContext.CurrentContext.Test.MethodName);
            Test = Report.StartTest($"{TestContext.CurrentContext.Test.ClassName}#{TestContext.CurrentContext.Test.Name}_{testTry}", $"Try time: {testTry}");
            Pages.GetBrowser().ExtensiveTestReport = Test;
            Browser.Driver.Manage().Window.Maximize();
            Pages.LoginPage.Goto();
            Pages.NavigationPage.GotoSignIn();
            Pages.HomePage.LogIn();
        }

        [TearDown]
        public void TearDown()
        {
            //Writing test report depending of test outcome
            var status = TestContext.CurrentContext.Result.Outcome.Status.ToString();
            var message = TestContext.CurrentContext.Result.Message;
            string screenShotPath;

            LogStatus logStatus;
            switch (status)
            {
                case "Failed":
                    Browser.Driver.Manage().Window.Maximize();
                    screenShotPath = ReportingManager.Capture(Browser.Driver, TestContext.CurrentContext.Test.Name + testTry);
                    logStatus = LogStatus.Fail;
                    Test.Log(logStatus, "Test ended with " + logStatus + " - " + message);
                    Test.Log(logStatus, "Snapshot below " + Test.AddScreenCapture(screenShotPath));
                    Logging.Error("Test ended with " + logStatus + " - " + message);
                    break;
                case "Passed":
                    Browser.Driver.Manage().Window.Maximize();
                    logStatus = LogStatus.Pass;
                    screenShotPath = ReportingManager.Capture(Browser.Driver, TestContext.CurrentContext.Test.Name + testTry);
                    Test.Log(logStatus, "Snapshot below " + Test.AddScreenCapture(screenShotPath));
                    testTry = 0;
                    break;
                default:
                    logStatus = LogStatus.Fatal;
                    Browser.Driver.Manage().Window.Maximize();
                    screenShotPath = ReportingManager.Capture(Browser.Driver, TestContext.CurrentContext.Test.Name + testTry);
                    Test.Log(logStatus, "Test ended with unexpected result");
                    Test.Log(logStatus, "Snapshot below " + Test.AddScreenCapture(screenShotPath));
                    Logging.Error("Test ended with unexpected result");
                    break;
            }

            Report.EndTest(Test);
            Browser.SetScreen();
            Pages.NavigationPage.GotoSettings();
            Pages.SettingsPage.Logout();
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            Report.EndTest(Test);
            Report.Flush();
            Browser.Driver.Close();
            Browser.Driver.Quit();
            Browser.Driver.Dispose();
        }
    }
}
