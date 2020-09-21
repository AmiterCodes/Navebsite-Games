using NavebsiteDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavebsiteBL
{
    public class GamePhoto : Photo
    {
        
        public int GameId { get; set; }
        


        public GamePhoto(int id) : base()
        {
            Id = id;
            var dr = DBPhotos.GetPhoto(id, PhotoType.GamePhotos);
            if (dr == null) throw new ArgumentException("no photo with that id");

            GameId = (int) dr["Game"];
            Image  = (string) dr["Photo"];

        }

        public GamePhoto(DataRow dr) : base(dr)
        {

            GameId = (int)dr["Game"];
        }

        public static GamePhoto RandomPhoto(int game)
        {
            return new GamePhoto(DBPhotos.RandomPhotoOfGame(game));
        }

        public static List<GamePhoto> PhotosByGame(int game)
        {
            var list = new List<GamePhoto>();
            foreach(DataRow row in DBPhotos.GetPhotosOfGame(game).Rows)
            {
                list.Add(new GamePhoto(row));
            }

            return list;
        }
        public static List<GamePhoto> PhotosByDeveloper(int developer)
        {
            var list = new List<GamePhoto>();
            foreach (DataRow row in DBPhotos.GetPhotosFromDeveloper(developer).Rows)
            {
                list.Add(new GamePhoto(row));
            }

            return list;
        }

    }
}
