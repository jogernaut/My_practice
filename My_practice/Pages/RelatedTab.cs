using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace My_practice
{
    public class RelatedTab : SIForm
    {
        public RelatedTab(IWebDriver driver) : base(driver)
        {
        }

        #region
        By newRelatedBtn = By.XPath("//button[@title='New Related Issue']");
        By refreshRelatedBtn = By.XPath("//button[@title='Refresh Related Issues']");
        By closeAddRelatedBtn = By.CssSelector(".close");
        By addRelatedBtn = By.XPath("//button[@title='OK']");
        By runSearchBtn = By.XPath("//button[@title='Run Search']");
        By clearCriteriaBtn = By.XPath("//button[@title='Clear Search Criteria']");
        #endregion

        private IWebElement GetAddRelatedWindow()
        {
            IWebElement addWindow = driver.FindElement(By.CssSelector(".modal.fade.in"));
            return addWindow;
        }

        private void ClickAddNewRelated()
        {
            GetActiveTab().FindElement(newRelatedBtn).Click();
            waitHelper.WaitForElementIsDisplayed(By.CssSelector(".modal.fade.in"));
        }

        public void ClickRefreshRelatedTab()
        {
            GetActiveTab().FindElement(refreshRelatedBtn).Click();
        }

        private void ClickRunSearch()
        {
            GetAddRelatedWindow().FindElement(runSearchBtn).Click();
            waitHelper.waitForUntilSpinnerIsDisplayed();
        }

        private void ClickClearCriteria()
        {
            GetAddRelatedWindow().FindElement(clearCriteriaBtn).Click();
        }

        private void ClickOkButton()
        {
            GetAddRelatedWindow().FindElement(addRelatedBtn).Click();
        }
    }
}
