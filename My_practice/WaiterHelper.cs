using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_practice
{
    public class WaiterHelper
    {
        private IWebDriver driver;

        public WaiterHelper(IWebDriver driver)
        {
            this.driver = driver;
        }
        
        public void WaitDocumentCompleteState(int sec = 20)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(sec))
                .Until((d) => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState")
                .Equals("complete"));
        }

        public void WaitForElementIsEnabled(By locator)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until((d) => driver.FindElement(locator).Enabled);
        }

        public void WaitForElementIsDisplayed(By locator)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until((d) => driver.FindElement(locator).Displayed);
        }

        public void WaitForElementToBeClickable(By locator)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public void  waitForElementIsVisibility(By locator)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public void waitForUntilSpinnerIsDisplayed()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("spinner")));
        }
    }
}
