using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace NavebsiteDAL
{
    public class DBGame
    {
        public static DataRow GetGame(int id)
        {
            return DALHelper.GetRowById(id,"Games");
        }

        public static DataTable AllGamesFromDeveloper(int devId)
        {
            return DALHelper.AllWhere("Games", "Developer", devId);
        }

        public static int InsertGame(string gameName, string link, string version, string description, string background, string logo, int developer, double price)
        {
            return DALHelper.Insert($"INSERT INTO Games ([Game Name],[Game Link],Version,Description,Background,Logo,Developer,Price) " +
                $"VALUES ('{gameName}','{link}','{version}','{description}','{background}','{logo}',{developer},{price})");
        }
        
        /// <summary>
        /// returns all games from the database
        /// </summary>
        /// <returns>DataTable of all games</returns>
        public static DataTable AllGames()
        {
            return DALHelper.AllFromTable("Games");
        }
    }
}
