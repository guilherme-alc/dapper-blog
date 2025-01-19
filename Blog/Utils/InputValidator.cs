namespace Blog.Utils
{
    public class InputValidator
    {
        public static bool TryParseNumber(string input, out int number)
        {
            if(int.TryParse(input, out number)) {
                return true;
            }
            number = 0;
            return false;
        }
    }
}
