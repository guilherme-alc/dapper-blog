using Blog.Repositories;
using Blog.Utils;

namespace Blog.Screens.PostScreens
{
    public class PostTagScreen
    {
        public static void Load()
        {
            try
            {
                Console.Write("Digite o ID do post: ");
                var inputPost = Console.ReadLine();
                if (!InputValidator.TryParseNumber(inputPost, out int postId))
                    throw new Exception("O ID deve ser um inteiro");
                Console.Write("Digite o ID da tag: ");
                var inputTag = Console.ReadLine();
                if (!InputValidator.TryParseNumber(inputTag, out int tagId))
                    throw new Exception("O ID deve ser um inteiro");

                var repository = new PostRepository(Database.Connection);
                var result = repository.PostTag(postId, tagId);
                if (result)
                    Console.WriteLine("\nTag vinculada com sucesso!");
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
                    Console.WriteLine("[1] - Fazer um novo vínculo");
                    var input = Console.ReadLine();

                    if (input == "0")
                    {
                        repeat = false;
                        MenuPostScreen.Load();
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
