using Highcon.Infra;
using OpenQA.Selenium;
using System;

namespace Highcon.pom
{
    internal class HomePage
    {
        // Selector for the home page title element
        public By homePageTitle = By.Id("headerTitle");

        // Selector for the "Add New" button element
        public By addNewBtn = By.CssSelector("span[class='p-button-icon p-button-icon-left pi pi-plus']");

        // Selector for the "Add New File" dropdown button element
        public By addNewFileDropdownBtn = By.CssSelector("span[class='p-button-icon pi pi-chevron-down']");

        // Selector for the "Upload a File" button element
        public By uploadAFileBtn = By.Id("UploadFileBtnJQ");

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
    }
}
