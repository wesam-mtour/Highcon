using Highcon.Infra;
using Highcon.pom;
using Highcon.Pom;
using Highcon.webdriverinitializer;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.IO;

namespace Highcon.Tests.UITests.home
{
    internal class VulcanHomeTest
    {
        private WebDriver webDriver;
        private HomePage homePage;
        private JobPage jobPage;
        private readonly string WebDriverUrl = "https://integration.vulcan.highcon.link/queue";

        [SetUp]
        public void SetUp()
        {
            webDriver = BrowserFactory.StartWebDriver("Chrome");
            homePage = new HomePage();
            jobPage = new JobPage();
            BrowserFactory.OpenUrl(WebDriverUrl);
        }
        [Test]
        public void HomePageTitleTest()
        {
            TestLogger.INFO($"Test {TestContext.CurrentContext.Test.Name} started");
            TestLogger.STEP("Get the title appears in the home page");
            string pageTitle = homePage.GetHomePageTitleName();
            TestLogger.STEP("Verify the header title equal to \"Job Queue\"");
            Assert.AreEqual(pageTitle, "Job Queue");
        }
        [Test]
        public void UploadFile()
        {
            TestLogger.INFO($"Test {TestContext.CurrentContext.Test.Name} started");
            string relativePath = @"..\..\Files\MyTestJob.dxf";
            string filePath = Path.GetFullPath(relativePath);
            string actualJobName = Path.GetFileNameWithoutExtension(filePath);
            TestLogger.STEP($"Start Uploading the file \"{actualJobName}\"");
            homePage.UploadFile(filePath);
            TestLogger.STEP("Verify the alert message shows successful upload");
            string alertMsg = jobPage.GetAlertTextMessage();
            Assert.AreEqual(alertMsg, "Job created successfully.");
            TestLogger.STEP($"Verify the Job \"{actualJobName}\" appeared at the top of the Job Page");
            string expectedJobName = jobPage.GetJobName();
            Assert.AreEqual(expectedJobName, actualJobName);
            TestLogger.STEP($"Verify if a new status has appeared for the job \"{actualJobName}\"");
            string jobStatus = jobPage.GetJobStatus();
            Assert.AreEqual(jobStatus, "New");
            TestLogger.STEP("Back to the home page");
            jobPage.ClickCloseBtn();
            TestLogger.STEP($"Verify the Job \"{actualJobName}\" appeared one time in the home page table");
            List<string> jobsNames = homePage.GetJobsNamesFromTheJobsList();
            int number =  Utils.GetNumberOfOccurrencesForStringInList(jobsNames, actualJobName);
            Assert.AreEqual(number, 1);
        }
        [TearDown]
        public void TearDown()
        {
            TestLogger.INFO($"End Test {TestContext.CurrentContext.Test.Name}");
            BrowserFactory.Close();
        }
    }
}
