using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavebsiteDAL
{
    public enum PhotoType
    {
        GamePhotos,
        UserPhotos
    }
    public class DBPhotos
    {
        public static DataRow GetPhoto(int id, PhotoType type)
        {
            return DALHelper.GetRowById(id, type.ToString());
        }

        public static DataTable GetPhotosOfGame(int game)
        {
            return DALHelper.AllWhere("GamePhotos", "Game", game);
        }

        public static DataTable GetPhotosOfUser(int user)
        {
            return DALHelper.AllWhere("UserPhotos", "User", user);
        }


        public static DataRow RandomPhotoOfGame(int game)
        {
            return DALHelper.RandomWhere("GamePhotos", "Game", game);
        }

        public static DataTable GetPhotosFromDeveloper(int developer)
        {
            return DALHelper.Select($"SELECT GamePhotos.* FROM GamePhotos INNER JOIN Games ON GamePhotos.Game = Games.Id WHERE Games.Developer = {developer};");

        }

        public static DataTable AllPhotos(PhotoType type)
        {
            return DALHelper.AllFromTable(type.ToString());
        }
    }
}
