using Highcon.Infra;
using Highcon.Pom;
using Highcon.webdriverinitializer;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Highcon.pom
{
    internal class HomePage
    {
        private static WebDriver webDriver = BrowserFactory.GetDriver();
        // Selector for the home page title element
        public By homePageTitle = By.Id("headerTitle");

        // Selector for the "Add New" button element
        public By addNewBtn = By.CssSelector("span[class='p-button-icon p-button-icon-left pi pi-plus']");

        // Selector for the "Add New File" dropdown button element
        public By addNewFileDropdownBtn = By.CssSelector("span[class='p-button-icon pi pi-chevron-down']");

        // Selector for the "Upload a File" button element
        public By uploadAFileBtn = By.Id("UploadFileBtnJQ");

        // Selector for the jobs table and its elements
        public By jobsList = By.CssSelector("div[class='p-orderlist-list-container']");


        //public By ele = By.XPath("//input[@type='file']");

        // Returns the text of the home page title element
        public string GetHomePageTitleName()
        {
            return Actions.GetText(homePageTitle);
        }

        // Clicks on the "Add New File" dropdown button element
        public void ClickAddNewFileDropdown()
        {
            Actions.Click(addNewFileDropdownBtn);
        }

        // Uploads a file using the provided file path
        public void UploadFile(string filePath)
        {
            // Click on the "Add New" button element
            Actions.Click(addNewBtn);
            // Send the file path to the "Upload a File" button element using AutoIt
            Actions.UploadFileWithAutoIt(filePath);
        }
        public List<IWebElement> GetDivElementsFromJobsList()
        {
            Actions.waitElementToBeVisible(jobsList);

            // Find the parent div element
            IWebElement parentDiv = webDriver.FindElement(jobsList);

            // Find all the li elements inside the parent div
            List<IWebElement> liElements = parentDiv.FindElements(By.TagName("li")).ToList();

            return liElements;
        }
        public List<string> GetJobsNamesFromTheJobsList()
        {
            List<IWebElement> liElements = GetDivElementsFromJobsList();
            List<string> jobsNames = new List<string>();
            foreach (var li in liElements)
            {
                jobsNames.Add(li.FindElements(By.TagName("div"))[1].Text);

            }
            foreach (var name in jobsNames)
            {
                TestLogger.INFO(name);
            }
            return jobsNames;
        }
    }
}
