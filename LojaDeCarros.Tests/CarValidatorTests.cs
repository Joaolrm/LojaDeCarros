using LojaDeCarros.Models;
using LojaDeCarros.Validators;
using Xunit;

namespace LojaDeCarros.Tests
{
    public class CarValidatorTests
    {
        [Fact]
        public void Modelo_Deve_Ser_Ano_Fabricacao_Ou_Ano_Seguinte()
        {
            Assert.True(CarValidator.IsValidModelYear(2023, 2023));
            Assert.True(CarValidator.IsValidModelYear(2023, 2024));
            Assert.False(CarValidator.IsValidModelYear(2023, 2025));
        }

        [Fact]
        public void Preco_Deve_Ser_Maior_Que_Zero()
        {
            Assert.True(CarValidator.IsValidPrice(1));
            Assert.False(CarValidator.IsValidPrice(0));
            Assert.False(CarValidator.IsValidPrice(-10));
        }

        [Fact]
        public void Carro_Deve_Passar_Validacoes_Com_Dados_Validos()
        {
            var car = new Car
            {
                Brand = "Toyota",
                Model = "Corolla",
                ManufactureYear = 2023,
                ModelYear = 2024,
                ChassisNumber = "XYZ123456789",
                Price = 95000m
            };

            var isValid = CarValidator.IsValid(car, out var errors);
            Assert.True(isValid);
            Assert.Empty(errors);
        }

        [Fact]
        public void Carro_Deve_Falhar_Se_Ano_Modelo_Invalido_Ou_Preco_Zerado()
        {
            var car = new Car
            {
                Brand = "Honda",
                Model = "Civic",
                ManufactureYear = 2022,
                ModelYear = 2025, // inválido
                ChassisNumber = "ABC987654321",
                Price = 0 // inválido
            };

            var isValid = CarValidator.IsValid(car, out var errors);
            Assert.False(isValid);
            Assert.Contains("O Ano do Modelo deve ser igual ou no máximo 1 ano após o Ano de Fabricação.", errors);
            Assert.Contains("O Preço do carro deve ser maior que zero.", errors);
        }
    }
}
