using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class CategoryRepository : Repository<Category>
    {
        private readonly SqlConnection _connection;
        public CategoryRepository(SqlConnection connection)
            : base(connection)
        {
            _connection = connection;
        }

        public List<Category> GetCategoryCountPost()
        {
            var categories = new List<Category>();
            var query = @"SELECT 
                            [Category].*, [Post].* 
                        FROM 
                            [Category]
                        LEFT JOIN
                            [Post] ON [Category].[Id] = [Post].[CategoryId]";
            var items = _connection.Query<Category, Post, Category>(query, (category, post) =>
            {
                var existingCategory = categories.Where(x => x.Id == category.Id).FirstOrDefault();
                if(existingCategory == null)
                {
                    existingCategory = category;
                    if(post != null)
                        existingCategory.Posts.Add(post);
                    categories.Add(existingCategory);
                } else
                {
                    existingCategory.Posts.Add(post);
                }

                return category;
            }, splitOn: "Id");
            if(categories == null)
                throw new Exception("Não foi possível realizar a busca desse relatório");
            return categories;
        }

        public List<Category> GetPostFromCategory()
        {
            var categories = new List<Category>();
            var query = @"SELECT 
                            [Category].*, [Post].* FROM [Category]
                        LEFT JOIN 
                            [Post] ON [Category].[Id] = [Post].[CategoryId]";
            var items = _connection.Query<Category, Post, Category>(query, (category, post) =>
            {
                var existingCategory = categories.Where(x => x.Id == category.Id).FirstOrDefault();
                if(existingCategory == null)
                {
                    existingCategory = category;
                    if (post != null)
                        existingCategory.Posts.Add(post);
                    categories.Add(existingCategory);
                } else 
                    existingCategory.Posts.Add(post);
                return category;
            }, splitOn: "Id");
            return categories;
        }
    }
}
