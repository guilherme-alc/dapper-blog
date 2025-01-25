using Blog.Utils;

namespace Blog.Screens.TagScreens
{
    public class MenuTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de tags");
            Console.WriteLine("=======================================================");
            Console.WriteLine("[0] - Voltar ao Menu principal");
            Console.WriteLine("[1] - Listar tags");
            Console.WriteLine("[2] - Buscar tag pelo ID");
            Console.WriteLine("[3] - Criar tag");
            Console.WriteLine("[4] - Editar tag");
            Console.WriteLine("[5] - Deletar tag");
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
                    ReadTagScreen.Load();
                    break;
                case 2:
                    ReadTagScreen.Load(0);
                    break;
                case 3:
                    CreateTagScreen.Load();
                    break;
                case 4:
                    UpdateTagScreen.Load();
                    break;
                case 5:
                    DeleteTagScreen.Load();
                    break;
                default:
                    Load();
                    break;
            }
        }
    }
}
