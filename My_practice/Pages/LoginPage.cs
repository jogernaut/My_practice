using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_practice
{
    public class LoginPage
    {
        private IWebDriver driver;
        private WaiterHelper waitHelper;


        public LoginPage (IWebDriver driver)
        {
            this.driver = driver;
            waitHelper = new WaiterHelper(driver);
        }

        private void FillUserName(string userName)
        {
            driver.FindElement(By.Id("UserName")).Clear();
            driver.FindElement(By.Id("UserName")).SendKeys(userName);
        }

        private void FillPassword(string password)
        {
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys(password);
        }

        public void Login(string userName, string password)
        {
            FillUserName(userName);
            FillPassword(password);
            driver.FindElement(By.CssSelector("button.si-btn.btn")).Click();           
        }
    }
}
