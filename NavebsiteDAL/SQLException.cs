using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavebsiteDAL
{
    class SqlException : Exception
    {
        public SqlException() : base("SQL Error")
        {

        }
    }
}
