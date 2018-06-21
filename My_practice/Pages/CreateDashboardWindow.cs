using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace My_practice.Pages
{
    class CreateDashboardWindow : ManageDashboard
    {
        public CreateDashboardWindow(IWebDriver driver) : base(driver)
        {
        }

        #region
        By saveDashboardBtn = By.XPath("Id");
        By deleteDashboardBtn = By.XPath("Delete Item");
        By undoChangesBtn = By.XPath("Undo Changes on Item / Return to Manage Dashboard");
        By nameItemBtn = By.Id("NameItem");
        By shareDashboardBtn = By.Id("ShareItem");
        By numberSIdBtn = By.Id("NumberSI");
        By stateSIdBtn = By.Id("StateSI");
        By createdOn = By.Id("CreatedOn");
        By сustomer = By.Id("Customer");
        By multiSelectCheckbox = By.CssSelector("input[type=checkbox]");
        By assignedTo = By.Id("Assignee");
        #endregion

        private void FillField(By locator, string text)
        {
            GetManageDashboardWindow().FindElement(locator).Clear();
            GetManageDashboardWindow().FindElement(locator).SendKeys(text);
        }

        private void SelectFromDropDown(By locator, string option)
        {
            new SelectElement(GetManageDashboardWindow().FindElement(locator)).SelectByText(option);
        }



    }
}
