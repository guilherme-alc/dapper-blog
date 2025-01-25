using Blog.Models;
using Blog.Repositories;
using Blog.Utils;

namespace Blog.Screens.PostScreens
{
    public class ReadPostScreen
    {
        public static void Load()
        {
            try
            {
                var repository = new Repository<Post>(Database.Connection);
                var posts = repository.GetAll().OrderBy(x => x.CreateDate);

                foreach (var post in posts)
                {
                    Console.WriteLine($"Criação: {post.CreateDate} | Id: {post.Id} | Título: {post.Title}");
                }
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
                    Console.WriteLine("[1] - Fazer uma nova busca");
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
        public static void Load(int value)
        {
            try
            {
                Console.Write("\nInsira o ID da postagem: ");
                var input = Console.ReadLine();
                if (InputValidator.TryParseNumber(input, out int id))
                {
                    var repository = new Repository<Post>(Database.Connection);
                    var post = repository.GetById(id);

                    Console.WriteLine($"Id: {post.Id} | Título: {post.Title}\n{post.Body}\nÚltima atualização: {post.LastUpdateDate}");
                }
                else
                {
                    throw new FormatException("Entrada inválida: o ID da postagem deve ser um número inteiro.");
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
                    Console.WriteLine("\n[0] - Voltar ao menu anteior");
                    Console.WriteLine("[1] - Fazer uma nova busca");
                    var input = Console.ReadLine();

                    if (input == "0")
                    {
                        repeat = false;
                        MenuPostScreen.Load();
                    }
                    else if (input == "1")
                    {
                        repeat = false;
                        Load(1);
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
