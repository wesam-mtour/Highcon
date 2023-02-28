using Highcon.Infra;
using Highcon.pom;
using Highcon.Pom;
using Highcon.webdriverinitializer;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;

namespace Highcon.Tests.UITests.home
{
    internal class VulcanHomeTest
    {
        private HomePage homePage;
        private JobPage jobPage;
        private WebDriver webDriver;
        private readonly string WebDriverUrl = "https://integration.vulcan.highcon.link/queue";

        [SetUp]
        public void SetUp()
        {
            homePage = new HomePage();
            jobPage = new JobPage();
            webDriver = BrowserFactory.StartWebDriver("Chrome");
            BrowserFactory.OpenUrl(WebDriverUrl);
        }
        [Test]
        public void HomePageTitleTest()
        {
            NLogger.INFO($"Test {TestContext.CurrentContext.Test.Name} started");
            NLogger.STEP("Get the title appears in the home page");
            string pageTitle = homePage.GetHomePageTitleName();
            NLogger.STEP("Verify the header title equal to \"Job Queue\"");
            Actions.AreEqual(pageTitle, "Job Queue");
        }
        [Test]
        public void UploadFile()
        {
            NLogger.INFO($"Test {TestContext.CurrentContext.Test.Name} started");
            string relativePath = @"..\..\Files\MyTestJob.dxf";
            string filePath = Path.GetFullPath(relativePath);
            string actualJobName = Path.GetFileNameWithoutExtension(filePath);
            NLogger.STEP($"Start Uploading the file \"{actualJobName}\"");
            homePage.UploadFile(filePath);
            NLogger.STEP("Verify the alert message shows successful upload");
            string alertMsg = jobPage.GetAlertTextMessage();
            Actions.AreEqual(alertMsg, "Job created successfully.");
            NLogger.STEP("Verify the Job name appeared at the top of the Job Page");
            string expectedJobName = jobPage.GetJobName();
            Actions.AreEqual(expectedJobName, actualJobName);
            NLogger.STEP("Back to the home page");
            jobPage.ClickCloseBtn();
        }
        [TearDown]
        public void TearDown()
        {
            BrowserFactory.Close();
        }
    }
}
