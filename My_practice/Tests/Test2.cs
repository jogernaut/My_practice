using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_practice
{
    [TestFixture]
    class Test2 : TestBase
    {
        [Test]
        public void SecondTest()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login("jhall", "innovator");
            MainPage mainPage = new MainPage(driver);
            waitHelper.WaitForElementIsDisplayed(mainPage.mainGrid);
            mainPage.CreateNewItem();
            waitHelper.waitForUntilSpinnerIsDisplayed();
            IWebElement newForm1 = driver.FindElement(By.CssSelector(".tab-pane.active"));
            newForm1.FindElement(By.XPath(".//button[@title='Search Customer']")).Click();
            SIForm siForm = new SIForm(driver);
            ItemData itemData = new ItemData()
            {
                Customer = "AMC Bridge",
                Contact = "Alexandr Ivashina",
                AssignedTo = "Dave Rolle",
                Summary = "test_summary",
                Description = "test_description",
                Severity = "Level 1",
                Product = "Innovator",
                Version = "11.0 SP2"
            };
            siForm.FillForm(itemData);
            siForm.GetValueFromField(siForm.SINumber);
            siForm.SaveItem();
            waitHelper.WaitForElementToBeClickable(mainPage.logout);
            mainPage.Logout();




        }
    }
}
