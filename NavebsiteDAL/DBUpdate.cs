using System.Data;
using System.Data.OleDb;

namespace NavebsiteDAL
{
    public class DbUpdate
    {
        /// <summary>
        /// Inserts a new game update to the database
        /// </summary>
        /// <param name="version">version name, e.g 1.12.4 or 19w34</param>
        /// <param name="updateName">name of update e.g "The End Update"</param>
        /// <param name="description">description of update, written in markdown</param>
        /// <param name="game">id of game</param>
        /// <returns>id of update</returns>
        public static int InsertUpdate(string version, string updateName, string description, int game)
        {
            return DalHelper.Insert(
                $"INSERT INTO GameUpdates ([Update Version],[Update Name], [Update Description], [Game]) VALUES (@version,@updateName,@description,{game})",
                new OleDbParameter("@version", version),
                new OleDbParameter("@description", description),
                new OleDbParameter("@updateName", updateName));
        }

        /// <summary>
        /// returns a list of all updates of a game
        /// </summary>
        /// <param name="game">game to retrieve updates of</param>
        /// <returns>DataTable of updates</returns>
        public static DataTable ListUpdates(int game)
        {
            return DalHelper.AllWhere("GameUpdates", "Game", game);
        }
    }
}