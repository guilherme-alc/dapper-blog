using Blog.Models;
using Blog.Repositories;
using Blog.Utils;

namespace Blog.Screens.CategoryScreens
{
    public class UpdateCategoryScreen
    {
        public static void Load()
        {
            try
            {
                Console.Write("Informe o ID da categoria: ");
                var input = Console.ReadLine();
                if (!InputValidator.TryParseNumber(input, out int id))
                    throw new Exception("O ID deve ser um inteiro");
                Console.Write("Informe o novo nome: ");
                var name = Console.ReadLine();
                Console.Write("Informe o novo slug: ");
                var slug = Console.ReadLine();
                var category = new Category()
                {
                    Id = id,
                    Name = name,
                    Slug = slug
                };
                var repository = new Repository<Category>(Database.Connection);
                var result = repository.Update(category);
                if (result)
                    Console.WriteLine("\nCategoria atualizada com sucesso!");
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
                    Console.WriteLine("[1] - Atualizar categoria");
                    var input = Console.ReadLine();

                    if (input == "0")
                    {
                        repeat = false;
                        MenuCategoryScreen.Load();
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
