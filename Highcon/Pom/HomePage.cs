using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
// For supporting Page Object Model
// Obsolete - using OpenQA.Selenium.Support.PageObjects;

namespace Highcon.pom
{
    public class HomePage
    {
        public By homePageTitle = By.CssSelector("p#headerTitle");
    }
}
