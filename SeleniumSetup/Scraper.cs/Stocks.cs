using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraper
{
    public class Stocks
    {
        public string Symbol { get; set; }
        public decimal PercentChange { get; set; }
        public decimal AvgVolume { get; set; }
        public string CompanyName { get; set; }
        public decimal LastPrice { get; set; }
        public DateTime MarketTime { get; set; }
        public decimal OpenPrice { get; set; }
        public decimal HighPrice { get; set; }
        public decimal LowPrice { get; set; }
        public decimal YearWeekHigh { get; set; }
        public decimal YearWeekLow { get; set; }
    }
}
