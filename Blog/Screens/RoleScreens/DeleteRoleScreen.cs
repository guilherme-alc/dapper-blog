using Blog.Models;
using Blog.Repositories;
using Blog.Screens.CategoryScreens;
using Blog.Utils;

namespace Blog.Screens.RoleScreens
{
    public class DeleteRoleScreen
    {
        public static void Load()
        {
            try
            {
                Console.Write("Informe o ID do perfil: ");
                var input = Console.ReadLine();
                if (!InputValidator.TryParseNumber(input, out int id))
                    throw new Exception("O ID deve ser um inteiro");

                var repository = new Repository<Role>(Database.Connection);
                var result = repository.DeleteById(id);
                if (result)
                    Console.WriteLine("\nPerfil deletado com sucesso!");
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
                    Console.WriteLine("[1] - Deletar perfil");
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
