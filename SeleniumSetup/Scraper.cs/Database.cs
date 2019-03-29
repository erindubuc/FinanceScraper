using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraper
{
    public class Database
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

        
         
        
        
        public static void AddStockInfoIntoDatabase(Stock stock)
        {
            string connectionString = GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();


                //Console.WriteLine("State: {0}", connection.State);
                //Console.WriteLine("ConnectionString: {0}",
                //    connection.ConnectionString);

                try
                {
                    using (SqlCommand command = new SqlCommand(
                        "INSERT INTO StockInfo VALUES(@Symbol, @PercentChange, @AvgVolume, @CompanyName," +
                        "@Last, @MarketTime, @Open, @High, @Low, @YearWeekHigh, @YearWeekLow)", connection))
                    {
                        command.Parameters.Add(new SqlParameter("Symbol", stock.Symbol));
                        command.Parameters.Add(new SqlParameter("PercentChange", stock.PercentChange));
                        command.Parameters.Add(new SqlParameter("AvgVolume", stock.AvgVolume));
                        command.Parameters.Add(new SqlParameter("CompanyName", stock.CompanyName));
                        command.Parameters.Add(new SqlParameter("Last", stock.LastPrice));
                        command.Parameters.Add(new SqlParameter("MarketTime", stock.MarketTime));
                        command.Parameters.Add(new SqlParameter("Open", stock.OpenPrice));
                        command.Parameters.Add(new SqlParameter("High", stock.HighPrice));
                        command.Parameters.Add(new SqlParameter("Low", stock.LowPrice));
                        command.Parameters.Add(new SqlParameter("YearWeekHigh", stock.YearWeekHigh));
                        command.Parameters.Add(new SqlParameter("YearWeekLow", stock.YearWeekLow));
                        command.ExecuteNonQuery();
                        Console.WriteLine($"{stock.Symbol} stock successfully added");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Values could not be inserted into database");
                    throw e;
                }
            }
        }
        

    }
}
