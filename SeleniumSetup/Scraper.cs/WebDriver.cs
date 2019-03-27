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
        public static IWebDriver driver;
        public static List<IWebElement> stockInfo;
        public ChromeOptions options;
      
        public static List<IWebElement> DriverLoginToPortfolioAndGetData()
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
                Console.WriteLine("This URL can't be found." + e.Message);
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
                Console.WriteLine("Element can't be found." + e.Message);
                throw (e);

            }

            try
            {
                // Driver finds password textbox, enters password, and presses enter 
                driver.FindElement(By.Id("login-passwd")).SendKeys(Password + Keys.Enter);
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Element can't be found." + e.Message);
                throw (e);
            }

            try
            {
                driver.Navigate().GoToUrl(StockPortfolio);
            }
            catch (Exception e)
            {
                Console.WriteLine("Can't find this site." + e.Message);
                throw (e);
            }

            try
            {
                driver.FindElements(By.TagName("tr"));
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Table rows can't be found." + e.Message);
                throw e;
            }

            try
            {
                stockInfo = new List<IWebElement>(driver.FindElements(By.TagName("td")));
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not find table data." + e.Message);
                throw e;
            }

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
