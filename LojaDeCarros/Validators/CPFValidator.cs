using System.Text.RegularExpressions;

namespace LojaDeCarros.Validators
{
    public static class CPFValidator
    {
        public static bool IsValid(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf)) return false;

            cpf = Regex.Replace(cpf, "[^0-9]", "");

            if (cpf.Length != 11 || cpf.Distinct().Count() == 1)
                return false;

            var numbers = cpf.Select(c => int.Parse(c.ToString())).ToArray();

            for (int i = 9; i < 11; i++)
            {
                int sum = 0;
                for (int j = 0; j < i; j++)
                    sum += numbers[j] * (i + 1 - j);

                int result = sum * 10 % 11;
                if (result == 10) result = 0;
                if (numbers[i] != result) return false;
            }

            return true;
        }
    }
}
