namespace SpaceInvaders.Models
{
    public class UserStatistics
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Rps_Score { get; set; }
        public int Tictactoe_Score { get; set; }
        public int Snake_Score { get; set; }
        public int Total_Xp { get; set; }
    }
}
