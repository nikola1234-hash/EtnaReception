using System.Text.RegularExpressions;

namespace BookSoft.BLL.Validation
{
    public sealed class NumbersValidation
    {
        public static bool Validate(string number)
        {
            string pattern = @"^[0-9]*$";
            Regex rx = new Regex(pattern);
            var isMatching = rx.IsMatch(number);
            return isMatching;
        }
        
    }
}
