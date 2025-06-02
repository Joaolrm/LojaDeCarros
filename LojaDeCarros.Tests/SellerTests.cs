using LojaDeCarros.Models;

namespace LojaDeCarros.Tests;

public class SellerTests
{
    [Fact]
    public void CalculateCommission_DeveRetornar5PorCento()
    {
        // Arrange
        var seller = new Seller();
        decimal valorVenda = 10000;

        // Act
        var comissao = seller.CalculateCommission(valorVenda);

        // Assert
        Assert.Equal(500, comissao);
    }
}
