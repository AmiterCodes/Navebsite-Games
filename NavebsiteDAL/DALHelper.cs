using System.Data;

namespace NavebsiteDAL
{
    public class DalHelper
    {
        /// <summary>
        ///     runs an insert SQL statement
        /// </summary>
        /// <param name="sql">sql query</param>
        /// <returns>id of newly inserted row, -1 if it didn't work</returns>
        public static int Insert(string sql)
        {
            var helper = new DbHelper(Constants.Provider, Constants.Path);


            if (!helper.OpenConnection()) throw new ConnectionException();

            var id = helper.InsertWithAutoNumKey(sql);
            helper.CloseConnection();

            return id;
        }

        /// <summary>
        ///     if no row satisfies the check query, insert with the insert query
        /// </summary>
        /// <param name="insert">insert SQL query</param>
        /// <param name="check">check SQL query</param>
        /// <returns>the id of the inserted element, else the id of the first row</returns>
        public static int InsertIfNotExist(string insert, string check)
        {
            var helper = new DbHelper(Constants.Provider, Constants.Path);
            if (!helper.OpenConnection()) throw new ConnectionException();
            var tb = helper.GetDataTable(check);
            if (tb.Rows.Count == 0)
            {
                var id = helper.InsertWithAutoNumKey(insert);
                return id;
            }

            return (int) tb.Rows[0]["ID"];
        }

        /// <summary>
        ///     runs an insert SQL statement
        /// </summary>
        /// <param name="sql">sql query</param>
        /// <returns>id of newly inserted row, -1 if it didn't work</returns>
        public static int Update(string sql)
        {
            var helper = new DbHelper(Constants.Provider, Constants.Path);


            if (!helper.OpenConnection()) throw new ConnectionException();

            var id = helper.WriteData(sql);
            helper.CloseConnection();

            return id;
        }

        public static int UpdateWhere(string table, string column, string value, string checkColumn, string checkValue)
        {
            return Update($"UPDATE `{table}` SET `{column}` = '{value}' WHERE `{checkColumn}` = '{checkValue}'");
        }

        public static int UpdateWhere(string table, string column, int value, string checkColumn, int checkValue)
        {
            return Update($"UPDATE `{table}` SET `{column}` = '{value}' WHERE `{checkColumn}` = {checkValue}");
        }


        /// <summary>
        ///     queries a select statement on the SQL access database
        /// </summary>
        /// <param name="sql">sql query to run</param>
        /// <returns>DataTable containing the results</returns>
        public static DataTable Select(string sql)
        {
            var helper = new DbHelper(Constants.Provider, Constants.Path);


            if (!helper.OpenConnection()) throw new ConnectionException();

            var tb = helper.GetDataTable(sql);
            helper.CloseConnection();

            return tb;
        }

        /// <summary>
        ///     a method to check if a sql select statement has an existing row
        /// </summary>
        /// <param name="sql">select sql query to run</param>
        /// <returns>true if row exists</returns>
        public static bool RowExists(string sql)
        {
            return Select(sql).Rows.Count > 0;
        }

        /// <summary>
        ///     returns a single row from a table by id
        /// </summary>
        /// <param name="id">id of the row requested</param>
        /// <param name="table">name of SQL table</param>
        /// <returns>DataRow containing the row</returns>
        public static DataRow GetRowById(int id, string table)
        {
            var helper = new DbHelper(Constants.Provider, Constants.Path);

            if (!helper.OpenConnection()) throw new ConnectionException();
            var sql = $"SELECT * FROM {table} WHERE ID = {id}";

            var tb = helper.GetDataTable(sql);
            helper.CloseConnection();

            if (tb.Rows.Count < 1) return null;

            return tb.Rows[0];
        }

        /// <summary>
        ///     Returns a random row from a table
        /// </summary>
        /// <param name="table">name of SQL table</param>
        /// <param name="column">name of a column in the table, will only look at rows that have this</param>
        /// <returns>DataRow containing the results</returns>
        public static DataRow Random(string table, string column)
        {
            var helper = new DbHelper(Constants.Provider, Constants.Path);

            if (!helper.OpenConnection()) throw new ConnectionException();
            var sql = $"SELECT top 1 * from {table} ORDER BY rnd({column})";

            var tb = helper.GetDataTable(sql);
            helper.CloseConnection();
            if (tb.Rows.Count == 0) return null;
            return tb.Rows[0];
        }

        /// <summary>
        ///     Returns a random row from a table with a where clause
        /// </summary>
        /// <param name="table">name of SQL table</param>
        /// <param name="column">column to compare</param>
        /// <param name="value">value that is required for the row</param>
        /// <returns>DataRow containing the results</returns>
        public static DataRow RandomWhere(string table, string column, int value)
        {
            var helper = new DbHelper(Constants.Provider, Constants.Path);

            if (!helper.OpenConnection()) throw new ConnectionException();
            var sql = $"SELECT top 1 * from {table} WHERE {column} = {value} ORDER BY rnd({column})";

            var tb = helper.GetDataTable(sql);
            helper.CloseConnection();
            if (tb.Rows.Count == 0) return null;
            return tb.Rows[0];
        }

        /// <summary>
        ///     Returns a random row from a table with a where clause
        /// </summary>
        /// <param name="table">name of SQL table</param>
        /// <param name="column">column to compare</param>
        /// <param name="value">value that is required for the row</param>
        /// <returns>DataRow containing the results</returns>
        public static DataRow RandomWhere(string table, string column, string value)
        {
            var helper = new DbHelper(Constants.Provider, Constants.Path);

            if (!helper.OpenConnection()) throw new ConnectionException();
            var sql = $"SELECT top 1 * from {table} WHERE {column} = '{value}' ORDER BY rnd({column})";

            var tb = helper.GetDataTable(sql);
            helper.CloseConnection();
            if (tb.Rows.Count == 0) return null;
            return tb.Rows[0];
        }


        /// <summary>
        ///     Returns row from a table with a where clause
        /// </summary>
        /// <param name="table">name of SQL table</param>
        /// <param name="column">column to compare</param>
        /// <param name="value">value that is required for the rows</param>
        /// <returns>DataRow containing the matching row</returns>
        public static DataRow RowWhere(string table, string column, string value)
        {
            var helper = new DbHelper(Constants.Provider, Constants.Path);

            if (!helper.OpenConnection()) throw new ConnectionException();
            var sql = $"SELECT * FROM {table} WHERE `{column}` = '{value}'";

            var tb = helper.GetDataTable(sql);
            if (tb.Rows.Count == 0) return null;
            helper.CloseConnection();
            return tb.Rows[0];
        }

        /// <summary>
        ///     Returns row from a table with a where clause
        /// </summary>
        /// <param name="table">name of SQL table</param>
        /// <param name="column">column to compare</param>
        /// <param name="value">value that is required for the rows</param>
        /// <returns>DataRow containing the matching row</returns>
        public static DataRow RowWhere(string table, string column, int value)
        {
            var helper = new DbHelper(Constants.Provider, Constants.Path);

            if (!helper.OpenConnection()) throw new ConnectionException();
            var sql = $"SELECT * FROM {table} WHERE `{column}` = {value}";

            var tb = helper.GetDataTable(sql);
            if (tb.Rows.Count == 0) return null;
            helper.CloseConnection();
            return tb.Rows[0];
        }

        /// <summary>
        ///     Returns a table of al rows from a table with a where clause
        /// </summary>
        /// <param name="table">name of SQL table</param>
        /// <param name="column">column to compare</param>
        /// <param name="value">value that is required for the rows</param>
        /// <returns>DataTable containing the matching rows</returns>
        public static DataTable AllWhere(string table, string column, int value)
        {
            var helper = new DbHelper(Constants.Provider, Constants.Path);

            if (!helper.OpenConnection()) throw new ConnectionException();
            var sql = $"SELECT * FROM {table} WHERE `{column}` = {value}";

            var tb = helper.GetDataTable(sql);
            helper.CloseConnection();
            return tb;
        }

        /// <summary>
        ///     Returns a table of al rows from a table with a where clause
        /// </summary>
        /// <param name="table">name of SQL table</param>
        /// <param name="column">column to compare</param>
        /// <param name="value">value that is required for the rows</param>
        /// <returns>DataTable containing the matching rows</returns>
        public static DataTable AllWhere(string table, string column, string value)
        {
            var helper = new DbHelper(Constants.Provider, Constants.Path);

            if (!helper.OpenConnection()) throw new ConnectionException();
            var sql = $"SELECT * FROM {table} WHERE `{column}` = '{value}'";

            var tb = helper.GetDataTable(sql);
            helper.CloseConnection();
            return tb;
        }

        /// <summary>
        ///     returns all rows from a table
        /// </summary>
        /// <param name="table">name of SQL table</param>
        /// <returns>DataTable containing all rows of a table</returns>
        public static DataTable AllFromTable(string table)
        {
            var helper = new DbHelper(Constants.Provider, Constants.Path);

            if (!helper.OpenConnection()) throw new ConnectionException();
            var sql = $"SELECT * FROM {table}";

            var tb = helper.GetDataTable(sql);
            helper.CloseConnection();
            return tb;
        }
    }
}