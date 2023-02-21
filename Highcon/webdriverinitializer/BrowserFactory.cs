using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Highcon.webdriverinitializer
{
    public class BrowserFactory
    {
        private static WebDriver webDriver;
        public static WebDriver StartWebDriver(String browserName){
            switch (browserName.ToLower())
            {
                case "chrome":
                    webDriver = new ChromeDriver();
                    webDriver.Manage().Window.Maximize();
                    break;                    
            }
            return (WebDriver)webDriver;
        }
        public static string Title
        {
            get { return webDriver.Title; }
        }
        public static void OpenUrl(string url)
        {
            webDriver.Url = url;
        }
        public static WebDriver getDriver
        {
            get { return webDriver; }
        }
        public static void Close()
        {
            webDriver.Quit();
        }
    }
}
