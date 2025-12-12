using SpaceInvaders.Models;
using SpaceInvaders.Data;
using System.Collections.Generic;
using System.Data;

namespace SpaceInvaders.Repositories
{
    public class UserInfoRepository
    {
        public int Add(UserInfo user)
        {
            string q = @"INSERT INTO user_info
                         (UserName, FirstName, LastName, Age, Email, Contact_Number)
                         VALUES
                         (@UserName, @FirstName, @LastName, @Age, @Email, @Contact);";

            return DbHelper.ExecuteNonQuery(q, cmd =>
            {
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Age", user.Age);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Contact", user.Contact_Number);
            });
        }

        public List<UserInfo> GetAll()
        {
            string q = "SELECT * FROM user_info;";
            DataTable dt = DbHelper.ExecuteQuery(q);

            var list = new List<UserInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new UserInfo
                {
                    Id = (int)row["id"],
                    UserName = row["UserName"].ToString(),
                    FirstName = row["FirstName"].ToString(),
                    LastName = row["LastName"].ToString(),
                    Age = (int)row["Age"],
                    Email = row["Email"].ToString(),
                    Contact_Number = row["Contact_Number"].ToString()
                });
            }
            return list;
        }
    }
}
