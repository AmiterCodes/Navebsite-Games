using System.Data;
using System.Data.OleDb;

namespace NavebsiteDAL
{
    public enum PhotoType
    {
        GamePhotos,
        UserPhotos
    }

    public class DbPhotos
    {
        /// <summary>
        /// gets a photo by id and type
        /// </summary>
        /// <param name="id">id of photo</param>
        /// <param name="type">type of photo</param>
        /// <returns>DataRow of photo</returns>
        public static DataRow GetPhoto(int id, PhotoType type)
        {
            return DalHelper.GetRowById(id, type.ToString());
        }

        /// <summary>
        /// gets photos by game
        /// </summary>
        /// <param name="game">id of game</param>
        /// <returns>DataTable of photos</returns>
        public static DataTable GetPhotosOfGame(int game)
        {
            return DalHelper.AllWhere("GamePhotos", "Game", game);
        }

        /// <summary>
        /// gets photos by user
        /// </summary>
        /// <param name="user">id of user</param>
        /// <returns>DataTable of photos</returns>
        public static DataTable GetPhotosOfUser(int user)
        {
            return DalHelper.AllWhere("UserPhotos", "User", user);
        }

        /// <summary>
        /// gets random photo of game
        /// </summary>
        /// <param name="game">id of game</param>
        /// <returns>DataRow of photo</returns>
        public static DataRow RandomPhotoOfGame(int game)
        {
            return DalHelper.RandomWhere("GamePhotos", "Game", game);
        }

        /// <summary>
        /// gets photos by dev
        /// </summary>
        /// <param name="developer">id of developer</param>
        /// <returns>DataTable of photos</returns>
        public static DataTable GetPhotosFromDeveloper(int developer)
        {
            return DalHelper.Select(
                $"SELECT GamePhotos.* FROM GamePhotos INNER JOIN Games ON GamePhotos.Game = Games.Id WHERE Games.Developer = {developer};");
        }

        /// <summary>
        /// gets all photos of type
        /// </summary>
        /// <param name="type">type of photo</param>
        /// <returns>DataTable of photos</returns>
        public static DataTable AllPhotos(PhotoType type)
        {
            return DalHelper.AllFromTable(type.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="filename"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int InsertPhoto(int id, string filename, PhotoType type)
        {
            string field = type == PhotoType.UserPhotos ? "User" : "Game";
            return DalHelper.Insert($"INSERT INTO {type.ToString()} ({field}, Photo) VALUES ({id}, @filename)"
            , new OleDbParameter("@filename", filename));
        }
    }
}