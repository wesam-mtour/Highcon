using Highcon.Infra;
using Highcon.pom;
using Highcon.webdriverinitializer;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;

namespace Highcon.Tests.UITests.home
{
    public class VulcanHomeTest
    {
        private HomePage homePage;
        private WebDriver webDriver;
        private readonly String WebDriverUrl = "https://integration.vulcan.highcon.link/queue";
        //private NLogger nlogger = new NLogger();
        NLogger nlogger = NLogger.GetInstance();

        [SetUp]
        public void SetUp()
        {
            homePage = new HomePage();
            webDriver = BrowserFactory.StartWebDriver("Chrome");
            BrowserFactory.OpenUrl(WebDriverUrl);
        }
        [Test]
        public void HomePageTitleTest()
        {
            nlogger.logger.Info($"Test {TestContext.CurrentContext.Test.Name} started");
            String pageTitle = homePage.GetHomePageTitleName();
            nlogger.logger.Info("Test verification that the header title should match \"Job Queue\"");
            Assert.AreEqual(pageTitle, "Job Queue", "The title is not as expected");
        }
        [Test]
        public void UploadFile()
        {
            string relativePath = @"..\..\Files\1.dxf";
            string filePath = Path.GetFullPath(relativePath);
            homePage.UploadFile(filePath);
            
        }

        [TearDown]
        public void TearDown()
        {
            BrowserFactory.Close();
        }
    }
}
