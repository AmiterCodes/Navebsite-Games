using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace NavebsiteDAL
{
    public class DALHelper
    {
        /// <summary>
        /// queries a select statement on the SQL access database
        /// </summary>
        /// <param name="sql">sql query to run</param>
        /// <returns>DataTable containing the results</returns>
        public static DataTable Select(string sql)
        {
            DBHelper helper = new DBHelper(Constants.PROVIDER, Constants.PATH);

            if (!helper.OpenConnection()) throw new ConnectionException();

            DataTable tb = helper.GetDataTable(sql);
            helper.CloseConnection();
            
            return tb;
        }

        /// <summary>
        /// returns ta single row from a table by id
        /// </summary>
        /// <param name="id">id of the row requested</param>
        /// <param name="table">name of SQL table</param>
        /// <returns>DataRow containing the row</returns>
        public static DataRow GetRowById(int id, string table)
        {
            DBHelper helper = new DBHelper(Constants.PROVIDER, Constants.PATH);

            if (!helper.OpenConnection()) throw new ConnectionException();
            string sql = $"SELECT * FROM {table} WHERE ID = {id}";

            DataTable tb = helper.GetDataTable(sql);
            helper.CloseConnection();

            if (tb.Rows.Count < 1) return null;

            return tb.Rows[0];
        }

        /// <summary>
        /// Returns a random row from a table
        /// </summary>
        /// <param name="table">name of SQL table</param>
        /// <param name="column">name of a column in the table, will only look at rows that have this</param>
        /// <returns>DataRow containing the results</returns>
        public static DataRow Random(string table, string column)
        {
            DBHelper helper = new DBHelper(Constants.PROVIDER, Constants.PATH);

            if (!helper.OpenConnection()) throw new ConnectionException();
            string sql = $"SELECT top 1 * from {table} ORDER BY rnd({column})";

            DataTable tb = helper.GetDataTable(sql);
            helper.CloseConnection();
            if (tb.Rows.Count == 0) return null; 
            return tb.Rows[0];
        }

        /// <summary>
        /// Returns a random row from a table with a where clause
        /// </summary>
        /// <param name="table">name of SQL table</param>
        /// <param name="column">column to compare</param>
        /// <param name="value">value that is required for the row</param>
        /// <returns>DataRow containing the results</returns>
        public static DataRow RandomWhere(string table, string column, int value)
        {
            DBHelper helper = new DBHelper(Constants.PROVIDER, Constants.PATH);

            if (!helper.OpenConnection()) throw new ConnectionException();
            string sql = $"SELECT top 1 * from {table} WHERE {column} = {value} ORDER BY rnd({column})";

            DataTable tb = helper.GetDataTable(sql);
            helper.CloseConnection();
            if (tb.Rows.Count == 0) return null;
            return tb.Rows[0];
        }

        /// <summary>
        /// Returns a random row from a table with a where clause
        /// </summary>
        /// <param name="table">name of SQL table</param>
        /// <param name="column">column to compare</param>
        /// <param name="value">value that is required for the row</param>
        /// <returns>DataRow containing the results</returns>
        public static DataRow RandomWhere(string table, string column, string value)
        {
            DBHelper helper = new DBHelper(Constants.PROVIDER, Constants.PATH);

            if (!helper.OpenConnection()) throw new ConnectionException();
            string sql = $"SELECT top 1 * from {table} WHERE {column} = '{value}' ORDER BY rnd({column})";

            DataTable tb = helper.GetDataTable(sql);
            helper.CloseConnection();
            if (tb.Rows.Count == 0) return null;
            return tb.Rows[0];
        }

        /// <summary>
        /// Returns a table of al rows from a table with a where clause
        /// </summary>
        /// <param name="table">name of SQL table</param>
        /// <param name="column">column to compare</param>
        /// <param name="value">value that is required for the rows</param>
        /// <returns>DataTable containing the matching rows</returns>
        public static DataTable AllWhere(string table, string column, int value)
        {
            DBHelper helper = new DBHelper(Constants.PROVIDER, Constants.PATH);

            if (!helper.OpenConnection()) throw new ConnectionException();
            string sql = $"SELECT * FROM {table} WHERE `{column}` = {value}";

            DataTable tb = helper.GetDataTable(sql);
            helper.CloseConnection();
            return tb;
        }

        /// <summary>
        /// Returns a table of al rows from a table with a where clause
        /// </summary>
        /// <param name="table">name of SQL table</param>
        /// <param name="column">column to compare</param>
        /// <param name="value">value that is required for the rows</param>
        /// <returns>DataTable containing the matching rows</returns>
        public static DataTable AllWhere(string table, string column, string value)
        {
            DBHelper helper = new DBHelper(Constants.PROVIDER, Constants.PATH);

            if (!helper.OpenConnection()) throw new ConnectionException();
            string sql = $"SELECT * FROM {table} WHERE `{column}` = '{value}'";

            DataTable tb = helper.GetDataTable(sql);
            helper.CloseConnection();
            return tb;
        }

        /// <summary>
        /// returns all rows from a table
        /// </summary>
        /// <param name="table">name of SQL table</param>
        /// <returns>DataTable containing all rows of a table</returns>
        public static DataTable AllFromTable(string table)
        {
            DBHelper helper = new DBHelper(Constants.PROVIDER, Constants.PATH);

            if (!helper.OpenConnection()) throw new ConnectionException();
            string sql = $"SELECT * FROM {table}";

            DataTable tb = helper.GetDataTable(sql);
            helper.CloseConnection();
            return tb;
        }
    }
}
