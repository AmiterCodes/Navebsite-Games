﻿using NavebsiteDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavebsiteBL
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Description { get; set; }
        public double Balance { get; set; }
        public DateTime JoinDate { get; set; }
        public string ProfilePicture { get; set; }
        public string Background { get; set; }

        public List<Activity> Activities { get => Activity.UserActivities(Id); }
        public string ProfilePictureUrl { get => "./Images/UserProfiles/" + ProfilePicture; }
        public string BackgroundUrl { get => "./Images/UserBackgrounds/" + Background; }

        public User(int id)
        {
            Id = id;
            DataRow dr= DBUser.GetUserById(id);
            if (dr == null) throw new InvalidOperationException();

            Username = (string)dr["Username"];
            Description = (string)dr["Description"];
            Balance = (double)dr["Balance"];
            JoinDate = (DateTime)dr["Join Date"];
            ProfilePicture = (string)dr["Profile Picture"];
            Background = (string)dr["Background"];
        }

        public User(DataRow dr)
        {
            if (dr == null) throw new InvalidOperationException();
            Id = (int)dr["ID"];
            Username = (string)dr["Username"];
            Description = (string)dr["Description"];
            Balance = (double)dr["Balance"];
            JoinDate = (DateTime)dr["JoinDate"];
            ProfilePicture = (string)dr["Profile Picture"];
            Background = (string)dr["Background"];
        }
    }
}