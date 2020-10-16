using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavebsiteDAL
{
    public class DbGameCodes
    {
        /// <summary>
        /// returns a table of all codes for a game
        /// </summary>
        /// <param name="game">id of game</param>
        /// <returns>table of all codes</returns>
        public static DataTable GameCodesForGame(int game)
        {
            return DalHelper.AllWhere("GameCodes", "Game", game);
        }


        /// <summary>
        /// Checks that a game code hasn't been used yet
        /// </summary>
        /// <param name="code">16 char string of game code</param>
        /// <returns>true if code hasn't been used, else false</returns>
        public static bool CodeUnredeemed(string code)
        {
            return DalHelper.RowExists($"SELECT Code FROM GameCodes WHERE Code = '{code}' AND Used = False");
        }

        /// <summary>
        /// changes a game code status to used by certain user
        /// this does not check if the code was previously used, and does not give the user the game
        /// </summary>
        /// <param name="code">16 char string of game code</param>
        /// <param name="user">id of user</param>
        /// <returns>true if rows were updated, meaning a game code was changed and the code worked, else false</returns>
        public static bool UseGameCode(string code, int user)
        {
            return DalHelper.UpdateWhere("GameCodes",
                "Used", true, 
                "Redeemed By", user,
                "Code", code) > 0;
        }

        /// <summary>
        /// Returns a game from a given code
        /// </summary>
        /// <param name="code">16 char string of game code</param>
        /// <returns>id of game if found, else -1</returns>
        public static int GetGameFromCode(string code)
        {
            DataRow row = DalHelper.RowWhere("GameCodes","Code", code, "Game");
            if (row == null) return -1;
            return (int) row["Game"];
        }


        /// <summary>
        /// inserts a game code into the database
        /// </summary>
        /// <param name="code">string of code</param>
        /// <param name="game">id of game</param>
        /// <returns>id of code row</returns>
        public static int InsertCode(string code, int game)
        {
            return DalHelper.Insert($"INSERT INTO GameCodes (Code, Game) VALUES ('{code}', {game})");
        }

    }
}
