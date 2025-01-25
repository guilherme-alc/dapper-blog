using Blog.Models;
using Blog.Repositories;
using Blog.Utils;

namespace Blog.Screens.PostScreens
{
    public class CreatePostScreen
    {
        public static void Load()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Digite o título da postagem:");
                var title = Console.ReadLine();
                Console.WriteLine("Agora digite o sumário:");
                var summary = Console.ReadLine();
                Console.WriteLine("Escreva um texto");
                var body = Console.ReadLine();
                Console.WriteLine("informe o slug");
                var slug = Console.ReadLine();

                Console.WriteLine("Informe o ID do autor da postagem");
                var inputAuthor = Console.ReadLine();
                if (!InputValidator.TryParseNumber(inputAuthor, out int authorId))
                    throw new Exception("O ID deve ser um inteiro");
                var existingUser = new Repository<User>(Database.Connection).GetById(authorId);
                if (existingUser == null)
                    throw new Exception("Não foi possível localizar o usuário.");

                Console.WriteLine("Informe o ID da categoria");
                var inputCategory = Console.ReadLine();
                if (!InputValidator.TryParseNumber(inputCategory, out int categoryId))
                    throw new Exception("O ID deve ser um inteiro");
                var existingCategory = new Repository<Category>(Database.Connection).GetById(categoryId);
                if (existingCategory == null)
                    throw new Exception("Não foi possível localizar a categoria.");

                var post = new Post()
                {
                    Title = title,
                    Summary = summary,
                    Body = body,
                    Slug = slug,
                    AuthorId = authorId,
                    CategoryId = categoryId,
                    CreateDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                };

                var repository = new Repository<Post>(Database.Connection);
                var result = repository.Create(post);
                if (result)
                    Console.WriteLine("\nPostagem criado com sucesso!");
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
                    Console.WriteLine("[1] - Criar nova postagem");
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
