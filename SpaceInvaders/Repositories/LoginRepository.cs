using SpaceInvaders.Data;

namespace SpaceInvaders.Repositories
{
    public class LoginRepository
    {
        public bool ValidateLogin(string userName, string password)
        {
            string q = @"SELECT COUNT(*) FROM login_info
                         WHERE UserName=@UserName AND Password=@Password;";

            var result = DbHelper.ExecuteScalar(q, cmd =>
            {
                cmd.Parameters.AddWithValue("@UserName", userName);
                cmd.Parameters.AddWithValue("@Password", password);
            });

            return System.Convert.ToInt32(result) > 0;
        }

        public int RegisterLogin(string userName, string password)
        {
            string q = @"INSERT INTO login_info (UserName, Password)
                         VALUES (@UserName, @Password);";

            return DbHelper.ExecuteNonQuery(q, cmd =>
            {
                cmd.Parameters.AddWithValue("@UserName", userName);
                cmd.Parameters.AddWithValue("@Password", password);
            });
        }
    }
}
