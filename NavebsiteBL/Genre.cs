using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NavebsiteDAL;

namespace NavebsiteBL
{
    [Serializable]
    public class Genre
    {
        public Genre(string genreName)
        {
            GenreName = genreName;
            Id = DbGenre.InsertGenre(GenreName);
        }

        public Genre(int id, string genreName)
        {
            Id = id;
            GenreName = genreName;
        }

        public static void ClearGenres(int game)
        {
            DbGenre.DeleteGenresForGame(game);
        }

        public Genre(DataRow row)
        {
            if (row == null) throw new InvalidOperationException();

            Id = (int) row["ID"];
            GenreName = (string) row["Genre Name"];
        }

        public Genre(int id) : this(DbGenre.GetGenre(id))
        {
        }

        public int Id { get; set; }
        public string GenreName { get; set; }

        public static int InsertGameGenre(Genre genre, int gameId)
        {
            return DbGenre.InsertGameGenre(genre.Id, gameId);
        }

        public static List<Genre> AllGenres()
        {
            return (from DataRow row in DbGenre.AllGenres().Rows select new Genre(row)).ToList();
        }
    }
}