using System;

namespace NavebsiteDAL
{
    /// <summary>
    /// Exception caused by SQL calls
    /// </summary>
    internal class SqlException : Exception
    {
        public SqlException() : base("SQL Error")
        {
        }
    }
}