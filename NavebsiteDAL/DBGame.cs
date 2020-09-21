using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace NavebsiteDAL
{
    public class DbGame
    {
        public static DataRow GetGame(int id)
        {
            return DalHelper.GetRowById(id,"Games");
        }

        public static DataTable AllGamesFromDeveloper(int devId)
        {
            return DalHelper.AllWhere("Games", "Developer", devId);
        }

        public static int InsertGame(string gameName, string link, string version, string description, string background, string logo, int developer, double price)
        {
            return DalHelper.Insert($"INSERT INTO Games ([Game Name],[Game Link],Description,Background,Logo,Developer,Price) " +
                $"VALUES ('{gameName}','{link}','{description}','{background}','{logo}',{developer},{price})");
        }
        
        /// <summary>
        /// returns all games from the database
        /// </summary>
        /// <returns>DataTable of all games</returns>
        public static DataTable AllGames()
        {
            return DalHelper.AllFromTable("Games");
        }
    }
}
