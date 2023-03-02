using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using Highcon.webdriverinitializer;
using SeleniumExtras.WaitHelpers;
using AutoIt;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Highcon.Infra
{
    internal class Actions
    {
        // Initialize a WebDriver and WebDriverWait object
        private static WebDriver webDriver = BrowserFactory.GetDriver();
        public static WebDriverWait wait = BrowserFactory.GetWaitInstance();

        // Function to get the text of an element given a By object
        public static string GetText(By by)
        {
            // Wait for the element to be visible before getting its text
            wait.Until(ExpectedConditions.ElementIsVisible(by));
            // Find the element and get its text
            IWebElement webElement = webDriver.FindElement(by);
            TestLogger.INFO("Element text: " + webElement.Text);
            return webElement.Text;
        }

        // Function to click on an element given a By object
        public static void Click(By by)
        {
            // Wait for the element to be clickable before clicking on it
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
            // Find the element and click on it
            IWebElement webElement = webDriver.FindElement(by);
            webElement.Click();
        }

        // Function to send keys to an input element given a By object and a string
        public static void SendKeys(By by, string str)
        {
            // Wait for the element to be visible before sending keys to it
            wait.Until(ExpectedConditions.ElementIsVisible(by));
            // Find the element and send the specified keys to it
            IWebElement webElement = webDriver.FindElement(by);
            webElement.SendKeys(str);
        }

        // Function to upload a file using AutoIt
        public static void UploadFileWithAutoIt(string filePath)
        {
            AutoItX.WinWait("Open", "", 10);
            AutoItX.ControlSetText("Open", "", "Edit1", filePath);
            AutoItX.ControlClick("Open", "", "Button1");
        }

        // Wait for the element to be visible before doing actions
        public static void waitElementToBeVisible(By by)
        {
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
        }
    }
}
