using Blog.Screens.CategoryScreens;
using Blog.Utils;

namespace Blog.Screens.UserScreens
{
    public class MenuUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de usuários");
            Console.WriteLine("=======================================================");
            Console.WriteLine("[0] - Voltar ao Menu principal");
            Console.WriteLine("[1] - Listar usuários");
            Console.WriteLine("[2] - Buscar usuário pelo ID");
            Console.WriteLine("[3] - Criar usuário");
            Console.WriteLine("[4] - Editar usuário");
            Console.WriteLine("[5] - Deletar usuário");
            Console.Write("\nSelecione o número correspondente a opção desejada: ");
            var input = Console.ReadLine();

            if (!InputValidator.TryParseNumber(input, out int option))
            {
                Console.WriteLine("Não encontrei a opção escolhida, tente novamente");
                Load();
            }

            switch (option)
            {
                case 0:
                    MenuScreen.Load();
                    break;
                case 1:
                    ReadUserScreen.Load();
                    break;
                case 2:
                    ReadUserScreen.Load(0);
                    break;
                case 3:
                    CreateUserScreen.Load();
                    break;
                case 4:
                    UpdateUserScreen.Load();
                    break;
                case 5:
                    DeleteUserScreen.Load();
                    break;
                default:
                    Load();
                    break;
            }
        }
    }
}
