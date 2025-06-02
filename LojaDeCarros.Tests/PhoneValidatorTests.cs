using LojaDeCarros.Validators;
using Xunit;

namespace LojaDeCarros.Tests
{
    public class PhoneValidatorTests
    {
        [Theory]
        [InlineData("11999998888", true)]  // Celular SP
        [InlineData("1133224455", true)]   // Fixo SP
        [InlineData("2123456789", true)]   // Fixo RJ
        [InlineData("1199999", false)]     // Muito curto
        [InlineData("abcdefghijk", false)] // Não numérico
        [InlineData("11-99999-8888", false)] // Separadores inválidos
        [InlineData("", false)]
        [InlineData("   ", false)]
        public void IsValid_DeveValidarTelefoneCorretamente(string phone, bool expected)
        {
            var result = PhoneValidator.IsValid(phone);
            Assert.Equal(expected, result);
        }
    }
}
