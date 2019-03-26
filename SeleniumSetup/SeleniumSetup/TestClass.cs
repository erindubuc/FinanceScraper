// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumSetup.BaseTest;

namespace SeleniumSetup 
{

    [TestFixture]
    public class TestClass : BaseSetupTeardown
    {
        public IWebDriver driver;
        private string LoginUrl = "https://login.yahoo.com/";
        private string username = "avengersassembull";
        private string password = "Ready2rock";

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

        public string LoginUrl1 { get => LoginUrl; set => LoginUrl = value; }

        [Test]
        public void NavigateToLogin_EnterLoginAndSubmit()
        {
            IWebElement loginTextField = driver.FindElement(By.XPath(".//*[@id='login-username']"));
            loginTextField.SendKeys("avengersassembull");
            IWebElement nextSubmitButton = driver.FindElement(By.XPath(".//*[@id='login-signin']"));
            nextSubmitButton.Submit();
            //Thread.Sleep(3000);

        }

        [Test]
        public void EnterPasswordAndSubmit_SuccessToHomepage()
        {
            // Driver finds login textbox, enters username, and presses enter
            driver.FindElement(By.Id("login-username")).SendKeys("avengersassembull" + Keys.Enter);

            // Driver waits for browser to load password page
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            // Driver finds password textbox, enters password, and presses enter 
            driver.FindElement(By.Id("login-passwd")).SendKeys("Ready2rock" + Keys.Enter);

            //wait.Until(d => driver.FindElement(By.TagName("tbody")));
            
        }

        
        [Test]
        public void OpenDriverNavigateAndLogin()
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
            
        }

        

        [Test]
        public void EnterUsernamePasswordAndSubmit_SuccessToStockPortfolio()
        {
            try
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("start-maximized");

                // Instantiate driver object that goes to specified url
                driver = new ChromeDriver(options);

                driver.Navigate().GoToUrl(LoginUrl1);
                // Driver finds login textbox, enters username, and presses enter
                driver.FindElement(By.Id("login-username")).SendKeys(Username + Keys.Enter);

                // Driver waits for browser to load password page
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                // Driver finds password textbox, enters password, and presses enter 
                driver.FindElement(By.Id("login-passwd")).SendKeys(Password + Keys.Enter);
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Element can't be found." + e.Message);
                throw (e);
                
            }
            

            //wait.Until(d => driver.FindElement(By.TagName("tbody")));

        }
    }

    public class User
    {
        private string username = "avengersassembull";
        private string password = "Ready2rock";

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
    }
}
