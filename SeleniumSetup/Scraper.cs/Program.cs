using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Scraper
{
    public class Program
    {
        static void Main(string[] args)
        {
            WebDriver driver = new WebDriver();
            User user = new User();

            WebDriver.DriverLoginToPortfolioAndGetStockData();

            WebDriver.DisplayStockInfoToConsole();

         
            Console.ReadLine();

        }
    }
}
