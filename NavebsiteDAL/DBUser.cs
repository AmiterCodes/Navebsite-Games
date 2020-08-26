using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavebsiteDAL
{
    class DBUser
    {
        public static DataTable AllUsers()
        {
            return DALHelper.AllFromTable("Users");
        }


    }
}
