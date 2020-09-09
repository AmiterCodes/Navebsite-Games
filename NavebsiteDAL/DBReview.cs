using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavebsiteDAL
{
    public class DBReview
    {
        public static DataTable ReviewsByGame(int gameId)
        {
            return DALHelper.AllWhere("GameReviews", "Game", gameId);
        }

        public static DataTable ReviewsByUser(int gameId)
        {
            return DALHelper.AllWhere("GameReviews", "[User]", gameId);
        }
    }
}
