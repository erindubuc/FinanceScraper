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
        public static List<Stock> ListOfAllStocks;


        public static List<Stock> DriverLoginToPortfolioAndGetStockData()
        {
            try
            {
                ChromeOptions options = new ChromeOptions();

                options.AddArguments("start-maximized");

                driver = new ChromeDriver(options);

                driver.Navigate().GoToUrl(LoginUrl);
            }
            catch (Exception e)
            {
                Console.WriteLine("This URL can't be found. " + e.Message);

                driver.Quit();
            }

            try
            {
                driver.FindElement(By.Id("login-username")).SendKeys(Username + Keys.Enter);

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Element can't be found. " + e.Message);

                throw e;
            }

            try
            {
                driver.FindElement(By.Id("login-passwd")).SendKeys(Password + Keys.Enter);
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Element can't be found. " + e.Message);

                throw e;
            }
            catch (TimeoutException ex)
            {
                Console.WriteLine("Timeout while entering password." + ex.Message);

                throw ex;
            }

            try
            {
                driver.Navigate().GoToUrl(StockPortfolio);
            }
            catch (Exception e)
            {
                Console.WriteLine("Can't find this site. " + e.Message);

                throw e;
            }

            try
            {
                IWebElement stockTable = driver.FindElement(By.TagName("tbody"));

                IList<IWebElement> tableRows = new List<IWebElement>(stockTable.FindElements(By.ClassName("simpTblRow")));

                ListOfAllStocks = new List<Stock>();

                int stockId = 0;

                

                foreach (var row in tableRows)
                {
                    stockId++;
                    string[] singleStockData = row.Text.Split(' ');
                    string[] stockSymbolAndPercent = singleStockData[0].Split(new[] { "\r\n", "\r", "\n" },
                            StringSplitOptions.None
                        );

                    singleStockData[0] = stockSymbolAndPercent[0];
                    Console.WriteLine($"index 0 = {stockSymbolAndPercent[0]}");
                    Console.WriteLine($"index 1 = {stockSymbolAndPercent[1]}");
                    Console.WriteLine($"index 1 = {singleStockData[1]}");
                    Console.WriteLine($"index 2 = {singleStockData[2]}");
                    Console.WriteLine($"index 3 = {singleStockData[3]}");
                    Console.WriteLine($"index 4 = {singleStockData[4]}");
                    Console.WriteLine($"index 5 = {singleStockData[5]}");
                    Console.WriteLine($"index 6 = {singleStockData[6]}");
                    Console.WriteLine($"index 7 = {singleStockData[7]}");
                    Console.WriteLine($"index 8 = {singleStockData[8]}");
                    Console.WriteLine($"index 9 = {singleStockData[9]}");
                    Console.WriteLine();

                    Stock newStock = new Stock(stockId, stockSymbolAndPercent[0], stockSymbolAndPercent[1], singleStockData[1], singleStockData[2],
                        singleStockData[3] + singleStockData[4], singleStockData[5], singleStockData[6], singleStockData[7],
                        singleStockData[8], singleStockData[9]);

                    Console.WriteLine($"The new stock {newStock.Symbol} has been created");

                    ListOfAllStocks.Add(newStock);

                    Database.MoveCurrentStockInfoToHistoryOfStocksTable(newStock);
                    Database.AddCurrentStockInfoIntoDatabase(newStock);
                    
                    Console.WriteLine();
                }
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Table rows can't be found. " + e.Message);

                throw e;
            }

            driver.Quit();

            return ListOfAllStocks;
        }

        public static void DisplayStockInfoToConsole(List<IWebElement> tableRows)
        {
            foreach(var item in tableRows)
            {
                Console.WriteLine(" " + item.Text + "\t\t");
            }

        }   
    }
}
