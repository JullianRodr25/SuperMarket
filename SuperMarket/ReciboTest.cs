using FluentAssertions;

namespace SuperMarket;

public class ReciboTest
{
    [Fact]
    public void Si_Compro1BolsaDeArroz_Debe_GenerarElReciboConElDetalleYElValorTotalSinDescuentos()
    {
        // Arrange
        var productos = new List<(string nombre, decimal precio, decimal unidad)>
        {
            ("Arroz", 2.49m, 1),
        };

        var carrito = new Carrito();

        // Act
        var recibo = carrito.GenerarRecibo(productos);
    
        //Assert
        recibo.ProductosDetalles.Should().ContainSingle();
        recibo.ProductosDetalles[0].Should().Contain("Arroz");
        recibo.Total.Should().Be(2.49m);
        recibo.TotalDescuentos.Should().Be(0m);
    }
}