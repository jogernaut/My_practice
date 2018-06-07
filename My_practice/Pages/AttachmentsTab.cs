using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace My_practice
{
    class AttachmentsTab : SIForm
    {
        public AttachmentsTab(IWebDriver driver) : base(driver)
        {
        }

        #region
        By newAttach = By.XPath("//button[@title='New Attachment']");
        By refreshAttach = By.XPath("//button[@title='Refresh Attachments']");        
        By closeAddAttach = By.CssSelector(".close");
        By saveAttach = By.XPath("//button[@title='Save Attachment']");
        By chooseFileBtn = By.Id("File");
        By publishAttach = By.CssSelector("input[type=checkbox]");
        #endregion

        private IWebElement GetAddAttachWindow()
        {
            IWebElement addWindow = driver.FindElement(By.CssSelector(".modal.fade.in"));
            return addWindow;
        }

        public void AddNewAttach(string path)
        {
            ClickAddNewAttach();
            SelectFile(path);
            ClickSaveAttach();
        }

        public void AddNewPublicAttach(string path)
        {
            ClickAddNewAttach();
            SelectFile(path);
            ClickPublishAttach();
            driver.SwitchTo().Alert().Accept();
            ClickSaveAttach();
        }

        private void ClickAddNewAttach()
        {
            GetActiveTab().FindElement(newAttach).Click();
            waitHelper.WaitForElementIsDisplayed(By.CssSelector(".modal.fade.in"));
        }

        public void ClickRefreshAttachTab()
        {
            GetActiveTab().FindElement(refreshAttach).Click();
        }

        private void ClickSaveAttach()
        {
            GetAddAttachWindow().FindElement(saveAttach).Click();
            waitHelper.waitForUntilSpinnerIsDisplayed();
        }

        private void ClickPublishAttach()
        {
            GetAddAttachWindow().FindElement(publishAttach).Click();
        }

        public void ClickCloseAddAttachWindow()
        {
            GetAddAttachWindow().FindElement(closeAddAttach).Click();
        }

        private void SelectFile(string path)
        {
            GetAddAttachWindow().FindElement(chooseFileBtn).SendKeys(path);
        }
    }
}
