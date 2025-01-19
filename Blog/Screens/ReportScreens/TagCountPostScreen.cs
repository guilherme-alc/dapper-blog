using Blog.Repositories;

namespace Blog.Screens.ReportScreens
{
    public class TagCountPostScreen
    {
        public static void Load()
        {
            try
            {
                var repository = new TagRepository(Database.Connection);
                var tags = repository.GetTagWithPost().OrderByDescending(tag => tag.PostCount);
                foreach ( var tag in tags )
                {
                    Console.WriteLine($"{tag.TagName} - {tag.PostCount}");
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
