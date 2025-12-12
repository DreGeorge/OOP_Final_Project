using SpaceInvaders.Data;
using SpaceInvaders.Models;
using System.Data;

namespace SpaceInvaders.Repositories
{
    public class StatisticsRepository
    {
        public UserStatistics GetByUserName(string userName)
        {
            string q = "SELECT * FROM user_statistics WHERE UserName=@UserName;";
            DataTable dt = DbHelper.ExecuteQuery(q, cmd =>
            {
                cmd.Parameters.AddWithValue("@UserName", userName);
            });

            if (dt.Rows.Count == 0) return null;

            var row = dt.Rows[0];
            return new UserStatistics
            {
                Id = (int)row["id"],
                UserName = row["UserName"].ToString(),
                Rps_Score = (int)row["rps_score"],
                Tictactoe_Score = (int)row["tictactoe_score"],
                Snake_Score = (int)row["snake_score"],
                Total_Xp = (int)row["total_xp"]
            };
        }

        public int UpdateScores(UserStatistics stats)
        {
            string q = @"UPDATE user_statistics
                         SET rps_score=@Rps,
                             tictactoe_score=@Tic,
                             snake_score=@Snake,
                             total_xp=@Xp
                         WHERE UserName=@UserName;";

            return DbHelper.ExecuteNonQuery(q, cmd =>
            {
                cmd.Parameters.AddWithValue("@Rps", stats.Rps_Score);
                cmd.Parameters.AddWithValue("@Tic", stats.Tictactoe_Score);
                cmd.Parameters.AddWithValue("@Snake", stats.Snake_Score);
                cmd.Parameters.AddWithValue("@Xp", stats.Total_Xp);
                cmd.Parameters.AddWithValue("@UserName", stats.UserName);
            });
        }
    }
}
