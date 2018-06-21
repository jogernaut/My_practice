using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace My_practice
{
    public class SIForm
    {
        protected IWebDriver driver;
        protected WaiterHelper waitHelper;

        #region
        By SINumber = By.Id("Number");
        By state = By.Id("State");
        By createdOn = By.Id("CreatedOn");        
        By customer = By.Id("Customer");
        By сontact = By.Id("Contact");
        By assignedTo = By.XPath("//input[@id='Assigned To']");
        By summary = By.Id("Summary");
        By description = By.Id("Description");
        By priority = By.Id("Priority");
        By product = By.Id("Product");
        By version = By.Id("Version");
        By closedCheckbox = By.XPath("//div[@class='checkbox']//input");

        By saveSIBtn = By.Id("saveSiBtn");
        By lockSIBtn = By.Id("lockBtn");
        By unlockSIBtn = By.Id("unlockBtn");
        By promoteSIBtn = By.XPath("//button[@title='Promote Item']");
        By claimSIBtn = By.XPath("//button[@title='Claim Item']");
        By actionsSIBtn = By.Id("actions");
        By createDuplicateSIBtn = By.XPath("//button[@title='Create Duplicate SI']");
        #endregion

        public SIForm(IWebDriver driver)
        {
            this.driver = driver;
            waitHelper = new WaiterHelper(driver);
        }

        protected IWebElement GetActiveTab()
        {
            IWebElement newForm = driver.FindElement(By.CssSelector(".tab-pane.active"));
            return newForm;
        }

        private void FillField(By locator, string text)
        {
            GetActiveTab().FindElement(locator).Clear();
            GetActiveTab().FindElement(locator).SendKeys(text);
        }

        private void SelectFromDropDown(By locator, string option)
        {
            new SelectElement(GetActiveTab().FindElement(locator)).SelectByText(option);
        }

        public void FillForm(ItemData item)
        {
            FillField(customer, item.Customer);
            FillField(сontact, item.Contact);
            FillField(assignedTo, item.AssignedTo);
            if (driver.FindElement(By.CssSelector("#Contact ~ ul>li:nth-child(1)")).Displayed)
            {
                GetActiveTab().FindElement(By.CssSelector("#Contact ~ ul>li:nth-child(1)")).Click();
            }
            FillField(summary, item.Summary);
            FillField(description, item.Description);
            SelectFromDropDown(priority, item.Severity);
            SelectFromDropDown(product, item.Product);
            Thread.Sleep(500);
            SelectFromDropDown(version, item.Version);
        }

        public string SaveItem()
        {
            GetActiveTab().FindElement(saveSIBtn).Click();
            waitHelper.waitForUntilSpinnerIsDisplayed();
            string siNumber = GetValueFromField(SINumber);
            return siNumber;
        }

        public void LockItem()
        {
            GetActiveTab().FindElement(lockSIBtn).Click();
        }

        public void UnlockItem()
        {
            GetActiveTab().FindElement(unlockSIBtn).Click();
        }

        public void PromoteItem()
        {
            GetActiveTab().FindElement(promoteSIBtn).Click();
        }

        public void ClaimItem()
        {
            GetActiveTab().FindElement(claimSIBtn).Click();
        }

        public void ClickActions()
        {
            GetActiveTab().FindElement(actionsSIBtn).Click();
        }

        public void CreateDuplicateSI()
        {
            GetActiveTab().FindElement(createDuplicateSIBtn).Click();
        }

        public void CloseItem()
        {
            driver.FindElement(By.CssSelector("#si-tabs .active button")).Click();
        }

        public void ActivateTab(string tabName)
        {
            GetActiveTab().FindElement(By.XPath("//a[text()='" + tabName + "']")).Click();
        }

        public string GetValueFromField(By locator)
        {
            return GetActiveTab().FindElement(locator).GetAttribute("value");
        }
    }
}
