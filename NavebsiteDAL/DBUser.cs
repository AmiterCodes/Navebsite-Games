using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavebsiteDAL
{
    public class DBUser
    {
        public static DataTable AllUsers()
        {
            return DALHelper.AllFromTable("Users");
        }

        public static DataRow GetUserById(int user)
        {
            return DALHelper.GetRowById(user, "Users");
        }

        public static DataRow GetUserByName(string username)
        {
            return DALHelper.RowWhere("Users", "Username", username);
        }

        public static bool Authenticate(string username, string password)
        {
            DataTable tb = DALHelper.Select("SELECT HashPass FROM Users WHERE username = '" + username + "'");

            if (tb.Rows.Count == 0) return false;

            DataRow row = tb.Rows[0];
            string hash =(string) row["HashPass"];

            return BCrypt.Net.BCrypt.EnhancedVerify(password, hash);
        }

        public static int InsertUser(string username, string password)
        {
            return DALHelper.Insert(
"INSERT INTO Users" +
"(Username,HashPass)"+
$"VALUES('{username}', '{BCrypt.Net.BCrypt.EnhancedHashPassword(password)}')");
        }
    }
}
