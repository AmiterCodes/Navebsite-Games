using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NavebsiteDAL;

namespace NavebsiteBL
{
    /// <summary>
    /// represents a game update
    /// </summary>
    public class Update
    {
        /// <summary>
        /// creates an update object from dataRow
        /// </summary>
        /// <param name="dr">dataRow of update</param>
        public Update(DataRow dr)
        {
            Id = (int) dr["ID"];
            UpdateVersion = (string) dr["Update Version"];
            UpdateName = (string) dr["Update Name"];
            UpdateDescription = (string) dr["Update Description"];
            GameId = (int) dr["Game"];
            Timestamp = (DateTime) dr["Timestamp"];
        }

        /// <summary>
        /// inserts update into the database
        /// </summary>
        /// <param name="updateVersion">version of update</param>
        /// <param name="updateName">name of update</param>
        /// <param name="updateDescription">description of update</param>
        /// <param name="gameId">id of game</param>
        public Update(string updateVersion, string updateName, string updateDescription, int gameId)
        {
            UpdateVersion = updateVersion;
            UpdateName = updateName;
            UpdateDescription = updateDescription;
            GameId = gameId;
            Id = DbUpdate.InsertUpdate(updateVersion, updateName, updateDescription, gameId);
        }


        public int Id { get; }
        public string UpdateVersion { get; }
        public string UpdateName { get; }
        public DateTime Timestamp { get; }
        public string UpdateDescription { get; }
        public int GameId { get; }

        public Game Game => new Game(GameId);

        /// <summary>
        /// lists all updates for a certain game
        /// </summary>
        /// <param name="game">id of game</param>
        /// <returns>list of update</returns>
        public static List<Update> ListUpdates(int game)
        {
            return (from DataRow dr in DbUpdate.ListUpdates(game).Rows select new Update(dr)).ToList();
        }
    }
}