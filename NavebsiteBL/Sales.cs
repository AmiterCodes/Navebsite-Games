using System;
using System.Collections.Generic;
using System.Data;
using NavebsiteDAL;

namespace NavebsiteBL
{
    public class Sales
    {
        public Sales(DataRow dr)
        {
            Date = (DateTime) dr["Timestamp"];
            Purchases = (int) dr["Purchases"];
            Revenue = (double) dr["Revenue"];
        }

        public DateTime Date { get; set; }
        public int Purchases { get; set; }
        public double Revenue { get; set; }

        private static List<Sales> DataTableToList(DataTable tb)
        {
            var list = new List<Sales>();
            foreach (DataRow dr in tb.Rows) list.Add(new Sales(dr));
            return list;
        }

        public static DataTable GameStatsTable(int gameId)
        {
            return DbStats.GameSalesStats(gameId);
        }

        public static DataTable CompanyStatsTable(int devId)
        {
            return DbStats.CompanySalesStats(devId);
        }

        public static DataTable AllStatsTable()
        {
            return DbStats.TotalSalesStats();
        }

        public static List<Sales> GameStats(int gameId)
        {
            return DataTableToList(DbStats.GameSalesStats(gameId));
        }

        public static List<Sales> CompanyStats(int devId)
        {
            return DataTableToList(DbStats.CompanySalesStats(devId));
        }

        public static List<Sales> AllStats()
        {
            return DataTableToList(DbStats.TotalSalesStats());
        }
    }
}