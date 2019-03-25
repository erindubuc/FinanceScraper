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
    public class WebDriver
    {
        public ChromeOptions options;
        public static IWebDriver driver;
        public static List<IWebElement> stockInfo;

        public WebDriver(string url)
        {
            options = new ChromeOptions();
            options.AddArguments("start-maximized");

            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(url);
        }

        public static void LogInToSite(string user, string password)
        {
            driver.FindElement(By.Id("login-username")).SendKeys(user + Keys.Enter);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.Id("login-passwd")).SendKeys(password + Keys.Enter);
        }

        public static void MoveToDifferentPage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public static void FindTableBody()
        {
            driver.FindElement(By.TagName("tbody"));
        }

        public static void GetRowsFromStockTable()
        {
            driver.FindElements(By.TagName("tr"));
        }

        public static void GetCellDataForEachStock()
        {
            stockInfo = new List<IWebElement>(driver.FindElements(By.TagName("td")));
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
