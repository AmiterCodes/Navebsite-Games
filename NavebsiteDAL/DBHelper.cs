using System;
using System.Data;
using System.Data.OleDb;

namespace NavebsiteDAL
{
    /// <summary>
    ///     DB Helper, methods to do operations on a database
    /// </summary>
    public class DbHelper
    {
        public const int WriteDataError = -1;
        private readonly string _provider;
        private readonly string _source;

        private OleDbConnection _conn;
        private bool _connOpen;

        /// <summary>
        ///     constructor of the DBHelper class, which is used to
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="source"></param>
        public DbHelper(string provider, string source)
        {
            _provider = provider;
            _source = source;
        }

        /// <summary>
        ///     Builds a connection string using provider and data source
        /// </summary>
        /// <returns>connection string</returns>
        public string BuildConnString()
        {
            return $@"Provider={_provider};Data Source={_source};";
        }

        /// <summary>
        ///     Closes the current connection, if open.
        /// </summary>
        public void CloseConnection()
        {
            if (_conn == null) return;
            _conn.Close();
            _connOpen = false;
        }

        /// <summary>
        ///     Gets a DataTable from a SELECT query
        /// </summary>
        /// <param name="sql">SQL SELECT Query</param>
        /// <returns>the data table, or null if it failed</returns>
        public DataTable GetDataTable(string sql)
        {
            var reader = ReadData(sql);
            DataTable output = null;

            if (reader != null)
            {
                output = new DataTable();
                output.Load(reader);
            }

            return output;
        }

        /// <summary>
        ///     runs an INSERT query for a single element
        /// </summary>
        /// <param name="sql">SQL INSERT query</param>
        /// <returns>ID of element</returns>
        public int InsertWithAutoNumKey(string sql)
        {
            try
            {
                var cmd = new OleDbCommand(sql, _conn);

                var reader = cmd.ExecuteReader();

                if (reader != null && reader.RecordsAffected == 1)
                {
                    cmd = new OleDbCommand(@"SELECT @@Identity", _conn);
                    reader = cmd.ExecuteReader();
                    var newId = WriteDataError;
                    while (reader.Read())
                        //The new ID will be on the first (and only) column
                        newId = (int) reader[0];
                    return newId;
                }

                return WriteDataError;
            }
            catch
            {
                return WriteDataError;
            }
        }


        /// <summary>
        ///     runs a INSERT, UPDATE or DELETE query on the database
        /// </summary>
        /// <param name="sql">SQL Query</param>
        /// <returns>the numbers of rows affected</returns>
        public int WriteData(string sql)
        {
            try
            {
                if (!_connOpen) return WriteDataError;
                var cmd = new OleDbCommand(sql, _conn);

                var reader = cmd.ExecuteReader();

                return reader.RecordsAffected;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return WriteDataError;
            }
        }


        /// <summary>
        ///     Reads data from an SQL "SELECT" query
        /// </summary>
        /// <param name="sql">SQL query to process</param>
        /// <returns>The DataReader, if fails returns null</returns>
        public OleDbDataReader ReadData(string sql)
        {
            var cmd = new OleDbCommand(sql, _conn);
            // since execute reader returns null on failure, that's all we have to do.
            return cmd.ExecuteReader();
        }


        /// <summary>
        ///     opens a connection
        /// </summary>
        /// <returns>if the connection went successful</returns>
        public bool OpenConnection()
        {
            if (_conn == null) _conn = new OleDbConnection(BuildConnString());
            try
            {
                _conn.Open();
                _connOpen = true;
            }
            catch (Exception) // basically, if the connection throws some kind of exception.
            {
                return false;
            }

            // if it didn't return false, it probably went successful, do a true.
            return true;
        }


        /// <summary>
        ///     returns a DataSet from a list of SQL SELECT queries
        ///     Tables are sql1, sql2 and so on...
        /// </summary>
        /// <param name="sql">SQL SELECT queries</param>
        /// <returns>Dataset of queries</returns>
        public DataSet GetDataSet(string[] sql)
        {
            try
            {
                var set = new DataSet();
                var i = 1;
                foreach (var s in sql)
                {
                    var adapter = new OleDbDataAdapter(s, _conn);
                    adapter.Fill(set, $"sql{i}");

                    // to release resources.
                    adapter.Dispose();
                    i++;
                }

                return set;
            }
            catch
            {
                return null;
            }
        }
    }
}