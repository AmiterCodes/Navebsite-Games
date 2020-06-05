using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using System.Configuration;
//using System.Linq;
using System.Xml.Linq;
using System.Data.OleDb;
using System.Threading.Tasks;
using System.Net.Http;

namespace NavebsiteDAL
{
    /// <summary>
    /// DB Helper, methods to do operations on a database
    /// </summary>
    public class DBHelper
    {

        public const int WRITEDATA_ERROR = -1;

        private OleDbConnection conn;
        private string provider;
        private string source;
        private bool connOpen;

        /// <summary>
        /// constructor of the DBHelper class, which is used to 
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="source"></param>

        public DBHelper(string provider, string source)
        {
            this.provider = provider;
            this.source = source;


        }

        /// <summary>
        /// Builds a connection string using provider and data source
        /// </summary>
        /// <returns>connection string</returns>
        public string BuildConnString()
        {
            return String.Format(@"Provider={0};Data Source={1};", provider, source);

        }

        /// <summary>
        /// Closes the current connection, if open.
        /// </summary>
        public void CloseConnection()
        {
            if (conn == null) return;
            conn.Close();
            connOpen = false;
        }

        /// <summary>
        /// Gets a DataTable from a SELECT query
        /// </summary>
        /// <param name="sql">SQL SELECT Query</param>
        /// <returns>the data table, or null if it failed</returns>
        public DataTable GetDataTable(string sql)
        {
            OleDbDataReader reader = ReadData(sql);
            DataTable output = null;

            if (reader != null)
            {
                output = new DataTable();
                output.Load(reader);
            }
            return output;
        }

        /// <summary>
        /// runs an INSERT query for a single element
        /// </summary>
        /// <param name="sql">SQL INSERT query</param>
        /// <returns>ID of element</returns>
        public int InsertWithAutoNumKey(string sql)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand(sql, conn);

                OleDbDataReader reader = cmd.ExecuteReader();

                if (reader != null && reader.RecordsAffected == 1)
                {
                    cmd = new OleDbCommand(@"SELECT @@Identity", conn);
                    reader = cmd.ExecuteReader();
                    int newID = WRITEDATA_ERROR;
                    while (reader.Read())
                    {
                        //The new ID will be on the first (and only) column
                        newID = (int)reader[0];
                    }
                    return newID;
                }
                else return WRITEDATA_ERROR;
            }
            catch
            {
                return WRITEDATA_ERROR;
            }
        }


        /// <summary>
        /// runs a INSERT, UPDATE or DELETE query on the database
        /// </summary>
        /// <param name="sql">SQL Query</param>
        /// <returns>the numbers of rows affected</returns>
        public int WriteData(string sql)
        {
            try
            {
                if (!connOpen) return WRITEDATA_ERROR;
                OleDbCommand cmd = new OleDbCommand(sql, conn);

                OleDbDataReader reader = cmd.ExecuteReader();
                
                return reader.RecordsAffected;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return WRITEDATA_ERROR;
            }
        }


        /// <summary>
        /// Reads data from an SQL "SELECT" query
        /// </summary>
        /// <param name="sql">SQL query to process</param>
        /// <returns>The DataReader, if fails returns null</returns>
        public OleDbDataReader ReadData(string sql)
        {

            
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            // since execute reader returns null on failure, that's all we have to do.
            return cmd.ExecuteReader();
        }



        /// <summary>
        /// opens a connection
        /// </summary>
        /// <returns>if the connection went successful</returns>
        public bool OpenConnection()
        {
            if (conn == null) conn = new OleDbConnection(BuildConnString());
            try
            {
                conn.Open();
                connOpen = true;

            }
            catch(Exception e) // basically, if the connection throws some kind of exception.
            {
                return false;
            }
            // if it didn't return false, it probably went successful, do a true.
            return true;
        }


        /// <summary>
        /// returns a DataSet from a list of SQL SELECT queries 
        /// Tables are sql1, sql2 and so on...
        /// </summary>
        /// <param name="sql">SQL SELECT queries</param>
        /// <returns>Dataset of queries</returns>
        public DataSet GetDataSet(string[] sql)
        {
            try
            {
                DataSet set = new DataSet();
                int i = 1;
                foreach (string s in sql)
                {
                    OleDbDataAdapter adapter = new OleDbDataAdapter(s, conn);
                    adapter.Fill(set, $"sql{i}");

                    // to release resources.
                    adapter.Dispose();
                    i++;
                }

                return set;
            } catch
            {
                return null;
            }
        }


    }
}


