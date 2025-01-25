using Blog.Utils;

namespace Blog.Screens.CategoryScreens
{
    public class MenuCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de categorias");
            Console.WriteLine("=======================================================");
            Console.WriteLine("[0] - Voltar ao Menu principal");
            Console.WriteLine("[1] - Listar categorias");
            Console.WriteLine("[2] - Buscar categoria pelo ID");
            Console.WriteLine("[3] - Criar nova categoria");
            Console.WriteLine("[4] - Editar categoria existente");
            Console.WriteLine("[5] - Deletar categoria");
            Console.Write("\nSelecione o número correspondente a opção desejada: ");
            var input = Console.ReadLine();
            
            if(!InputValidator.TryParseNumber(input, out int option)) {
                Console.WriteLine("Não encontrei a opção escolhida, tente novamente");
                Load();
            }

            switch(option)
            {
                case 0:
                    MenuScreen.Load();
                    break;
                case 1:
                    ReadCategoryScreen.Load();
                    break;
                case 2:
                    ReadCategoryScreen.Load(0);
                    break;
                case 3: 
                    CreateCategoryScreen.Load();
                    break;
                case 4:
                    UpdateCategoryScreen.Load();
                    break;
                case 5:
                    DeleteCategoryScreen.Load();
                    break;
                default:
                    Load();
                    break;
            }

        }
    }
}
