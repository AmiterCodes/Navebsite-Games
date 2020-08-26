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

        public static DataTable Select(string sql)
        {
            DBHelper helper = new DBHelper(Constants.PROVIDER, Constants.PATH);

            if (!helper.OpenConnection()) throw new ConnectionException();

            DataTable tb = helper.GetDataTable(sql);
            helper.CloseConnection();
            
            return tb;
        }

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

        //SELECT top 1 ID from GamePhotos WHERE Game = 1 ORDER BY rnd(ID)
        

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

        public static DataTable AllWhere(string table, string column, int value)
        {
            DBHelper helper = new DBHelper(Constants.PROVIDER, Constants.PATH);

            if (!helper.OpenConnection()) throw new ConnectionException();
            string sql = $"SELECT * FROM {table} WHERE `{column}` = {value}";

            DataTable tb = helper.GetDataTable(sql);
            helper.CloseConnection();
            return tb;
        }

        public static DataTable AllWhere(string table, string column, string value)
        {
            DBHelper helper = new DBHelper(Constants.PROVIDER, Constants.PATH);

            if (!helper.OpenConnection()) throw new ConnectionException();
            string sql = $"SELECT * FROM {table} WHERE `{column}` = '{value}'";

            DataTable tb = helper.GetDataTable(sql);
            helper.CloseConnection();
            return tb;
        }

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
