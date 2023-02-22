using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using Highcon.webdriverinitializer;
using SeleniumExtras.WaitHelpers;
namespace Highcon.Infra
{
    public class Actions
    {
        private static WebDriver webDriver = BrowserFactory.GetDriver();
        public static WebDriverWait wait = BrowserFactory.GetWaitInstance();
        public static String GetText(By by)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(by));
            IWebElement webElement = webDriver.FindElement(by);
            Console.WriteLine("Element text is: " + webElement.Text);
            return webElement.Text;
        }
    }
}
