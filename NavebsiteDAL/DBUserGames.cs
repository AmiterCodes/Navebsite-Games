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
    }
}