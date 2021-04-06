using System;
using System.Collections.Generic;
using System.Data;
using NavebsiteDAL;

namespace NavebsiteBL
{
    /// <summary>
    /// Represents an activity of a user
    /// </summary>
    public class Activity
    {
        /// <summary>
        /// creates an activity object from a dataRow, does not do any DAL calls
        /// </summary>
        /// <param name="dr">DataRow of activity</param>
        public Activity(DataRow dr)
        {
            Id = (int) dr["ID"];
            ActivityText = (string) dr["ActivityText"];
            Timestamp = (DateTime) dr["Timestamp"];
            UserId = (int) dr["User"];
        }

        /// <summary>
        /// Creates an activity object from id
        /// </summary>
        /// <param name="id">id of activity</param>
        public Activity(int id)
        {
            var dr = DbActivity.GetActivity(id);
            ActivityText = (string) dr["ActivityText"];
            Timestamp = (DateTime) dr["Timestamp"];
            UserId = (int) dr["User"];
        }


        public int Id { get; set; }
        public string ActivityText { get; set; }
        public DateTime Timestamp { get; set; }
        public int UserId { get; set; }

        /// <summary>
        /// returns all activities for user
        /// </summary>
        /// <param name="user">id of user</param>
        /// <returns></returns>
        public static List<Activity> UserActivities(int user)
        {
            var list = new List<Activity>();
            var tb = DbActivity.UserActivity(user);
            foreach (DataRow row in tb.Rows) list.Add(new Activity(row));
            return list;
        }

        /// <summary>
        /// adds a new activity to the database
        /// </summary>
        /// <param name="text">activity text</param>
        /// <param name="userId">id of user</param>
        public static void AddActivity(string text, int userId)
        {
            DbActivity.InsertActivity(text, userId);
        }
    }
}