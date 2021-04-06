using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NavebsiteDAL;

namespace NavebsiteBL
{
    /// <summary>
    /// represents a code for a game
    /// </summary>
    public class GameCode
    {
        public int Id { get; }
        public string Code { get; }
        public int GameId { get; }
        public Game Game => new Game(GameId);
        public bool Used{ get; }
        public int RedeemedById { get; }
        public User Redeemer => RedeemedById == -1 ? null : new User(RedeemedById);

        /// <summary>
        /// Redeems a code for a user and gives him the game
        /// </summary>
        /// <param name="user">id of user</param>
        /// <param name="code">code string</param>
        /// <returns>-1 if code was already redeemed or invalid else the id of the game that user bought</returns>
        public static int RedeemCode(int user, string code)
        {
            if (!DbGameCodes.CodeUnredeemed(code)) return -1;
            if (!DbGameCodes.UseGameCode(code, user)) return -1;

            int game = DbGameCodes.GetGameFromCode(code);

            UserGame.AddGame(user, game, 0);

            return game;
        }


        

        /// <summary>
        /// Generates a random unused game code for a specific game
        /// </summary>
        /// <param name="game">id of game</param>
        /// <returns>the game code for the game</returns>
        public static GameCode GenerateCode(int game)
        {
            string code = RandomCodeString(16);

            return new GameCode(code, game);
        }



        private static readonly Random Random = new Random();

        private static string RandomCodeString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }
        private GameCode(DataRow row)
        {
            Id = (int)row["ID"];
            Code = (string)row["Code"];
            GameId = (int)row["Game"];
            Used = (bool)row["Used"];
            RedeemedById = (int)row["Redeemed By"];
        }
        private GameCode(string code, int game)
        {
            Id = DbGameCodes.InsertCode(code, game);

            Code = code;
            GameId = game;

            Used = false;
            RedeemedById = -1;
        }
    }
}
