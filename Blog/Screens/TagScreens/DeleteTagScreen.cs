using Blog.Models;
using Blog.Repositories;
using Blog.Screens.CategoryScreens;
using Blog.Utils;

namespace Blog.Screens.TagScreens
{
    public class DeleteTagScreen
    {
        public static void Load()
        {
            try
            {
                Console.Write("Informe o ID da tag: ");
                var input = Console.ReadLine();
                if (!InputValidator.TryParseNumber(input, out int id))
                    throw new Exception("O ID deve ser um inteiro");

                var repository = new Repository<Tag>(Database.Connection);
                var result = repository.DeleteById(id);
                if (result)
                    Console.WriteLine("\nTag deletada com sucesso!");
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
                    Console.WriteLine("[1] - Deletar tag");
                    var input = Console.ReadLine();

                    if (input == "0")
                    {
                        repeat = false;
                        MenuTagScreen.Load();
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
