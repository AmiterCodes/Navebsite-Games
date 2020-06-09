using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace NavebsiteDAL
{
    public class DBDeveloper
    {
        public static DataRow GetDeveloper(int id)
        {
            return DALHelper.GetRowById(id, "Developer");
        }


    }
}
