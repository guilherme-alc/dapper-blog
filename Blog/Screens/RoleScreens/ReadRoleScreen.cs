using Blog.Models;
using Blog.Repositories;
using Blog.Utils;

namespace Blog.Screens.RoleScreens
{
    public class ReadRoleScreen
    {
        public static void Load()
        {
            try
            {
                var repository = new Repository<Role>(Database.Connection);
                var roles = repository.GetAll();

                foreach (var role in roles)
                {
                    Console.WriteLine($"{role.Id} | {role.Name} | {role.Slug}");
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
                        MenuRoleScreen.Load();
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
                Console.Write("\nInsira o ID do perfil: ");
                var input = Console.ReadLine();
                if (InputValidator.TryParseNumber(input, out int id))
                {
                    var repository = new Repository<Role>(Database.Connection);
                    var role = repository.GetById(id);

                    Console.WriteLine($"{role.Id} | {role.Name} | {role.Slug}");
                }
                else
                {
                    throw new FormatException("Entrada inválida: o ID do perfil deve ser um número inteiro.");
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
                        MenuRoleScreen.Load();
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
