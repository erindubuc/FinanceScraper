using System;
using System.Collections.Generic;

namespace StockScraper.Models
{
    public partial class HistoryOfStockInfo
    {
        public byte StockId { get; set; }
        public string Symbol { get; set; }
        public string PercentChange { get; set; }
        public string AverageVolume { get; set; }
        public string LastPrice { get; set; }
        public string MarketTime { get; set; }
        public string OpenPrice { get; set; }
        public string HighPrice { get; set; }
        public string LowPrice { get; set; }
        public string YearWeekHigh { get; set; }
        public string YearWeekLow { get; set; }
        public DateTime Date { get; set; }
    }
}
