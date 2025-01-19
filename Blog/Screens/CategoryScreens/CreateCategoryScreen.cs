using Blog.Models;
using Blog.Repositories;
using Blog.Utils;

namespace Blog.Screens.CategoryScreens
{
    public class CreateCategoryScreen
    {
        public static void Load()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Digite o nome da categoria:");
                var name = Console.ReadLine();
                Console.WriteLine("Digite o slug da categoria:");
                var slug = Console.ReadLine();

                var category = new Category()
                {
                    Name = name,
                    Slug = slug
                };

                var repository = new Repository<Category>(Database.Connection);
                var result = repository.Create(category);
                if (result)
                    Console.WriteLine("\nCategoria criada com sucesso!");
            } catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            finally
            {
                var repeat = true;
                while (repeat)
                {
                    Console.WriteLine("\n[0] - Voltar ao menu anteior");
                    Console.WriteLine("[1] - Criar nova categoria");
                    var input = Console.ReadLine();

                    if (input == "0")
                    {
                        repeat = false;
                        MenuCategoryScreen.Load();
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
