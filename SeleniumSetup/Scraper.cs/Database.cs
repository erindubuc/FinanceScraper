using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraper
{
    public class Database : WebDriver
    {

        public static void OpenSqlConnection()
        {
            string connectionString = GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Console.WriteLine("State: {0}", connection.State);
                Console.WriteLine("ConnectionString: {0}",
                    connection.ConnectionString);
            }
        }

        public static string GetConnectionString()
        {
            // To avoid storing the connection string in your code, 
            // you can retrieve it from a configuration file, using the 
            // System.Configuration.ConfigurationSettings.AppSettings property 
            return @"Data Source=(localDB)\MSSQLLocalDB;Initial Catalog=StockInfo;"
                + "Integrated Security=SSPI;";
        }

        public static void AddCurrentStockInfoIntoDatabase(Stock stock)
        {
            string connectionString = GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                /*
                Console.WriteLine("State: {0}", connection.State);
                Console.WriteLine("ConnectionString: {0}",
                    connection.ConnectionString);
                */

                try
                {
                    using (SqlCommand command = new SqlCommand(
                        /*
                        "INSERT INTO CurrentStockInfo VALUES(@StockId, @Symbol, @PercentChange, @AvgVolume, " +
                        "@Last, @MarketTime, @Open, @High, @Low, @YearWeekHigh, @YearWeekLow, @Date) ON DUPLICATE KEY UPDATE StockId = @StockId, PercentChange = @PercentChange, AvgVolume = @AvgVolume, " +
                            "Last = @Last, MarketTime = @MarketTime, Open = @Open, High = @High, Low = @Low, YearWeekHigh = @YearWeekHigh, " +
                            "YearWeekLow = @YearWeekLow, Date = @Date", connection))
                        */
                        "IF NOT EXISTS(SELECT * FROM CurrentStockInfo WHERE Symbol = @Symbol) INSERT INTO CurrentStockInfo VALUES(@StockId, @Symbol, @PercentChange, @AvgVolume, " +
                        "@Last, @MarketTime, @Open, @High, @Low, @YearWeekHigh, @YearWeekLow, @Date)" +
                        "ELSE UPDATE CurrentStockInfo SET Stock_Id = @StockId , PercentChange = @PercentChange, AverageVolume = @AvgVolume, " +
                            "LastPrice = @Last, MarketTime = @MarketTime, OpenPrice = @Open, HighPrice = @High, LowPrice = @Low, YearWeekHigh = @YearWeekHigh, " +
                            "YearWeekLow = @YearWeekLow, Date = @Date WHERE Symbol = @Symbol", connection))
                    //"ELSE INSERT INTO CurrentStockInfo VALUES(@StockId, @Symbol, @PercentChange, @AvgVolume, " +
                    // "@Last, @MarketTime, @Open, @High, @Low, @YearWeekHigh, @YearWeekLow, @Date)", connection))

                    {
                        command.Parameters.Add(new SqlParameter("StockId", stock.StockId));
                        command.Parameters.Add(new SqlParameter("Symbol", stock.Symbol));
                        command.Parameters.Add(new SqlParameter("PercentChange", stock.PercentChange));
                        command.Parameters.Add(new SqlParameter("AvgVolume", stock.AvgVolume));
                        command.Parameters.Add(new SqlParameter("Last", stock.LastPrice));
                        command.Parameters.Add(new SqlParameter("MarketTime", stock.MarketTime));
                        command.Parameters.Add(new SqlParameter("Open", stock.OpenPrice));
                        command.Parameters.Add(new SqlParameter("High", stock.HighPrice));
                        command.Parameters.Add(new SqlParameter("Low", stock.LowPrice));
                        command.Parameters.Add(new SqlParameter("YearWeekHigh", stock.YearWeekHigh));
                        command.Parameters.Add(new SqlParameter("YearWeekLow", stock.YearWeekLow));
                        command.Parameters.Add(new SqlParameter("Date", DateTime.Now));
                        command.ExecuteNonQuery();
                        Console.WriteLine($"{stock.Symbol} stock successfully added");
                    }

                    Console.WriteLine("The database has been successfully updated.");

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Values could not be inserted into database");


                    throw e;
                }
            }
        }

        public static void MoveCurrentStockInfoToHistoryOfStocksTable(Stock stock)
        {
            string connectionString = GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                try
                {
                    using (SqlCommand command = new SqlCommand(
                    "INSERT INTO HistoryOfStockInfo VALUES(@StockId, @Symbol, @PercentChange, @AvgVolume, " +
                        "@Last, @MarketTime, @Open, @High, @Low, @YearWeekHigh, @YearWeekLow, @Date) " +
                        "SELECT * FROM CurrentStockInfo", connection))
                    
                    {
                        command.Parameters.Add(new SqlParameter("StockId", stock.StockId));
                        command.Parameters.Add(new SqlParameter("Symbol", stock.Symbol));
                        command.Parameters.Add(new SqlParameter("PercentChange", stock.PercentChange));
                        command.Parameters.Add(new SqlParameter("AvgVolume", stock.AvgVolume));
                        command.Parameters.Add(new SqlParameter("Last", stock.LastPrice));
                        command.Parameters.Add(new SqlParameter("MarketTime", stock.MarketTime));
                        command.Parameters.Add(new SqlParameter("Open", stock.OpenPrice));
                        command.Parameters.Add(new SqlParameter("High", stock.HighPrice));
                        command.Parameters.Add(new SqlParameter("Low", stock.LowPrice));
                        command.Parameters.Add(new SqlParameter("YearWeekHigh", stock.YearWeekHigh));
                        command.Parameters.Add(new SqlParameter("YearWeekLow", stock.YearWeekLow));
                        command.Parameters.Add(new SqlParameter("Date", DateTime.Now));
                        command.ExecuteNonQuery();

                        Console.WriteLine($"All stocks successfully moved to History Table");
                    }

                    Console.WriteLine("The history table been successfully updated.");
                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Values could not be inserted into history table");

                    throw e;
                }
                
                /*
                try
                {
                    using (SqlCommand command = new SqlCommand(
                        "DELETE FROM CurrentStockInfo", connection))
                        //"INSERT INTO HistoryOfStockInfo SELECT * FROM CurrentStockInfo", connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("All rows from CurrentStockInfo have been deleted");
                    }

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Rows from CurrentStockInfo could not be deleted. " + e.Message);

                    throw e;
                }
                */

            }
        }
    }
}
