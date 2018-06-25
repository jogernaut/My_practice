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
        By newItemBtn = By.Id("addSI");
        By runSearchBtn = By.XPath("//button[@title='Run Search']");
        By clearSearchBtn = By.XPath("//button[@title='Clear Search Criteria']");
        By pageSize = By.XPath("//input[@title='Page Size']");
        By previousPageBtn = By.XPath("//button[@title='Previous Page']");
        By nextPageBtn = By.XPath("//button[@title='Next Page']");
        By amountOfSIItem = By.XPath("//button[@title='Next Page']//following-sibling::p[2]");
        By teamLeaderReportBtn = By.XPath("//button[@title='TeamLeader Report']");
        By SSRSReportBtn = By.XPath("//button[@title='SSRS Report']");
        By logoutBtn = By.CssSelector("#logoutForm a");
        
        #endregion

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            waitHelper = new WaiterHelper(driver);
        }
       
        public void CreateNewItem()
        {
            waitHelper.waitForUntilSpinnerIsDisplayed();                   
            driver.FindElement(newItemBtn).Click();
            waitHelper.waitForUntilSpinnerIsDisplayed();
        }

        public void Logout()
        {
            waitHelper.waitForUntilSpinnerIsDisplayed();
            waitHelper.waitForElementIsVisibility(logoutBtn);
            driver.FindElement(logoutBtn).Click();
        }

        public void GoToPage(string namePage)
        {
            driver.FindElement(By.XPath("//p[text()='" + namePage + "']")).Click();
            waitHelper.waitForUntilSpinnerIsDisplayed();
        }

        public void ExpandDashboard()
        {
            driver.FindElement(By.XPath("//ul[@class='si sidebar-menu']//button")).Click();
        }

        public void ClickRunSearch()
        {
            waitHelper.WaitForElementIsDisplayed(runSearchBtn);
            driver.FindElement(runSearchBtn).Click();
            waitHelper.waitForUntilSpinnerIsDisplayed();
        }

        public void ClickClearCriteria()
        {
            driver.FindElement(clearSearchBtn).Click();
        }
    }
}
