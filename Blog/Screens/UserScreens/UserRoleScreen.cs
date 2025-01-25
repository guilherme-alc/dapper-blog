using Blog.Repositories;
using Blog.Utils;

namespace Blog.Screens.UserScreens
{
    public class UserRoleScreen
    {
        public static void Load()
        {
            try
            {
                Console.Write("Digite o ID do usuário: ");
                var inputUser = Console.ReadLine();
                if (!InputValidator.TryParseNumber(inputUser, out int userId))
                    throw new Exception("O ID deve ser um inteiro");
                Console.Write("Digite o ID do perfil: ");
                var inputRole = Console.ReadLine();
                if (!InputValidator.TryParseNumber(inputRole, out int roleId))
                    throw new Exception("O ID deve ser um inteiro");

                var repository = new UserRepository(Database.Connection);
                var result = repository.UserRole(userId, roleId);
                if(result)
                    Console.WriteLine("\nUsuário vinculado com sucesso!");
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
                    Console.WriteLine("[1] - Fazer um novo vínculo");
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
    }
}
