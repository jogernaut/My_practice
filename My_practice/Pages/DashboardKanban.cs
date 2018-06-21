using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_practice
{
    public class DashboardKanban
    {
        protected IWebDriver driver;
        protected WaiterHelper waitHelper;

        #region
        By refreshKanbanBtn = By.XPath("//button[@title='Refresh Kanban']");
        By manageDashboardBtn = By.XPath("//button[@title='Manage Dashboard']");
        By openColumnList = By.XPath("//h1[text()='Open']/following-sibling::div");
        By activeColumnList = By.XPath("//h1[text()='Active']/following-sibling::div");
        By completeColumnList = By.XPath("//h1[text()='Complete']/following-sibling::div");
        By arrowRight = By.XPath("//div[@class='si kanban arrows']/button[1]");
        By arrowLeft = By.XPath("//div[@class='si kanban arrows']/button[2]");
        #endregion

        public DashboardKanban(IWebDriver driver)
        {
            this.driver = driver;
            waitHelper = new WaiterHelper(driver);
        }

        public void MoveSIToActiveColumn(string siNumber)
        {
            SelectSIFromList(siNumber);
            driver.FindElement(arrowRight).Click();
            waitHelper.waitForUntilSpinnerIsDisplayed();
        }

        public void MoveSIToOpenColumn(string siNumber)
        {
            SelectSIFromList(siNumber);
            driver.FindElement(arrowLeft).Click();
            waitHelper.waitForUntilSpinnerIsDisplayed();
        }

        private void SelectSIFromList(string siNumber)
        {
            driver.FindElement(By.XPath("//a[text()='" + siNumber + "']/ancestor::li")).Click();
        }        

        public void OpenSIFromList(string siNumber)
        {
            driver.FindElement(By.XPath("//a[text()='" + siNumber + "']")).Click();
            waitHelper.waitForUntilSpinnerIsDisplayed();
        }

        public void ClickRefreshKanbanBtn()
        {
            driver.FindElement(refreshKanbanBtn).Click();
            waitHelper.waitForUntilSpinnerIsDisplayed();
        }

        public void ClickManageDashboardBtn()
        {
            driver.FindElement(manageDashboardBtn).Click();
            waitHelper.WaitForElementIsDisplayed(By.Id("dashboardDialog"));
        }
    }
}
