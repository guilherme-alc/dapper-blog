using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.RoleScreens
{
    public class CreateRoleScreen
    {
        public static void Load()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Digite o nome do perfil:");
                var name = Console.ReadLine();
                Console.WriteLine("Digite o slug do perfil:");
                var slug = Console.ReadLine();

                var role = new Role()
                {
                    Name = name,
                    Slug = slug
                };

                var repository = new Repository<Role>(Database.Connection);
                var result = repository.Create(role);
                if (result)
                    Console.WriteLine("\nPerfil criado com sucesso!");
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
                    Console.WriteLine("[1] - Criar novo perfil");
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
    }
}
