namespace Scraper
{
    public class User
    {
        private static string loginUrl = "https://login.yahoo.com/";
        private static string username = "avengersassembull";
        private static string password = "Ready2rock";
        private static string stockPortfolioUrl = "https://finance.yahoo.com/portfolio/p_2/view/view_2";

        public static string StockPortfolio { get => stockPortfolioUrl; set => stockPortfolioUrl = value; }
        public static string Username { get => username; set => username = value; }
        public static string Password { get => password; set => password = value; }
        public static string LoginUrl { get => loginUrl; set => loginUrl = value; }


    }
}
