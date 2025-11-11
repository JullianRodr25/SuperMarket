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
    public void
        Si_Compro1BolsaDeArrozY1DeLeche_Debe_GenerarReciboConDosProductosSinDescuentoYDebeIncluirAmbosEnElDetalle()
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

    [Fact]
    public void
        Si_ComproProductosConDescuentosOPromociones_Debe_GenerarReciboConDetallesDeLaCompraTotalYTotalDescuentos()
    {
        // Arrange
        var productos = new List<(string nombre, decimal precio, decimal unidad)>
        {
            ("Cepillo de dientes", 0.99m, 3),
            ("Arroz", 2.49m, 2),
        };
        var carrito = new Carrito();
        carrito.AplicarDescuentosSemana();

        // Act
        var recibo = carrito.GenerarRecibo(productos);

        // Assert
        recibo.ProductosDetalles.Should().HaveCount(2);
        // 3 cepillos, pagas 2
        recibo.ProductosDetalles[0].Should().Contain("Cepillo de dientes");
        recibo.ProductosDetalles[0].Should().Contain("0,99");
        recibo.ProductosDetalles[0].Should().Contain("3");
        // 10% de descuento en arroz
        recibo.ProductosDetalles[1].Should().Contain("Arroz");
        recibo.ProductosDetalles[1].Should().Contain("2,49");
        recibo.ProductosDetalles[1].Should().Contain("2");

        // totales
        recibo.Total.Should().Be(6.46m);
        recibo.TotalDescuentos.Should().Be(1.49m);
    }
}