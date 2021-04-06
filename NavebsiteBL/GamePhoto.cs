using System;
using System.Collections.Generic;
using System.Data;
using NavebsiteDAL;

namespace NavebsiteBL
{
    /// <summary>
    /// represents a photo from a game
    /// </summary>
    public class GamePhoto : Photo
    {

        public int GameId { get; set; }

        /// <summary>
        /// gamePhoto from id
        /// </summary>
        /// <param name="id">id of gamePhoto</param>
        public GamePhoto(int id)
        {
            Id = id;
            var dr = DbPhotos.GetPhoto(id, PhotoType.GamePhotos);
            if (dr == null) throw new ArgumentException("no photo with that id");

            GameId = (int) dr["Game"];
            Image = (string) dr["Photo"];
        }

        /// <summary>
        /// constructor by dataRow
        /// </summary>
        /// <param name="dr">datarow to construct by</param>
        public GamePhoto(DataRow dr) : base(dr)
        {
            GameId = (int) dr["Game"];
        }


        /// <summary>
        /// inserts photo into the database
        /// </summary>
        /// <param name="game">id of game</param>
        /// <param name="filename">image filename</param>
        /// <returns>id of photo</returns>
        public static int InsertPhoto(int game, string filename)
        {
            return DbPhotos.InsertPhoto(game, filename, PhotoType.GamePhotos);
        }

        /// <summary>
        /// gets random photo of game
        /// </summary>
        /// <param name="game">id of game</param>
        /// <returns>GamePhoto of photo</returns>
        public static GamePhoto RandomPhoto(int game)
        {
            return new GamePhoto(DbPhotos.RandomPhotoOfGame(game));
        }
        /// <summary>
        /// gets photos by game
        /// </summary>
        /// <param name="game">id of game</param>
        /// <returns>list of game photos</returns>
        public static List<GamePhoto> PhotosByGame(int game)
        {
            var list = new List<GamePhoto>();
            foreach (DataRow row in DbPhotos.GetPhotosOfGame(game).Rows) list.Add(new GamePhoto(row));

            return list;
        }

        /// <summary>
        /// gets photos by dev
        /// </summary>
        /// <param name="developer">id of developer</param>
        /// <returns>list of photos</returns>
        public static List<GamePhoto> PhotosByDeveloper(int developer)
        {
            var list = new List<GamePhoto>();
            foreach (DataRow row in DbPhotos.GetPhotosFromDeveloper(developer).Rows) list.Add(new GamePhoto(row));

            return list;
        }
    }
}