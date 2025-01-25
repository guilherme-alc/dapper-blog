using Blog.Models;
using Blog.Repositories;
using Blog.Utils;

namespace Blog.Screens.PostScreens
{
    public class UpdatePostScreen
    {
        public static void Load()
        {
            try
            {
                Console.Write("Informe o ID da postagem: ");
                var input = Console.ReadLine();
                if (!InputValidator.TryParseNumber(input, out int id))
                    throw new Exception("O ID deve ser um inteiro");

                var repository = new Repository<Post>(Database.Connection);
                var post = repository.GetById(id);
                if (post == null)
                    throw new Exception("Postagem não encontrada.");

                Console.Write("Informe o novo título: ");
                post.Title = Console.ReadLine();
                Console.Write("Informe o novo sumário: ");
                post.Summary = Console.ReadLine();
                Console.Write("Informe o novo slug: ");
                post.Slug = Console.ReadLine();
                post.LastUpdateDate = DateTime.Now;

                var result = repository.Update(post);
                if (result)
                    Console.WriteLine("\nPostagem atualizada com sucesso!");
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
                    Console.WriteLine("\n[0] - Voltar ao menu anterior");
                    Console.WriteLine("[1] - Atualizar postagem");
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
