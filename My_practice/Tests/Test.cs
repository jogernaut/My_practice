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
    class Test : TestBase
    {
        [Test]
        public void FirstTest()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login("jhall", "innovator");
            MainPage mainPage = new MainPage(driver);
            //waitHelper.WaitForElementIsDisplayed(mainPage.mainGrid);
            GridComponent grid = new GridComponent(driver);
            // grid.GetSearchBarCell("Numbe grid.SetValueInSelectField("State", "Closed");r");
            grid.SelectRowByPropertyValue("Number", "SI-000958");
            grid.GetCell(1, 1);
            grid.GetRow(2);
            grid.SetValueInInputField("Closed On", "6/11/2018");
            //grid.SetValueInSelectField("State", "Closed");
            mainPage.ClickRunSearch();
            mainPage.CreateNewItem();
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
            siForm.SaveItem();
            /* CommentsTab comTab = new CommentsTab(driver);
             comTab.AddNewPublicComment("My comment");*/
           /* siForm.ActivateTab("Attachments");
            AttachmentsTab attTab = new AttachmentsTab(driver);
            attTab.AddNewPublicAttach("D:\\ASF_Project\\C# my project\\My_practice\\My_practice\\Files\\Bug.png");
            mainPage.Logout();*/            
        }
    }
}
