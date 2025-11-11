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
    
    [Fact]
    public void Si_Compro1BolsaDeArrozY1DeLeche_Debe_GenerarReciboConDosProductosSinDescuentoYDebeIncluirAmbosEnElDetalle()
    {
        // Arrange
        var productos = new List<(string nombre, decimal precio, decimal unidad)>
        {
            ("Arroz", 2.49m, 1),
            ("Leche", 1.99m, 1)
        };
        var carrito = new Carrito();

        // Act
        var recibo = carrito.GenerarRecibo(productos);
    
        // Assert
        recibo.ProductosDetalles.Should().HaveCount(2);
        recibo.ProductosDetalles[0].Should().Contain("Arroz");
        recibo.ProductosDetalles[1].Should().Contain("Leche");
        recibo.Total.Should().Be(4.48m);
        recibo.TotalDescuentos.Should().Be(0m);
    }
    
    [Fact]
    public void Si_ComproUnProducto_Debe_GenerarReciboYDebeIncluirNombrePrecioYCantidad()
    {
        // Arrange
        var productos = new List<(string nombre, decimal precio, decimal unidad)>
        {
            ("Arroz", 2.49m, 2)
        };
        var carrito = new Carrito();

        // Act
        var recibo = carrito.GenerarRecibo(productos);
    
        // Assert
        recibo.ProductosDetalles[0].Should().Contain("Arroz");
        recibo.ProductosDetalles[0].Should().Contain("2,49");
        recibo.ProductosDetalles[0].Should().Contain("2");
        recibo.Total.Should().Be(4.98m);
    }
    
}