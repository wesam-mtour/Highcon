using Highcon.Infra;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Highcon.Pom
{
    internal class JobPage
    {
        // Selector for the alert message element
        public By alertMsg = By.CssSelector("div[class='p-toast-detail ng-tns-c54-11']");

        // Selector for the job name element
        public By jobName = By.Id("JobNameJCH");

        // Selector for the job name element
        public By jobStatus = By.Id("JobStatusJCH");

        // Selector for the close button element
        public By closeBtn = By.Id("CloseBtnPS");

        // Returns the text of the alert message element
        public string GetAlertTextMessage()
        {
            return Actions.GetText(alertMsg);
        }

        // Clicks on the close button element
        public void ClickCloseBtn()
        {
            Actions.Click(closeBtn);
        }

        // Returns the text of the job name element
        public string GetJobName()
        {
            return Actions.GetText(jobName);
        }
        public string GetJobStatus()
        {
            return Actions.GetText(jobStatus);
        }
    }
}
