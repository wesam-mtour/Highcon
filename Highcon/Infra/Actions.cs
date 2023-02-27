using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using Highcon.webdriverinitializer;
using SeleniumExtras.WaitHelpers;
namespace Highcon.Infra
{
    public class Actions
    {
        static NLogger  nlogger = NLogger.GetInstance();
        private static WebDriver webDriver = BrowserFactory.GetDriver();
        public static WebDriverWait wait = BrowserFactory.GetWaitInstance();
        public static String GetText(By by)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(by));
            IWebElement webElement = webDriver.FindElement(by);
            nlogger.logger.Info("Element text: " + webElement.Text);
            return webElement.Text;
        }

        public static void Click(By by)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
            IWebElement webElement = webDriver.FindElement(by);
            webElement.Click();
        }
        public static void SendKeys( By by, String str)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(by));
            IWebElement webElement = webDriver.FindElement(by);
            webElement.SendKeys(str);
        }
    }
}
