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
    public void Si_AgregoDosProductosCon1Unidad_Debe_RetornarElValorTotalSi_AgregoDosProductosCon1Unidad_Debe_RetornarElValorTotal()
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
    
    [Fact]
    public void Si_AgregoUnProductoCon2Unidades_Debe_RetornarElValorTotal()
    {
        //arrange
        var productos = new List<(string nombre, decimal precio, decimal unidad)>
        {
            ("Arroz", 2.49m, 2),
        };

        //act
        var totalCompra = Carrito.Calcular(productos);
        
        //Asert
        totalCompra.Should().Be(4.98m);
    }
    
}

public class Carrito
{
    public static decimal Calcular(List<(string nombre, decimal precio, decimal unidad)> productos)
    {
        return productos.Sum(p => p.precio);

    }
}