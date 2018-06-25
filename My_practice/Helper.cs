using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Data.SqlClient;
using System.IO;


namespace My_practice
{
    public class Helper
    {
        private IWebDriver driver;
        private bool acceptNextAlert = true;

        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        public Helper(IWebDriver driver)
        {
            this.driver = driver;
        }

       public void ClickPerform(By locator)
        {
            driver.FindElement(locator).Click();
        }

        public void ClickButtonViaJS(By locator)
        {
            IWebElement aBtn = driver.FindElement(locator);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", aBtn);
        }

        /*public IWebElement GetActiveElement(By locator)
        {
            IWebElement newForm = driver.FindElement(locator);
            return newForm;
        }

        public void FillField(By locator, string text, By element = null)
        {
            GetActiveElement(element).FindElement(locator).Clear();
            GetActiveElement(element).FindElement(locator).SendKeys(text);
        }

        public void SelectFromDropDown(By locator, string option, By element = null)
        {
            new SelectElement(GetActiveElement(element).FindElement(locator)).SelectByText(option);
        }*/

        public void SqlExecute()
        {
            string sqlConnectionString = @"Data Source=192.168.168.205;Initial Catalog=SupportIncident2_3_11_TEST;User ID=sa;Password=sasa;Persist Security Info=True;";
            SqlConnection conn = new SqlConnection(sqlConnectionString);
            conn.Open();           
            SqlCommand command = new SqlCommand("DELETE FROM [innovator].SUPPORT_INCIDENT WHERE SUMMARY = 'test_summary'", conn);
            SqlDataReader reader = command.ExecuteReader();            
            conn.Close();         
        }

        public void SqlExecute(string path)
        {
            StreamReader file = new StreamReader(baseDirectory + path);
            string fileContent = file.ReadToEnd();
            string[] sqlqueries = fileContent.Split(new[] { "\r\nGO", "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            string sqlConnectionString = @"Data Source=192.168.168.205;Initial Catalog=SupportIncident2_3_11_TEST;User ID=sa;Password=sasa;Persist Security Info=True;";
            SqlConnection conn = new SqlConnection(sqlConnectionString);            
            foreach (var query in sqlqueries)
            {
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                command.ExecuteReader();
                conn.Close();        
            }
        
              /*   Actions builder = new Actions(driver);
          builder.ContextClick(GetActiveTab().FindElement(saveSIBtn)).SendKeys(Keys.ArrowDown).Perform();*/

            /* // When testing a long web page with some controls that are not visible, trying to click them might throw an Element Is Not Visible
                //error. In that case, setting the focus on the element might make it visible
              IWebElement elem = driver.FindElement(By.Id("pass"));
              ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].focus();", elem);

            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", elem);
            //driver.FindElements(By.Name("gender"))[1].Click();
              */
        }

        /* scroll
          IWebElement elem = driver.FindElement(By.Name("submit_action_2"));
            int elemPos = elem.Location.Y;
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scroll(0, " + elemPos + ");");
            elem.Click();*/

    }
}
