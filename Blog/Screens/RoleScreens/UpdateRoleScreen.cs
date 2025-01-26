using Blog.Models;
using Blog.Repositories;
using Blog.Utils;

namespace Blog.Screens.RoleScreens
{
    public class UpdateRoleScreen
    {
        public static void Load()
        {
            try
            {
                Console.Write("Informe o ID do perfil: ");
                var input = Console.ReadLine();
                if (!InputValidator.TryParseNumber(input, out int id))
                    throw new Exception("O ID deve ser um inteiro");
                Console.Write("Informe o novo nome: ");
                var name = Console.ReadLine();
                Console.Write("Informe o novo slug: ");
                var slug = Console.ReadLine();
                var role = new Role()
                {
                    Id = id,
                    Name = name,
                    Slug = slug
                };
                var repository = new Repository<Role>(Database.Connection);
                var result = repository.Update(role);
                if (result)
                    Console.WriteLine("\nPerfil atualizado com sucesso!");
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
                    Console.WriteLine("[1] - Atualizar perfil");
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
