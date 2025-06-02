using System.Text.RegularExpressions;

namespace LojaDeCarros.Validators
{
    public static class EmailValidator
    {
        public static bool IsValid(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // Regex aprimorada para validar e-mails e evitar casos como dois @ ou pontos duplos
            var pattern = @"^(?!.*\.\.)(?!.*@.*@)[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }
    }
}
