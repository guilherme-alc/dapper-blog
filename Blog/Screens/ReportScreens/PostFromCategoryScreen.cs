using Blog.Repositories;

namespace Blog.Screens.ReportScreens
{
    public class PostFromCategoryScreen
    {
        public static void Load()
        {
            try
            {
                var repository = new CategoryRepository(Database.Connection);
                var categories = repository.GetPostFromCategory();
                foreach (var category in categories)
                {
                    Console.WriteLine($"\nCategoria: ID: {category.Id} | {category.Name}");
                    foreach(var post in category.Posts)
                    {
                        Console.WriteLine($"Postagem:\nID: {post.Id} | {post.Title}\n{post.Body}\nCriado em: {post.CreateDate}");
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n{ex.Message}");
            }
            finally
            {
                var repeat = true;
                while (repeat)
                {
                    Console.WriteLine("\n[0] - Voltar ao menu anterior");
                    Console.WriteLine("[1] - Fazer uma nova busca");
                    var input = Console.ReadLine();

                    if (input == "0")
                    {
                        repeat = false;
                        MenuReportScreen.Load();
                    }
                    else if (input == "1")
                    {
                        repeat = false;
                        Load();
                    }
                    else
                    {
                        Console.WriteLine("Não encontrei a opção escolhida, tente novamente");
                    }
                }
            }
        }
    }
}
