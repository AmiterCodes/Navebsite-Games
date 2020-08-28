using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavebsiteDAL
{
    public class DBUser
    {
        public static DataTable AllUsers()
        {
            return DALHelper.AllFromTable("Users");
        }

        public static DataRow GetUserById(int user)
        {
            return DALHelper.GetRowById(user, "Users");
        }
    }
}
