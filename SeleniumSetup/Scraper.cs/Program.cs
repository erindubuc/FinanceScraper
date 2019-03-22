using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System;

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


            Console.WriteLine("Signing in");
            Console.ReadLine();

        }
    }
}
