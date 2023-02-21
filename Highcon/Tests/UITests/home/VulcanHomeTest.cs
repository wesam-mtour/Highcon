using Highcon.webdriverinitializer;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace Highcon.Tests.UITests.home
{
    public class VulcanHomeTest
    {
        private WebDriver webDriver;
        String WEB_DRIVER_URL = "https://integration.vulcan.highcon.link/queue";

        [SetUp]
        public void start_Browser()
        {
            webDriver = BrowserFactory.StartWebDriver("Chrome");
            BrowserFactory.OpenUrl(WEB_DRIVER_URL);
        }
        [Test]
        public void test_Browserops()
        {
            System.Threading.Thread.Sleep(4000);
            IWebElement element = webDriver.FindElement(By.CssSelector("p#headerTitle"));
            Console.WriteLine(element.Text);
            // Test verification from the header title which should be equal to Job Queue
            Assert.AreEqual(element.Text, "Job Queue");
        }

        [TearDown]
        public void close_Browser()
        {
            BrowserFactory.Close();
        }
    }
}
