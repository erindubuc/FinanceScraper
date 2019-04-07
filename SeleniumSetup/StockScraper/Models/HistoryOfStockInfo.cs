using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockScraper.Models
{
    public partial class HistoryOfStockInfo
    {
        [Key]
        [Column(Order = 1)]
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

        [Key]
        [Column(Order = 2)]
        public DateTime Date { get; set; }
    }
}
