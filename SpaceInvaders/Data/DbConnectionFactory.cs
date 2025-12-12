using MySql.Data.MySqlClient;

namespace SpaceInvaders.Data
{
    public static class DbConnectionFactory
    {
        public static MySqlConnection Create()
        {
            return new MySqlConnection(DbConfig.ConnectionString);
        }

        internal static IDisposable CreateConnection()
        {
            throw new NotImplementedException();
        }
    }
}
