using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavebsiteDAL
{
    public class DBUpdate
    {
        public static int InsertUpdate(string version,string updateName, string description, int game)
        {
            return DALHelper.Insert($"INSERT INTO GameUpdates ([Update Version],[Update Name], [Update Description], [Game]) VALUES ('{version}','{updateName}','{description}',{game})");
        }

        public static DataTable ListUpdates(int game)
        {
            return DALHelper.AllWhere("GameUpdates", "Game", game);
        }
    }
}
