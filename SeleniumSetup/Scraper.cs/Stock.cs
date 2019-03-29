using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraper
{
    public class Stock
    {  
        public string Symbol { get; set; }
        public string PercentChange { get; set; }
        public string AvgVolume { get; set; }
        public string CompanyName { get; set; }
        public string LastPrice { get; set; }
        public string MarketTime { get; set; }
        public string OpenPrice { get; set; }
        public string HighPrice { get; set; }
        public string LowPrice { get; set; }
        public string YearWeekHigh { get; set; }
        public string YearWeekLow { get; set; }

        public Stock()
        {

        }

        public Stock(string symbol, string percentChange, string avgVolume, string companyName,
            string last, string marketTime, string open, string high, string low,
            string yearWeekHigh, string yearWeekLow)
        {
            this.Symbol = symbol;
            this.PercentChange = percentChange;
            this.AvgVolume = avgVolume;
            this.CompanyName = companyName;
            this.LastPrice = last;
            this.MarketTime = marketTime;
            this.OpenPrice = open;
            this.HighPrice = high;
            this.LowPrice = low;
            this.YearWeekHigh = yearWeekHigh;
            this.YearWeekLow = yearWeekLow;
        }
       
    }
}
