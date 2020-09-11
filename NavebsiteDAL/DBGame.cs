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
