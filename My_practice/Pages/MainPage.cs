using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_practice
{
    public class MainPage
    {
        private IWebDriver driver;
        private WaiterHelper waitHelper;

        #region
        By newItem = By.Id("addSI");
        By runSearch = By.XPath("//button[@title='Run Search']");
        By clearSearch = By.XPath("//button[@title='Clear Search Criteria']");
        By pageSize = By.XPath("//input[@title='Page Size']");
        By previousPage = By.XPath("//button[@title='Previous Page']");
        By nextPage = By.XPath("//button[@title='Next Page']");
        public By logout = By.CssSelector("#logoutForm a");
        public By mainGrid = By.Id("gridSI");
        #endregion

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            waitHelper = new WaiterHelper(driver);
        }
       
        public void CreateNewItem()
        {
            waitHelper.waitForUntilSpinnerIsDisplayed();                   
            driver.FindElement(newItem).Click();
            waitHelper.waitForUntilSpinnerIsDisplayed();
        }

        public void Logout()
        {
            waitHelper.waitForUntilSpinnerIsDisplayed();
            waitHelper.waitForElementIsVisibility(logout);
            driver.FindElement(logout).Click();
        }

        public void GoToPage(string namePage)
        {
            driver.FindElement(By.XPath("//p[text()='" + namePage + "']")).Click();
        }
    }
}
