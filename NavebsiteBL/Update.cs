﻿using NavebsiteDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavebsiteBL
{
    public class Update
    {
        public int Id { get; }
        public string UpdateVersion { get; }
        public string UpdateName { get; }
        public string UpdateDescription { get; }
        public int GameId { get; }

        public Game Game { get => new Game(GameId); }

        public Update(DataRow dr)
        {
            Id = (int) dr["ID"];
            UpdateVersion = (string)dr["Update Version"];
            UpdateName = (string)dr["Update Name"];
            UpdateDescription= (string)dr["Update Description"];
            GameId = (int)dr["Game"];
        }

        public List<Update> ListUpdates(int game)
        {
            return (from DataRow dr in DBUpdate.ListUpdates(game).Rows select new Update(dr)).ToList();
        }

    }
}
