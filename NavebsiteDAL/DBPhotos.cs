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
    public class DbPhotos
    {
        public static DataRow GetPhoto(int id, PhotoType type)
        {
            return DalHelper.GetRowById(id, type.ToString());
        }

        public static DataTable GetPhotosOfGame(int game)
        {
            return DalHelper.AllWhere("GamePhotos", "Game", game);
        }

        public static DataTable GetPhotosOfUser(int user)
        {
            return DalHelper.AllWhere("UserPhotos", "User", user);
        }


        public static DataRow RandomPhotoOfGame(int game)
        {
            return DalHelper.RandomWhere("GamePhotos", "Game", game);
        }

        public static DataTable GetPhotosFromDeveloper(int developer)
        {
            return DalHelper.Select($"SELECT GamePhotos.* FROM GamePhotos INNER JOIN Games ON GamePhotos.Game = Games.Id WHERE Games.Developer = {developer};");

        }

        public static DataTable AllPhotos(PhotoType type)
        {
            return DalHelper.AllFromTable(type.ToString());
        }
    }
}
