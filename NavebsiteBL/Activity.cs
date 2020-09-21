using NavebsiteDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavebsiteBL
{
    public class Activity
    {
        public int Id { get; set; }
        public string ActivityText { get; set; }
        public DateTime Timestamp { get; set; }
        public int UserId { get; set; }

        public static List<Activity> UserActivities(int user)
        {
            var list = new List<Activity>();
            var tb = DbActivity.UserActivity(user);
            foreach(DataRow row in tb.Rows)
            {
                list.Add(new Activity(row));
            }
            return list;

        }

        public static void AddActivity(string text, int userId)
        {
            DbActivity.InsertActivity(text, userId);
        }

        public Activity(DataRow dr)
        {
            Id = (int)dr["ID"];
            ActivityText = (string)dr["ActivityText"];
            Timestamp = (DateTime)dr["Timestamp"];
            UserId = (int)dr["User"];
        }

        public Activity(int id)
        {
            var dr = DbActivity.GetActivity(id);
            ActivityText = (string)dr["ActivityText"];
            Timestamp = (DateTime)dr["Timestamp"];
            UserId = (int)dr["User"];
        }
    }
}
