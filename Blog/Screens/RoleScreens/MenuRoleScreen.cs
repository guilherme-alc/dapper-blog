using Blog.Screens.CategoryScreens;
using Blog.Utils;

namespace Blog.Screens.RoleScreens
{
    public class MenuRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de perfil");
            Console.WriteLine("=======================================================");
            Console.WriteLine("[0] - Voltar ao Menu principal");
            Console.WriteLine("[1] - Listar perfis");
            Console.WriteLine("[2] - Buscar perfil pelo ID");
            Console.WriteLine("[3] - Criar novo perfil");
            Console.WriteLine("[4] - Editar perfil existente");
            Console.WriteLine("[5] - Deletar perfil");
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
                    ReadRoleScreen.Load();
                    break;
                case 2:
                    ReadRoleScreen.Load(0);
                    break;
                case 3:
                    CreateRoleScreen.Load();
                    break;
                case 4:
                    UpdateRoleScreen.Load();
                    break;
                case 5:
                    DeleteRoleScreen.Load();
                    break;
                default:
                    Load();
                    break;
            }
        }
    }
}
