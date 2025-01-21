using Blog.Models;
using Blog.Repositories;
using Blog.Screens.CategoryScreens;
using Blog.Utils;

namespace Blog.Screens.UserScreens
{
    public class ReadUserScreen
    {
        public static void Load()
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                var users = repository.GetAll();

                foreach (var user in users)
                {
                    Console.WriteLine($"{user.Id} | {user.Name} | {user.Email}");
                }
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
                    Console.WriteLine("\n[0] - Voltar ao menu anterior");
                    Console.WriteLine("[1] - Fazer uma nova busca");
                    var input = Console.ReadLine();

                    if (input == "0")
                    {
                        repeat = false;
                        MenuUserScreen.Load();
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
        public static void Load(int param)
        {
            try
            {
                Console.Write("\nInsira o ID do usuário: ");
                var input = Console.ReadLine();
                if (InputValidator.TryParseNumber(input, out int id))
                {
                    var repository = new Repository<User>(Database.Connection);
                    var user = repository.GetById(id);

                    Console.WriteLine($"{user.Id} | {user.Name} | {user.Email}");
                }
                else
                {
                    throw new FormatException("Entrada inválida: o ID do usuário deve ser um número inteiro.");
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
                        MenuUserScreen.Load();
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
