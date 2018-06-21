using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace My_practice
{
    public class ManageDashboard : DashboardKanban
    {
        public ManageDashboard(IWebDriver driver) : base(driver)
        {
        }

        #region
        By newDashboardItemBtn = By.XPath("//button[@title='Create Dashboard Item']");
        By saveDashboardMenuBtn = By.XPath("//button[@title='Save Dashboard Menu']");
        By editDashboardItemBtn = By.XPath("//button[@title='Edit']");
        By deleteDashboardItemBtn = By.XPath("//button[@title='Delete']");
        By hiddenColumnList = By.XPath("//h1[text()='Hidden']/following-sibling::div");
        By displayedColumnList = By.XPath("//h1[text()='Displayed']/following-sibling::div");
        By closeMngBashboardWndBtn = By.CssSelector(".close");
        By arrowRight = By.XPath("//div[@class='si kanban arrows dash']/button[1]");
        By arrowLeft = By.XPath("//div[@class='si kanban arrows dash']/button[2]");
        #endregion

        protected IWebElement GetManageDashboardWindow()
        {
            IWebElement mngDashboardWnd = driver.FindElement(By.Id("dashboardDialog"));
            return mngDashboardWnd;
        }

        private void ClickNewDashboardBtn()
        {
            GetManageDashboardWindow().FindElement(newDashboardItemBtn).Click();
        }

        public void ClickCloseWmdBtn()
        {
            GetManageDashboardWindow().FindElement(closeMngBashboardWndBtn).Click();
        }

        private void ClickSaveDashboardMenuBtn()
        {
            GetManageDashboardWindow().FindElement(saveDashboardMenuBtn).Click();
            waitHelper.waitForUntilSpinnerIsDisplayed();
        }

        public void ClickEditDashboardItemBtn(string dashboardName)
        {
            SelectDashboardFromList(dashboardName);
            GetManageDashboardWindow().FindElement(editDashboardItemBtn).Click();
        }

        public void ClickDeleteDashboardItemBtn(string dashboardName)
        {
            SelectDashboardFromList(dashboardName);
            GetManageDashboardWindow().FindElement(deleteDashboardItemBtn).Click();
        }

        public void MoveDashboardToDisplayedColumn(string dashboardName)
        {
            SelectDashboardFromList(dashboardName);
            GetManageDashboardWindow().FindElement(arrowRight).Click();
            ClickSaveDashboardMenuBtn();
        }

        public void MoveDashboardToHiddenColumn(string dashboardName)
        {
            SelectDashboardFromList(dashboardName);
            GetManageDashboardWindow().FindElement(arrowLeft).Click();
            ClickSaveDashboardMenuBtn();
        }

        private void SelectDashboardFromList(string dashboardName)
        {
            GetManageDashboardWindow().FindElement(By.XPath(".//p[text()='" + dashboardName + "']/ancestor::div[1]"));
        }       
    }
}
