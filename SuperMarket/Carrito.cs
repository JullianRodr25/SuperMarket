namespace SuperMarket;

public class Carrito
{
    public static decimal Calcular(List<(string nombre, decimal precio, decimal unidad)> productos)
    {
        return productos.Sum(p => p.precio * p.unidad);

    }
}