using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialScraperApp.Models
{
    public class Stock
    {

        public int StockId { get; set; }
        public string Symbol { get; set; }
        public string PercentChange { get; set; }
        public string AvgVolume { get; set; }
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

        public Stock(int stockId, string symbol, string percentChange, string avgVolume,
            string last, string marketTime, string open, string high, string low,
            string yearWeekHigh, string yearWeekLow)
        {
            this.StockId = stockId;
            this.Symbol = symbol;
            this.PercentChange = percentChange;
            this.AvgVolume = avgVolume;
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
