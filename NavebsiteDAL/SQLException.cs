using System;

namespace NavebsiteDAL
{
    /// <summary>
    /// Exception caused by SQL calls
    /// </summary>
    [Serializable]
    internal class SqlException : Exception
    {
        public SqlException() : base("SQL Error")
        {
        }
    }
}