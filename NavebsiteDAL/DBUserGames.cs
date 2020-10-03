using System.Data;

namespace NavebsiteDAL
{
    public class DbUserGames
    {
        public static bool GameOwnedByUser(int gameId, int userId)
        {
            return DalHelper.RowExists($"SELECT Game FROM UserGames WHERE Game = {gameId} AND [User] = {userId}");
        }

        public static DataTable GetUserGames(int userId)
        {
            return DalHelper.Select(
                $"SELECT * FROM Games INNER JOIN UserGames ON Games.ID = UserGames.Game WHERE User = {userId}");
        }

        public static DataTable AllUserGames()
        {
            return DalHelper.AllFromTable("UserGames");
        }

        public static void AddGame(int user, int game, double price)
        {
            DalHelper.Insert($"INSERT INTO UserGames (User, Game,Cost) VALUES ({user},{game},{price})");
        }
    }
}