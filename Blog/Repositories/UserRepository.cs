using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class UserRepository : Repository<User>
    {
        private readonly SqlConnection _connection;
        public UserRepository(SqlConnection connection)
            : base(connection)
        {
            _connection = connection;
        }

        public List<User> GetUserWithRole()
        {
            var users = new List<User>();
            var query = @"SELECT 
                            [User].*, [Role].* 
                        FROM 
                            [User]
                        LEFT JOIN
                            [UserRole] ON [User].[Id] = [UserRole].[UserId]
                        LEFT JOIN
                            [Role] ON [Role].[Id] = [UserRole].[RoleId]";
            var items = _connection.Query<User, Role, User>(query,(user, role) =>
            {
                var existingUser = users.Where(x => x.Id == user.Id).FirstOrDefault();
                if(existingUser == null)
                {
                    existingUser = user;
                    if(role != null)
                        existingUser.Roles.Add(role);
                    users.Add(existingUser);
                } else
                {
                    existingUser.Roles.Add(role);
                }
                return user;
            }, splitOn: "Id");
            if(users == null)
                throw new Exception("Não foi possível realizar a busca desse relatório");
            return users;
        }
    }
}
