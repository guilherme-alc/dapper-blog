using Blog.Repositories;
using Blog.Utils;

namespace Blog.Screens.UserScreens
{
    public class UpdateUserScreen
    {
        public static void Load()
        {
            try
            {
                Console.Write("Informe o ID do usuário: ");
                var input = Console.ReadLine();
                if (!InputValidator.TryParseNumber(input, out int id))
                    throw new Exception("O ID deve ser um inteiro");
                Console.Write("Informe o novo nome: ");
                var name = Console.ReadLine();
                Console.Write("Informe o novo email: ");
                var email = Console.ReadLine();
                Console.Write("Informe o novo slug: ");
                var slug = Console.ReadLine();


                var repository = new UserRepository(Database.Connection);
                var result = repository.UpdateUser(id, name, email, slug);
                if (result)
                    Console.WriteLine("\nUsuário atualizado com sucesso!");
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
                    Console.WriteLine("[1] - Atualizar usuário");
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
