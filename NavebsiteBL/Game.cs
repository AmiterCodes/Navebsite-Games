using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NavebsiteDAL;

namespace NavebsiteBL
{
    public class Game
    {
        public int ID { get; set; }
        public string GameName { get; set; }
        public string GameLink { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public int ReviewStatus { get; set; }
        public string Background { get; set; }
        public string Logo { get; set; }
        public int Developer { get; set; }
        public DateTime PublishDate { get; set; }
        public double Price { get; set; }
        public Game(DataRow row)
        {
            if (row == null) throw new InvalidOperationException();

            this.ID = (int)row["ID"];
            this.GameName = (string)row["Game Name"];
            this.GameLink = (string)row["Game Link"];
            this.Version = (string)row["Version"];
            this.Description = (string)row["Description"];
            this.ReviewStatus = (int)row["Review Status"];
            this.Background = (string)row["Background"];
            this.Logo = (string)row["Logo"];
            this.Developer = (int)row["Developer"];
            this.PublishDate = (DateTime)row["Publish Date"];
            this.Price = (double)row["Price"];
        }

        public Game(int id) : this(DBGame.GetGame(id))
        {
            
        }

        public static List<Game> AllGames()
        {
            List<Game> l = new List<Game>();
            foreach(DataRow r in DBGame.AllGames().Rows)
            {
                l.Add(new Game(r));
            }
            return l;
        }
    }
}
