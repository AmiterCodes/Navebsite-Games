﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace NavebsiteDAL
{
    public class DbDeveloper
    {
        public static DataRow GetDeveloper(int id)
        {
            return DalHelper.GetRowById(id, "Developer");
        }


    }
}
