using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Highcon.webdriverinitializer
{
    public class BrowserFactory
    {
        private static WebDriver webDriver;
        private static WebDriverWait wait;
        private static int timeOut = 5;

        public static WebDriver StartWebDriver(String browserName){
            switch (browserName.ToLower())
            {
                case "chrome":
                    webDriver = new ChromeDriver();
                    webDriver.Manage().Window.Maximize();
                    break;                    
            }
            SetWaitInstance();
            return (WebDriver)webDriver;
        }
        public static string Title()
        {
            return webDriver.Title; 
        }
        public static void OpenUrl(string url)
        {
            webDriver.Url = url;
        }
        public static WebDriver GetDriver()
        {
            return webDriver; 
        }
        public static void Close()
        {
            webDriver.Quit();
        }
        public static void SetWaitInstance()
        {
            WebDriverWait webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeOut));
            wait = webDriverWait;
        }
        public static WebDriverWait GetWaitInstance()
        {
            return wait;
        }
    }
}

