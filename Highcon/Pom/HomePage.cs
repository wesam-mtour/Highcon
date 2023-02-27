using Highcon.Infra;
using OpenQA.Selenium;
using System;

namespace Highcon.pom
{
    public class HomePage
    {
        public By homePageTitle = By.Id("headerTitle");
        public By addNewFileDropdownButton = By.CssSelector("button[icon='pi pi-chevron-down']");
        public By uploadAFileButton = By.Id("UploadFileBtnJQ");

        public string GetHomePageTitleName() {
            return Actions.GetText(homePageTitle);
        }
        public void ClickAddNewFileDropdown()
        {
            Actions.Click(addNewFileDropdownButton);
        }
        public void UploadFile(String fileLocation) {
            Actions.Click(addNewFileDropdownButton);
            Actions.SendKeys(uploadAFileButton, fileLocation);
        }
    }
}
