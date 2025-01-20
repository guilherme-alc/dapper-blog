using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class PostRepository : Repository<Post>
    {
        public PostRepository(SqlConnection connection)
            : base(connection)
        {
            _connection = connection;
        }
        private readonly SqlConnection _connection;

        public IEnumerable<dynamic> GetPostWithCategory()
        {
            var query = @"SELECT 
                            [Post].[Title], [Category].[Name]
                        FROM
                            [Post]
                        LEFT JOIN
                            [Category] ON [Post].[CategoryId] = [Category].[Id]";
            return _connection.Query(query);
        }

        public List<Post> GetPostWithTag()
        {
            var posts = new List<Post>();
            var query = @"SELECT 
                            [Post].*, [Tag].*  FROM [Post]
                        LEFT JOIN
                            [PostTag] ON [Post].[Id] = [PostTag].[PostId]
                        LEFT JOIN
                            [Tag] ON [PostTag].[TagId] = [Tag].[Id]";
            var items = _connection.Query<Post, Tag, Post>(query, (post, tag) =>
            {
                var existingPost = posts.Where(x => x.Id == post.Id).FirstOrDefault();
                if(existingPost == null)
                {
                    existingPost = post;
                    if(tag != null)
                        existingPost.Tags.Add(tag);
                    posts.Add(existingPost);
                } else
                {
                    existingPost.Tags.Add(tag);
                }
                return post;
            }, splitOn: "Id");
            return posts;
        }
    }
}
