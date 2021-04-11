using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NavebsiteDAL;

namespace NavebsiteBL
{

    /// <summary>
    /// represents a genre of a game
    /// </summary>
    [Serializable]
    public class Genre
    {

        public int Id { get; set; }
        public string GenreName { get; set; }


        /// <summary>
        /// inserts a genre into the database
        /// </summary>
        /// <param name="genreName">name of genres</param>
        public Genre(string genreName)
        {
            GenreName = genreName;
            Id = DbGenre.InsertGenre(GenreName);
        }

        /// <summary>
        /// creates a genre object from id and name
        /// </summary>
        /// <param name="id">id of genre</param>
        /// <param name="genreName">name of genre</param>
        public Genre(int id, string genreName)
        {
            Id = id;
            GenreName = genreName;
        }

        /// <summary>
        /// clears all genres from game
        /// </summary>
        /// <param name="game">id of game</param>
        public static void ClearGenres(int game)
        {
            DbGenre.DeleteGenresForGame(game);
        }
        /// <summary>
        /// creates genre from DataRow
        /// </summary>
        /// <param name="row">DataRow of genre</param>
        public Genre(DataRow row)
        {
            if (row == null) throw new InvalidOperationException();

            Id = (int) row["ID"];
            GenreName = (string) row["Genre Name"];
        }

        /// <summary>
        /// gets genre by id
        /// </summary>
        /// <param name="id">id of genre</param>
        public Genre(int id) : this(DbGenre.GetGenre(id))
        {
        }

        /// <summary>
        /// inserts a game genre connection
        /// </summary>
        /// <param name="genre">genre object</param>
        /// <param name="gameId">id of game</param>
        /// <returns></returns>
        public static int InsertGameGenre(Genre genre, int gameId)
        {
            return DbGenre.InsertGameGenre(genre.Id, gameId);
        }

        /// <summary>
        /// gets a list of all genres
        /// </summary>
        /// <returns>list of all genres</returns>
        public static List<Genre> AllGenres()
        {
            return (from DataRow row in DbGenre.AllGenres().Rows select new Genre(row)).ToList();
        }
    }
}