using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavebsiteDAL
{
    public class DbGameCodes
    {
        public DataTable GameCodesForGame(int game)
        {
            return DalHelper.AllWhere("GameCodes", "Game", game);
        }
    }
}
