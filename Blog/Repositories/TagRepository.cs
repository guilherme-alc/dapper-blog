using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class TagRepository : Repository<Tag>
    {
        public TagRepository(SqlConnection connection)
            : base(connection)
        {
            _connection = connection;
        }
        private readonly SqlConnection _connection;
        public List<PostTagReport> GetTagWithPost()
        {
            var query = @"SELECT 
                            [Tag].[Name] AS TagName, COUNT([Post].[Id]) as PostCount FROM [Tag]
                        LEFT JOIN
                            [PostTag] ON [Tag].[Id] = [PostTag].[TagId]
                        LEFT JOIN
                            [Post] ON [PostTag].[PostId] = [Post].[Id]
                        GROUP BY
                            [Tag].[Name]";
            var items = _connection.Query<PostTagReport>(query);
            if (items == null)
                throw new Exception("Não foi possível realizar a busca desse relatório");
            return items.ToList();
        }
    }
}
