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
            // waitHelper.WaitForElementIsDisplayed(mainPage.mainGrid);
           
            mainPage.CreateNewItem();           
            SIForm siForm = new SIForm(driver);
            ItemData itemData = new ItemData()
            {
                Customer = "AMC Bridge",
                Contact = "Alexandr Ivashina",
                AssignedTo = "Jake Hall",
                Summary = "test_summary",
                Description = "test_description",
                Severity = "Level 1",
                Product = "Innovator",
                Version = "11.0 SP2"
            };
            siForm.FillForm(itemData);
            string siNumber = siForm.SaveItem();

            AttachmentsTab attTab = new AttachmentsTab(driver);
            siForm.ActivateTab("Attachments");
            attTab.AddNewAttach("Files\\Bug.png");
            siForm.CloseItem();
            mainPage.GoToPage("Dashboard");
            DashboardKanban dashKan = new DashboardKanban(driver);
          //  dashKan.SelectSIFromList(siNumber);
          //  dashKan.MoveSIToActiveColumn();
          //  dashKan.SelectSIFromList(siNumber);

            
            mainPage.Logout();

            
        }
    }
}
