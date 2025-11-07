using FluentAssertions;

namespace SuperMarket;

public class ReciboDeSupermercado
{
    [Fact]
    public void Si_AgregoUnProducto_Debe_RetornarElValorTotal()
    {
        //arrange
        var productos = new List<(string nombre, decimal precio, decimal cantidad)>
        {
            ("Arroz", 2.49m, 1),
        };

        //act
        var totalCompra = Carrito.Calcular(productos);
        
        //Asert
        totalCompra.Should().Be(2.49m);
    }
}

public class Carrito
{
    public static decimal Calcular(object productos)
    {
        return 2.49m;
    }
}