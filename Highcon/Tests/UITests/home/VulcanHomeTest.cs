using Highcon.pom;
using Highcon.webdriverinitializer;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using Highcon.Infra;

namespace Highcon.Tests.UITests.home
{
    public class VulcanHomeTest
    {
        private HomePage homePage;
        private WebDriver webDriver;
        private readonly String WebDriverUrl = "https://integration.vulcan.highcon.link/queue";

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
            String pageTitle = Actions.GetText(homePage.homePageTitle);
            // Test verification from the header title which should be equal to Job Queue
            Assert.AreEqual(pageTitle, "Job Queue");
        }

        [TearDown]
        public void TearDown()
        {
            BrowserFactory.Close();
        }
    }
}
