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
        By newComment = By.XPath("//button[@title='New Comment']");
        By refreshComment = By.XPath("//button[@title='Refresh Comments']");
        By previousPage = By.XPath("//button[@title='Previous Page']");
        By nextPage = By.XPath("//button[@title='Next Page']");
        By closeAddWindow = By.CssSelector(".close");
        By saveComment = By.XPath("//button[@title='Save/Update Comment']");
        By clearComment = By.XPath("//button[@title='Clear Comment']");
        By commentField = By.Id("Comment");
        By publishComment = By.CssSelector("input[type=checkbox]");
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
            GetAddCommentWindow().FindElement(closeAddWindow).Click();
        }

        private void ClickSaveComment()
        {
            GetAddCommentWindow().FindElement(saveComment).Click();
            waitHelper.waitForUntilSpinnerIsDisplayed();
        }

        public void ClickClearComment()
        {
            GetAddCommentWindow().FindElement(clearComment).Click();
        }

        private void FillCommentField(string text)
        {
            GetAddCommentWindow().FindElement(commentField).Clear();
            GetAddCommentWindow().FindElement(commentField).SendKeys(text);
        }

        private void ClickPublishComment()
        {
            GetAddCommentWindow().FindElement(publishComment).Click();
        }

        private void ClickAddNewComment()
        {
            GetActiveTab().FindElement(newComment).Click();
            waitHelper.WaitForElementIsDisplayed(By.CssSelector(".modal.fade.in"));
        }

        public void ClickRefreshCommentsTab()
        {
            GetActiveTab().FindElement(refreshComment).Click();
        }

        public void GoToPriviousPage()
        {
            GetActiveTab().FindElement(previousPage).Click();
        }

        public void GoToNextPage()
        {
            GetActiveTab().FindElement(nextPage).Click();
        }
    }
}
