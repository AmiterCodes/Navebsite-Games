﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavebsiteDAL
{
    public class DBActivity
    {
        public static DataTable UserActivity(int user)
        {
            return DALHelper.Select($@"
SELECT TOP 30
*
FROM UserActivity
WHERE User = {user}
ORDER BY Timestamp DESC;
");
        }

        public static DataRow GetActivity(int id)
        {
            return DALHelper.GetRowById(id, "UserActivity");
        }
    }
}
