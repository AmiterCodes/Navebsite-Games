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
