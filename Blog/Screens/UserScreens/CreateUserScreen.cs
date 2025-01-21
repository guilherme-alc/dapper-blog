using Blog.Models;
using Blog.Repositories;
using Blog.Screens.CategoryScreens;

namespace Blog.Screens.UserScreens
{
    public class CreateUserScreen
    {
        public static void Load()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Digite o nome do usuário:");
                var name = Console.ReadLine();
                Console.WriteLine("Agora digite o email do usuário:");
                var email = Console.ReadLine();
                Console.WriteLine("Digte a senha");
                var password = Console.ReadLine();
                Console.WriteLine("Escreva uma biografia");
                var bio = Console.ReadLine();
                Console.WriteLine("Informe o caminho da foto de perfil");
                var image = Console.ReadLine();
                Console.WriteLine("Digite o slug para sua conta");
                var slug = Console.ReadLine();


                var user = new User()
                {
                    Name = name,
                    Email = email,
                    PasswordHash = password,
                    Bio = bio,
                    Image = image,
                    Slug = slug
                };

                var repository = new Repository<User>(Database.Connection);
                var result = repository.Create(user);
                if (result)
                    Console.WriteLine("\nUsuário criado com sucesso!");
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
                    Console.WriteLine("\n[0] - Voltar ao menu anteior");
                    Console.WriteLine("[1] - Criar novo usuário");
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
