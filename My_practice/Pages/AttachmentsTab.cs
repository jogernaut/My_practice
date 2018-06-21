using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.IO;

namespace My_practice
{
    public class AttachmentsTab : SIForm
    {
        public AttachmentsTab(IWebDriver driver) : base(driver)
        {
        }

        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        #region
        By newAttachBtn = By.XPath("//button[@title='New Attachment']");
        By refreshAttachBtn = By.XPath("//button[@title='Refresh Attachments']");        
        By closeAddAttachBtn = By.CssSelector(".close");
        By saveAttachBtn = By.XPath("//button[@title='Save Attachment']");
        By chooseFileBtn = By.Id("File");
        By publishAttachCheckbox = By.CssSelector("input[type=checkbox]");
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
            GetActiveTab().FindElement(newAttachBtn).Click();
            waitHelper.WaitForElementIsDisplayed(By.CssSelector(".modal.fade.in"));
        }

        public void ClickRefreshAttachTab()
        {
            GetActiveTab().FindElement(refreshAttachBtn).Click();
        }

        private void ClickSaveAttach()
        {
            GetAddAttachWindow().FindElement(saveAttachBtn).Click();
            waitHelper.waitForUntilSpinnerIsDisplayed();
        }

        private void ClickPublishAttach()
        {
            GetAddAttachWindow().FindElement(publishAttachCheckbox).Click();
        }

        public void ClickCloseAddAttachWindow()
        {
            GetAddAttachWindow().FindElement(closeAddAttachBtn).Click();
        }

        private void SelectFile(string path)
        {
            GetAddAttachWindow().FindElement(chooseFileBtn).SendKeys(baseDirectory + path);
        }
    }
}
