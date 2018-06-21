using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_practice
{
    public class CommentsTab : SIForm
    {
        public CommentsTab(IWebDriver driver) : base(driver)
        {
        }

        #region
        By newCommentBtn = By.XPath("//button[@title='New Comment']");
        By refreshCommentBtn = By.XPath("//button[@title='Refresh Comments']");
        By previousPageBtn = By.XPath("//button[@title='Previous Page']");
        By nextPageBtn = By.XPath("//button[@title='Next Page']");
        By closeAddWindowBtn = By.CssSelector(".close");
        By saveCommentBtn = By.XPath("//button[@title='Save/Update Comment']");
        By clearCommentBtn = By.XPath("//button[@title='Clear Comment']");
        By commentField = By.Id("Comment");
        By publishCommentCheckbox = By.CssSelector("input[type=checkbox]");
        By deleteCommentBtn = By.XPath("//button[@title='Delete Comment']");
        By lockCommentBtn = By.Id("lockBtn");
        By unlockCommentBtn = By.Id("unlockBtn");
        By editCommentBtn = By.XPath("//button[@title='Edit Comment']");        
        #endregion

        private IWebElement GetAddCommentWindow()
        {
            IWebElement addWindow = driver.FindElement(By.CssSelector(".modal.fade.in"));
            return addWindow;
        }

        public void AddNewComment(string comment)
        {
            ClickAddNewComment();
            FillCommentField(comment);
            ClickSaveComment();            
        }

        public void AddNewPublicComment(string comment)
        {
            ClickAddNewComment();
            FillCommentField(comment);
            ClickPublishComment();
            driver.SwitchTo().Alert().Accept();
            ClickSaveComment();
        }

        public void ClickCloseAddCommentWindow()
        {
            GetAddCommentWindow().FindElement(closeAddWindowBtn).Click();
        }

        private void ClickSaveComment()
        {
            GetAddCommentWindow().FindElement(saveCommentBtn).Click();
            waitHelper.waitForUntilSpinnerIsDisplayed();
        }

        public void ClickClearComment()
        {
            GetAddCommentWindow().FindElement(clearCommentBtn).Click();
        }

        private void FillCommentField(string text)
        {
            GetAddCommentWindow().FindElement(commentField).Clear();
            GetAddCommentWindow().FindElement(commentField).SendKeys(text);
        }

        private void ClickPublishComment()
        {
            GetAddCommentWindow().FindElement(publishCommentCheckbox).Click();
        }

        private void ClickAddNewComment()
        {
            GetActiveTab().FindElement(newCommentBtn).Click();
            waitHelper.WaitForElementIsDisplayed(By.CssSelector(".modal.fade.in"));
        }

        public void ClickRefreshCommentsTab()
        {
            GetActiveTab().FindElement(refreshCommentBtn).Click();
        }

        public void GoToPriviousPage()
        {
            GetActiveTab().FindElement(previousPageBtn).Click();
        }

        public void GoToNextPage()
        {
            GetActiveTab().FindElement(nextPageBtn).Click();
        }
    }
}
