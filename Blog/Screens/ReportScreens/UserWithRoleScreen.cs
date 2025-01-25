using Blog.Repositories;

namespace Blog.Screens.ReportScreens
{
    public class UserWithRoleScreen
    {
        public static void Load()
        {
            try
            {
                var repository = new UserRepository(Database.Connection);
                var users = repository.GetUserWithRole();
                foreach(var user in users)
                {
                    Console.WriteLine($"\nID: {user.Id} | {user.Name} | {user.Email}\nBio:\n{user.Bio}");
                    foreach(var role in user.Roles)
                    {
                        Console.WriteLine($"- {role.Name}");
                    }
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
                        MenuReportScreen.Load();
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
