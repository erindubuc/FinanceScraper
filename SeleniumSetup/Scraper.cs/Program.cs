using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Scraper
{
    public class Program
    {
        static void Main(string[] args)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");

            IWebDriver driver = new ChromeDriver(options);
            
            driver.Navigate().GoToUrl("https://login.yahoo.com/");

            // Driver finds login textbox, enters username, and presses enter
            driver.FindElement(By.Id("login-username")).SendKeys("avengersassembull" + Keys.Enter);

            // Driver waits for browser to load password page
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            // Driver finds password textbox, enters password, and presses enter 
            driver.FindElement(By.Id("login-passwd")).SendKeys("Ready2rock" + Keys.Enter);

            // Driver navigates to Finance page/portfolio
            driver.Navigate().GoToUrl("https://finance.yahoo.com/portfolio/p_2/view/view_1");

            // Find table
            driver.FindElement(By.TagName("tbody"));
            Console.WriteLine("Table found");

            // Get rows from table and store in List
            List<IWebElement> tableRows = new List<IWebElement> (driver.FindElements(By.TagName("tr")));
            

            //foreach (var row in tableRows)
            //    Console.WriteLine(tableRows);

            List<IWebElement> stockInfo = new List<IWebElement>(driver.FindElements(By.TagName("td")));

            foreach (var item in stockInfo)
            {
                Console.WriteLine(" " + item.Text + "\t\t");
            }


            //Console.WriteLine("Signing in");
            driver.Quit();
            Console.ReadLine();

        }
    }
}
