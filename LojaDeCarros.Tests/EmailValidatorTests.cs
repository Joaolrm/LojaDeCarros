using LojaDeCarros.Validators;
using Xunit;

namespace LojaDeCarros.Tests
{
    public class EmailValidatorTests
    {
        [Theory]
        [InlineData("joao@email.com", true)]
        [InlineData("maria.silva@dominio.org", true)]
        [InlineData("usuario@dominio", false)]           // sem TLD
        [InlineData("usuario@.com", false)]              // domínio inválido
        [InlineData("usuario@@dominio.com", false)]      // dois @
        [InlineData("usuario@dominio..com", false)]      // ponto duplo
        [InlineData("", false)]
        [InlineData("   ", false)]
        [InlineData("sem-arroba.com", false)]
        public void IsValid_DeveValidarCorretamenteEmail(string email, bool expected)
        {
            var result = EmailValidator.IsValid(email);
            Assert.Equal(expected, result);
        }
    }
}
