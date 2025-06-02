using System.Text.RegularExpressions;

namespace LojaDeCarros.Validators
{
    public static class PhoneValidator
    {
        public static bool IsValid(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            // Aceita DDD com 2 dígitos + número com 8 ou 9 dígitos (sem separadores)
            var pattern = @"^\d{10,11}$";
            return Regex.IsMatch(phone, pattern);
        }
    }
}
