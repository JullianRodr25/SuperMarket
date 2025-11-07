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
        var total = Carrito.Calcular(productos);
        
        //Asert
        total.Should().Be("2.49m");
    }
}

public class Carrito
{
    public static object Calcular(object productos)
    {
        throw new NotImplementedException();
    }
}