using System;
using System.Collections.Generic;
using System.Data;
using NavebsiteDAL;

namespace NavebsiteBL
{
    public class GamePhoto : Photo
    {
        public GamePhoto(int id)
        {
            Id = id;
            var dr = DbPhotos.GetPhoto(id, PhotoType.GamePhotos);
            if (dr == null) throw new ArgumentException("no photo with that id");

            GameId = (int) dr["Game"];
            Image = (string) dr["Photo"];
        }

        public GamePhoto(DataRow dr) : base(dr)
        {
            GameId = (int) dr["Game"];
        }

        public int GameId { get; set; }

        public static int InsertPhoto(int game, string filename)
        {
            return DbPhotos.InsertPhoto(game, filename, PhotoType.GamePhotos);
        }

        public static GamePhoto RandomPhoto(int game)
        {
            return new GamePhoto(DbPhotos.RandomPhotoOfGame(game));
        }

        public static List<GamePhoto> PhotosByGame(int game)
        {
            var list = new List<GamePhoto>();
            foreach (DataRow row in DbPhotos.GetPhotosOfGame(game).Rows) list.Add(new GamePhoto(row));

            return list;
        }

        public static List<GamePhoto> PhotosByDeveloper(int developer)
        {
            var list = new List<GamePhoto>();
            foreach (DataRow row in DbPhotos.GetPhotosFromDeveloper(developer).Rows) list.Add(new GamePhoto(row));

            return list;
        }
    }
}