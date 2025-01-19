using Blog.Models;
using Blog.Repositories;
using Blog.Utils;

namespace Blog.Screens.CategoryScreens
{
    public class ReadCategoryScreen
    {
        public static void Load(int value)
        {
            try
            {
                var repository = new Repository<Category>(Database.Connection);
                var categories = repository.GetAll();

                foreach (var category in categories)
                {
                    Console.WriteLine($"{category.Id} | {category.Name} | {category.Slug}");
                }
            } catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
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
                        MenuCategoryScreen.Load();
                    }
                    else if (input == "1")
                    {
                        repeat = false;
                        Load(1);
                    }
                    else
                    {
                        Console.WriteLine("Não encontrei a opção escolhida, tente novamente");
                    }
                }
            }
        }

        public static void Load()
        {
            try
            {
                Console.Write("\nInsira o ID da categoria: ");
                var input = Console.ReadLine();
                if (InputValidator.TryParseNumber(input, out int id))
                {
                    var repository = new Repository<Category>(Database.Connection);
                    var category = repository.GetById(id);

                    Console.WriteLine($"{category.Id} | {category.Name} | {category.Slug}");
                }
                else
                {
                    throw new FormatException("Entrada inválida: o ID da categoria deve ser um número inteiro.");
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
                    Console.WriteLine("\n[0] - Voltar ao menu anteior");
                    Console.WriteLine("[1] - Fazer uma nova busca");
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
