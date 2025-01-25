using Blog.Models;
using Blog.Repositories;
using Blog.Utils;

namespace Blog.Screens.TagScreens
{
    internal class ReadTagScreen
    {
        public static void Load()
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                var tags = repository.GetAll();

                foreach (var tag in tags)
                {
                    Console.WriteLine($"{tag.Id} | {tag.Name} | {tag.Slug}");
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
        public static void Load(int value)
        {
            try
            {
                Console.Write("\nInsira o ID da tag: ");
                var input = Console.ReadLine();
                if (InputValidator.TryParseNumber(input, out int id))
                {
                    var repository = new Repository<Tag>(Database.Connection);
                    var tag = repository.GetById(id);

                    Console.WriteLine($"{tag.Id} | {tag.Name} | {tag.Slug}");
                }
                else
                {
                    throw new FormatException("Entrada inválida: o ID da tag deve ser um número inteiro.");
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
                        MenuTagScreen.Load();
                    }
                    else if (input == "1")
                    {
                        repeat = false;
                        Load(0);
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
