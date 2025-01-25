using Blog.Utils;

namespace Blog.Screens.ReportScreens
{
    public class MenuReportScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Relatórios");
            Console.WriteLine("=======================================================");
            Console.WriteLine("[0] - Voltar ao Menu principal");
            Console.WriteLine("[1] - Listar os usuários com perfis");
            Console.WriteLine("[2] - Listar categorias com quantidade de posts");
            Console.WriteLine("[3] - Listar tags com quantidade de posts");
            Console.WriteLine("[4] - Listar posts de uma categoria");
            Console.WriteLine("[5] - Listar todos os posts com sua categoria");
            Console.WriteLine("[6] - Listar posts com suas tags");
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
                    UserWithRoleScreen.Load();
                    break;
                case 2:
                    CategoryCountPostScreen.Load();
                    break;
                case 3:
                    TagCountPostScreen.Load();
                    break;
                case 4:
                    PostFromCategoryScreen.Load();
                    break;
                case 5:
                    PostWithCategory.Load();
                    break;
                case 6:
                    PostWithTagScreen.Load();
                    break;
                default:
                    Load();
                    break;
            }
        }
    }
}
