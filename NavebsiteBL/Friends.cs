using NavebsiteDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavebsiteBL
{
    public class Friends
    {
        public static List<User> GetFriends(int user)
        {
            List<User> users = new List<User>();
            DataTable tb = DBFriends.GetFriendsOfUser(user);
            foreach(DataRow row in tb.Rows)
            {
                users.Add(new User(row));
            }

            return users;
        }
    }
}
