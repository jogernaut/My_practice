using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_practice
{
    public class GridComponent
    {
        IWebDriver driver;
        WaiterHelper waitHelper;

        private By grid = By.Id("gridSI");

        public GridComponent(IWebDriver driver)
        {
            this.driver = driver;
            waitHelper = new WaiterHelper(driver);
        }

        /*public List<IWebElement> GetRows()
        {
            IWebElement mainGrid = driver.FindElement(grid);
            IList<IWebElement> rows = mainGrid.FindElement(By.XPath("//tbody/tr"));
        }*/

        public IWebElement GetGrid()
        {
            return driver.FindElement(grid);
        }


        public IList<IWebElement> GetRows()
        {           
            IList<IWebElement> rows = GetGrid().FindElements(By.XPath(".//tbody/tr[1]"));
            return rows;
        }

        public IWebElement GetRow(int rowNum)
        {            
            return GetRows().ElementAt(rowNum);              
        }

        public IList<IWebElement> GetHeadingsCells()
        {
            IWebElement headingsRow = GetGrid().FindElement(By.XPath(".//thead/tr[1]"));
            IList<IWebElement> headingColumns = headingsRow.FindElements(By.XPath(".//th"));
            return headingColumns;
        }

        public IList<IWebElement> GetSearchBarCells()
        {
            IWebElement searchBarRow = GetGrid().FindElement(By.CssSelector(".si-search-row"));
            IList<IWebElement> searchColumns = searchBarRow.FindElements(By.XPath(".//th"));
            return searchColumns;
        }

        public IWebElement GetSearchBarCell(int colNum)
        {
            return GetSearchBarCells().ElementAt(colNum);
        }

        public IWebElement GetSearchBarCell(string propName)
        {
            int colNum = GetPropertyColNumByName(propName);
            if (colNum < 0)
            {
                throw new Exception(string.Format("Column with name {0} is not found in grid", propName));
            }
            return GetSearchBarCells().ElementAt(colNum);
        }

        public int GetPropertyColNumByName(string propName)
        {
            IWebElement headingsRow = GetGrid().FindElement(By.XPath(".//thead/tr[1]"));
            IList<IWebElement> cells = headingsRow.FindElements(By.CssSelector(".sort-header-table"));            
            for (int i = 0; i < cells.Count; i++)
            {
                IWebElement cell = cells.ElementAt(i);
                string test = cell.FindElement(By.CssSelector(".si.text-grid")).Text;
                if (cell.FindElement(By.CssSelector(".si.text-grid")).Text.StartsWith(propName))
                {
                    return i;
                }
            }
            return -1;
        }

       public void SetValueInSearchBar(int colNum, string value)
        {
            /* IWebElement searchBarRow = GetGrid().FindElement(By.CssSelector(".si-search-row"));
             IList<IWebElement> cells = searchBarRow.FindElements(By.TagName("td")); */
                IList<IWebElement> cells = GetSearchBarCells();           
                IWebElement textbox = cells.ElementAt(colNum + 1).FindElement(By.TagName("input"));
                textbox.Click();
                textbox.Clear();
                textbox.SendKeys(value);
           
            {
                IWebElement selectField = cells.ElementAt(colNum + 1).FindElement(By.TagName("select"));
                new SelectElement(selectField).SelectByText(value);
            }

                 
           /* textbox.SendKeys(Keys.Enter);
            textbox.SendKeys(Keys.Tab);*/
        }

        public void SetValueInInputField(string propName, string value)
        {
            int colNum = GetPropertyColNumByName(propName);
            if (colNum < 0)
            {
                throw new Exception(string.Format("Column with name {0} is not found in grid", propName));
            }
            //SetValueInSearchBar(colNum, value);
            IList<IWebElement> cells = GetSearchBarCells();
            IWebElement textbox = cells.ElementAt(colNum + 1).FindElement(By.TagName("input"));
            textbox.Click();
            textbox.Clear();
            textbox.SendKeys(value);
        }

        public void SetValueInSelectField(string propName, string value)
        {
            int colNum = GetPropertyColNumByName(propName);
            if (colNum < 0)
            {
                throw new Exception(string.Format("Column with name {0} is not found in grid", propName));
            }
            //SetValueInSearchBar(colNum, value);
            IList<IWebElement> cells = GetSearchBarCells();
            IWebElement selectField = cells.ElementAt(colNum + 1).FindElement(By.TagName("select"));
            new SelectElement(selectField).SelectByText(value);
        }

        public int SelectRowByPropertyValue(string propName, string propValue)
        {
            int colNum = GetPropertyColNumByName(propName);
            colNum += 1;
            int rowNum = -1;
            if (colNum < 0)
            {
                throw new Exception(string.Format("Column with name {0} is not found in grid", propName));
            }
            for (int i = 0; i < GetRows().Count; i++)
            {
                if (GetCell(i, colNum).Text == propValue)
                {
                    GetCell(i, 0).Click();
                    rowNum = i;
                    break;
                }
            }
            if (rowNum == -1)
            {
                throw new Exception(string.Format("Row with {0} = {1} is not found in grid", propName, propValue));
            }
            return rowNum;
        }

      /*  public IWebElement GetCell(IWebElement row, int colNum)
        {
            return row.FindElements(By.ClassName("aras-grid-row-cell"))[colNum];
        }*/

        public IWebElement GetCell(int rowNum, int colNum)
        {
            return GetRow(rowNum).FindElements(By.XPath(".//td"))[colNum];
        }

    }
}
