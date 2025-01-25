using Blog.Models;
using Blog.Repositories;
using Blog.Screens.CategoryScreens;

namespace Blog.Screens.TagScreens
{
    public class CreateTagScreen
    {
        public static void Load()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Digite o nome da tag:");
                var name = Console.ReadLine();
                Console.WriteLine("Digite o slug da tag:");
                var slug = Console.ReadLine();

                var tag = new Tag()
                {
                    Name = name,
                    Slug = slug
                };

                var repository = new Repository<Tag>(Database.Connection);
                var result = repository.Create(tag);
                if (result)
                    Console.WriteLine("\nTag criada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            finally
            {
                var repeat = true;
                while (repeat)
                {
                    Console.WriteLine("\n[0] - Voltar ao menu anteior");
                    Console.WriteLine("[1] - Criar nova tag");
                    var input = Console.ReadLine();

                    if (input == "0")
                    {
                        repeat = false;
                        MenuTagScreen.Load();
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
