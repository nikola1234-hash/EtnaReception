using System.Text.RegularExpressions;

namespace BookSoft.BLL.Validation
{
    public sealed class EmailValidation
    {
        public static bool Validate(string input)
        {
            bool output = false;
            string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            Regex rx = new Regex(pattern);
            Match match = rx.Match(input);
            if (match.Success)
                output = true;
            return output;
        }
    }
}
