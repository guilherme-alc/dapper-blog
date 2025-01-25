using Blog.Screens.CategoryScreens;
using Blog.Screens.ReportScreens;
using Blog.Screens.TagScreens;
using Blog.Screens.UserScreens;
using Blog.Utils;

namespace Blog.Screens
{
    public class MenuScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Acesso a dados com Dapper");
            Console.WriteLine("===================================================");
            Console.WriteLine("[0] - Encerrar aplicação");
            Console.WriteLine("[1] - Gestão de usuários");
            Console.WriteLine("[2] - Gestão de perfis");
            Console.WriteLine("[3] - Gestão de categorias");
            Console.WriteLine("[4] - Gestão de tags");
            Console.WriteLine("[5] - Gestão de postagens");
            Console.WriteLine("[6] - Relatórios");
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
                    break;
                case 1:
                    MenuUserScreen.Load();
                    break;
                case 2:
                    break;
                case 3:
                    MenuCategoryScreen.Load();
                    break;
                case 4:
                    MenuTagScreen.Load();
                    break;
                case 5:
                    break;
                case 6:
                    MenuReportScreen.Load();
                    break;
                default:
                    Load();
                    break;
            }
        }
    }
}
