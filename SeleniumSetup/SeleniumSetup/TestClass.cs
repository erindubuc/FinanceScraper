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
            // Driver finds Sign In Link on Finance Portfolio Page
            driver.FindElement(By.XPath(".//*[@title='Sign In']")).Click();

            // Driver finds login textbox, enters username, and presses enter
            driver.FindElement(By.XPath(".//*[@id='login-username']")).SendKeys("avengersassembull" + Keys.Enter);

            // Driver waits for browser to load password page
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));

            // Driver finds password textbox, enters password, and presses enter
            IWebElement passwordTextField = wait.Until(driver => driver.FindElement(By.Id("login-passwd")));
            passwordTextField.SendKeys("Ready2rock" + Keys.Enter);

            //wait.Until(d => driver.FindElement(By.TagName("tbody")));

        }
    }
}
