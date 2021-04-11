using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NavebsiteDAL;

namespace NavebsiteBL
{
    /// <summary>
    /// class used for storing sales data for a certain date
    /// </summary>
    public class Sales
    {
        /// <summary>
        /// creates a sales object from dataRow
        /// </summary>
        /// <param name="dr">dataRow of sale</param>
        public Sales(DataRow dr)
        {
            Date = (DateTime) dr["Timestamp"];
            Purchases = (int) dr["Purchases"];
            Revenue = (double) dr["Revenue"];
        }

        public Sales() {}

        public DateTime Date { get; set; }
        public int Purchases { get; set; }
        public double Revenue { get; set; }
        /// <summary>
        /// return total amount of sales for a game
        /// </summary>
        /// <param name="id">id of game</param>
        /// <returns>sales object with all the game's sales and purchases</returns>
        public static Sales SalesForGame(int id)
        {
            DataRow row = DbStats.getGameStats(id);
            if (row == null)
                return new Sales
                {
                    Purchases = 0,
                    Revenue = 0
                };
            return new Sales
            {
                Purchases = (int) row["Purchases"],
                Revenue = (double) row["Revenue"]
            };
        }

        
        private static List<Sales> DataTableToList(DataTable tb)
        {
            return (from DataRow dr in tb.Rows select new Sales(dr)).ToList();
        }


        /// <summary>
        /// returns a list of sale days for a game 
        /// </summary>
        /// <param name="gameId">id of game</param>
        /// <returns>list of sales</returns>
        public static List<Sales> GameStats(int gameId)
        {
            return DataTableToList(DbStats.GameSalesStats(gameId));
        }

        /// <summary>
        /// returns a list of sale days for all games from a developer 
        /// </summary>
        /// <param name="devId">id of developer</param>
        /// <returns>list of sales</returns>
        public static List<Sales> CompanyStats(int devId)
        {
            return DataTableToList(DbStats.CompanySalesStats(devId));
        }
        /// <summary>
        /// returns a list of sale days for all games
        /// </summary>
        /// <returns>list of sales</returns>
        public static List<Sales> AllStats()
        {
            return DataTableToList(DbStats.TotalSalesStats());
        }
    }
}