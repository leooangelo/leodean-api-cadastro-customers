using System.Text.RegularExpressions;

namespace MS.Customer.Infra.CrossCutting.Utils
{
    public static class PasswordValidator
    {
        public static bool Valid(string pw)
        {
            if (!string.IsNullOrEmpty(pw))
            {
                var lowerCase = new Regex("[a-z]+");
                var upperCase = new Regex("[A-Z]+");
                var digit = new Regex("(\\d)+");
                var symbol = new Regex("(\\W)+");
                var minLength = pw.Length >= 8;

                return lowerCase.IsMatch(pw) && upperCase.IsMatch(pw) && digit.IsMatch(pw) && symbol.IsMatch(pw) && minLength;
            }

            return true;
        }
    }
}
