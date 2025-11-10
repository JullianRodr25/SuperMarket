using FluentAssertions;

namespace SuperMarket;

public class ReciboDeSupermercado
{
    [Fact]
    public void Si_AgregoUnProducto_Debe_RetornarElValorTotal()
    {
        //arrange
        var productos = new List<(string nombre, decimal precio, decimal unidad)>
        {
            ("Arroz", 2.49m, 1),
        };

        //act
        var totalCompra = Carrito.Calcular(productos);

        //Asert
        totalCompra.Should().Be(2.49m);
    }

    [Fact]
    public void
        Si_AgregoDosProductosCon1Unidad_Debe_RetornarElValorTotalSi_AgregoDosProductosCon1Unidad_Debe_RetornarElValorTotal()
    {
        //arrange
        var productos = new List<(string nombre, decimal precio, decimal unidad)>
        {
            ("Arroz", 2.49m, 1),
            ("Leche", 1.99m, 1),
        };

        //act
        var totalCompra = Carrito.Calcular(productos);

        //Asert
        totalCompra.Should().Be(4.48m);
    }

    [Theory]
    [InlineData("Arroz", 2.49, 2, 4.98)]
    [InlineData("Leche", 1.99, 5, 9.95)]
    public void Si_AgregoProductosConMasDe1Unidad_Debe_RetornarElValorTotal(
        string nombre,
        decimal precio,
        decimal unidad,
        decimal esperado)
    {
        // Arrange
        var productos = new List<(string nombre, decimal precio, decimal unidad)>
        {
            (nombre, precio, unidad)
        };

        // Act
        var totalCompra = Carrito.Calcular(productos);

        // Assert
        totalCompra.Should().Be(esperado);
    }
    
    [Fact]
    public void Si_Agrego3UnidadesDeCepillosDeDientes_Debe_RetornarELValorTotalAplicandoElDescuento()
    {
        //arrange
        var productos = new List<(string nombre, decimal precio, decimal unidad)>
        {
            ("Cepillo de dientes", 0.99m, 3),
        };

        //act
        var totalCompra = Carrito.Calcular(productos);

        //Asert
        totalCompra.Should().Be(1.98m);
    }
    
    [Fact]
    public void Si_Agrego6UnidadesDeCepillosDeDientes_Debe_RetornarELValorTotalAplicandoElDescuento()
    {
        //arrange
        var productos = new List<(string nombre, decimal precio, decimal unidad)>
        {
            ("Cepillo de dientes", 0.99m, 6),
        };

        //act
        var totalCompra = Carrito.Calcular(productos);

        //Assert
        totalCompra.Should().Be(3.96m);
    }
    
    [Fact]
    public void Si_Agrego1KiloDeManzanas_Debe_Aplicar20PorCientoDescuento()
    {
        //arrange
        var productos = new List<(string nombre, decimal precio, decimal unidad)>
        {
            ("Manzanas", 1.99m, 1),
        };

        //act
        var totalCompra = Carrito.Calcular(productos);

        //Assert
        totalCompra.Should().Be(1.59m);
    }
    
}