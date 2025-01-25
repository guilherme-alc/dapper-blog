using Blog.Utils;

namespace Blog.Screens.PostScreens
{
    public class MenuPostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de postagem");
            Console.WriteLine("=======================================================");
            Console.WriteLine("[0] - Voltar ao Menu principal");
            Console.WriteLine("[1] - Listar postagens");
            Console.WriteLine("[2] - Buscar postagem pelo ID");
            Console.WriteLine("[3] - Criar nova postagem");
            Console.WriteLine("[4] - Editar postagem existente");
            Console.WriteLine("[5] - Deletar postagem");
            Console.WriteLine("[6] - Vincular tag a uma postagem");
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
                    ReadPostScreen.Load();
                    break;
                case 2:
                    ReadPostScreen.Load(0);
                    break;
                case 3:
                    CreatePostScreen.Load();
                    break;
                case 4:
                    UpdatePostScreen.Load();
                    break;
                case 5:
                    DeletePostScreen.Load();
                    break;
                case 6:
                    PostTagScreen.Load();
                    break;
                default:
                    Load();
                    break;
            }

        }
    }
}
