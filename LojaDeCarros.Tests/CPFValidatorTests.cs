using LojaDeCarros.Models;
using LojaDeCarros.Validators;

namespace LojaDeCarros.Tests;

public class CPFValidatorTests
{

    [Theory]
    [InlineData("12345678909", true)]     // CPF válido
    [InlineData("11111111111", false)]    // Dígitos iguais
    [InlineData("12345678900", false)]    // CPF inválido
    [InlineData("93541134780", true)]     // CPF real válido
    [InlineData("", false)]               // Vazio
    [InlineData("abc", false)]            // Letras
    public void IsValid_DeveValidarCorretamenteOCpf(string cpf, bool expected)
    {
        var result = CPFValidator.IsValid(cpf);
        Assert.Equal(expected, result);
    }
}

