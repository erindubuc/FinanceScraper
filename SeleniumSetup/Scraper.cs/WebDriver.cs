using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Scraper
{
    public class WebDriver : User 
    {
        public ChromeOptions options;
        public static IWebDriver driver;
        public static List<IWebElement> tableRows;
        public static ICollection<IWebElement> stockInfo; 


        public static ICollection<IWebElement> DriverLoginToPortfolioAndGetData()
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
                tableRows = new List<IWebElement>(driver.FindElements(By.ClassName("simpTblRow")));
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Table rows can't be found. " + e.Message);
                throw e;
            }

            try
            {
                stockInfo = driver.FindElements(By.TagName("td"));

                /*
                var symbol = driver.FindElement(By.XPath("//td[@aria-label='Symbol']"));   
                var percentChange = driver.FindElement(By.XPath("//td[@aria-label='Chg %']"));
                var avgVolume = driver.FindElement(By.XPath("//td[@aria-label='Avg Vol (3m)']"));
                var companyName = driver.FindElement(By.XPath("//td[@aria-label='Company Name']"));
                var last = driver.FindElement(By.XPath("//td[@aria-label='Last Price']"));
                var marketTime = driver.FindElement(By.XPath("//td[@aria-label='Market Time']"));
                var open = driver.FindElement(By.XPath("//td[@aria-label='Open']"));
                var high = driver.FindElement(By.XPath("//td[@aria-label='High']"));
                var low = driver.FindElement(By.XPath("//td[@aria-label='Low']"));
                var yearWeekHigh = driver.FindElement(By.XPath("//td[@aria-label='52-Wk High']"));
                var yearWeekLow = driver.FindElement(By.XPath("//td[@aria-label='52-Wk Low']"));
                */
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not find table data. " + e.Message);
                throw e;
            }

            //driver.Quit();
            return stockInfo;

        }

        public static void DisplayStockInfoToConsole()
        {
            foreach (var item in stockInfo)
            {
                Console.WriteLine(" " + item.Text + "\t\t");
            }

        }


    }
}
