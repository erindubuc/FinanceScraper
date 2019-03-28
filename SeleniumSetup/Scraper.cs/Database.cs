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

        /*
        public static void AddStockInfo(string symbol, string percentChange, string avgVolume,
            string companyName, string last, DateTime marketTime, string open, string high,
            string low, string weekYearHigh, string weekYearLow)
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
                        command.Parameters.Add(new SqlParameter("Symbol", Symbol));
                        command.Parameters.Add(new SqlParameter("PercentChange", PercentChange));
                       
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        */

    }
}
