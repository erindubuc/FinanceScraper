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
        public static void Main(string[] args)
        {
            WebDriver driver = new WebDriver("https://login.yahoo.com/");
            
            WebDriver.LogInToSite("avengersassembull", "Ready2rock");

            WebDriver.MoveToDifferentPage("https://finance.yahoo.com/portfolio/p_2/view/view_1");

            WebDriver.GetCellDataForEachStock();

            WebDriver.DisplayStockInfoToConsole();

            Console.ReadLine();

        }
    }
}
