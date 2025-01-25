using Blog.Repositories;

namespace Blog.Screens.ReportScreens
{
    public class PostWithCategory
    {
        public static void Load()
        {
            try
            {
                var repository = new PostRepository(Database.Connection);
                var items = repository.GetPostWithCategory();
                foreach (var item in items)
                {
                    Console.WriteLine($"{item.Title}, {item.Name}");
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
