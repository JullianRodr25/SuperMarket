namespace SuperMarket;

public class Carrito
{
    public static decimal Calcular(List<(string nombre, decimal precio, decimal unidad)> productos)
    {
        var subtotal = productos.Sum(p => p.precio * p.unidad);
        var descuentos = AplicaDescuentos(productos);
        return subtotal - descuentos;
    }

    private static decimal AplicaDescuentos(List<(string nombre, decimal precio, decimal unidad)> productos)
    {
        var cepillos = productos.FirstOrDefault(p => p.nombre == "Cepillo de dientes");

        if (cepillos.nombre != null && cepillos.unidad >= 3)
        {
            return 0.99m;
        }

        return 0m;
    }
}