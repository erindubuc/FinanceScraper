using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Scraper
{
    public class WebDriver : User 
    {
        public ChromeOptions options;
        public static IWebDriver driver;
        public static IList<IWebElement> tableRows;
        //public static List<Stock> stocksList;
        
        public static void DriverLoginToPortfolioAndGetStockData()
        {
            try
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("start-maximized");

                // Instantiate driver object that goes to specified url
                driver = new ChromeDriver(options);

                driver.Navigate().GoToUrl(LoginUrl1);
            }
            catch (Exception e)
            {
                Console.WriteLine("This URL can't be found. " + e.Message);
                driver.Quit();
            }

            try
            {
                // Driver finds login textbox, enters username, and presses enter
                driver.FindElement(By.Id("login-username")).SendKeys(Username + Keys.Enter);

                // Driver waits for browser to load password page
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Element can't be found. " + e.Message);
                throw (e);
            }

            try
            {
                // Driver finds password textbox, enters password, and presses enter 
                driver.FindElement(By.Id("login-passwd")).SendKeys(Password + Keys.Enter);
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Element can't be found. " + e.Message);
                throw (e);
            }

            try
            {
                driver.Navigate().GoToUrl(StockPortfolio);
            }
            catch (Exception e)
            {
                Console.WriteLine("Can't find this site. " + e.Message);
                throw (e);
            }

            try
            {
                tableRows = driver.FindElements(By.ClassName("simpTblRow"));
                int rowCount = tableRows.Count;
                Console.WriteLine($"There are {rowCount} stocks");

                //Stock newStock = new Stock();
                
                //for (var row = 0; row < rowCount; row++)
                foreach (var row in tableRows)
                {

                    string symbol = driver.FindElement(By.XPath("//td[@aria-label='Symbol']")).Text;
                    string percentChange = driver.FindElement(By.XPath("//td[@aria-label='Chg %']")).Text;
                    string avgVolume = driver.FindElement(By.XPath("//td[@aria-label='Avg Vol (3m)']")).Text;
                    string companyName = driver.FindElement(By.XPath("//td[@aria-label='Company Name']")).Text;
                    string last = driver.FindElement(By.XPath("//td[@aria-label='Last Price']")).Text;
                    string marketTime = driver.FindElement(By.XPath("//td[@aria-label='Market Time']")).Text;
                    string open = driver.FindElement(By.XPath("//td[@aria-label='Open']")).Text;
                    string high = driver.FindElement(By.XPath("//td[@aria-label='High']")).Text;
                    string low = driver.FindElement(By.XPath("//td[@aria-label='Low']")).Text;
                    string yearWeekHigh = driver.FindElement(By.XPath("//td[@aria-label='52-Wk High']")).Text;
                    string yearWeekLow = driver.FindElement(By.XPath("//td[@aria-label='52-Wk Low']")).Text;

                    Stock newStock = new Stock(symbol, percentChange, avgVolume, companyName, last,
                        marketTime, open, high, low, yearWeekHigh, yearWeekLow);

                   
                    Database.AddStockInfoIntoDatabase(newStock);
                    Console.WriteLine($"{newStock.CompanyName} added to database");
                }
                

            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Table rows can't be found. " + e.Message);
                throw e;
            }

        }

        public static void DisplayStockInfoToConsole()
        {
            //foreach (var item in stockInfo)
            foreach(var item in tableRows)
            {
                Console.WriteLine(" " + item.Text + "\t\t");
                //Console.WriteLine(" " + item + "\t\t");
            }

        }

        /*
        public static List<Stock> GetListOfStocksToSendToDB()
        {
            List<Stock> stocksList = new List<Stock>();

            foreach (var row in tableRows)
            {
                string[] individualStockData = row.Text.Split(' ');

                Stock newStock = new Stock(individualStockData[0], individualStockData[1], individualStockData[2], individualStockData[3], individualStockData[4],
                    individualStockData[5], individualStockData[6], individualStockData[7], individualStockData[8], individualStockData[9], individualStockData[10]);
               
                stocksList.Add(newStock);
                Console.WriteLine($"{newStock.Symbol} added to stock list");
                
                
                Console.WriteLine($"{newStock.Symbol}");
                Console.WriteLine($"{newStock.PercentChange}");
                Console.WriteLine($"{newStock.AvgVolume}");
                Console.WriteLine($"{newStock.CompanyName}");
                        
            }

            return stocksList;
            //Database.AddStockInfoIntoDatabase(stocksList);

        }
        */

    }
}
