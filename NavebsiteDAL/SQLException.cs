using System;

namespace NavebsiteDAL
{
    internal class SqlException : Exception
    {
        public SqlException() : base("SQL Error")
        {
        }
    }
}