using Blog.Screens;
using Microsoft.Data.SqlClient;

namespace Blog
{
    internal class Program
    {
        private static readonly string CONNECTION_STRING = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING", EnvironmentVariableTarget.User);
        static void Main(string[] args)
        {
            Database.Connection = new SqlConnection(CONNECTION_STRING);
            Database.Connection.Open();

            MenuScreen.Load();

            Database.Connection.Close();

        }
    }
}
