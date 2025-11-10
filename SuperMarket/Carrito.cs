namespace SuperMarket;

public class Carrito
{
    public static decimal Calcular(List<(string nombre, decimal precio, decimal unidad)> productos)
    {
        var subtotal = productos.Sum(p => p.precio * p.unidad);
        var descuento = AplicaDescuentos(productos);
        var total = subtotal - descuento;
        return Math.Round(total, 2);
    }

    private static decimal AplicaDescuentos(List<(string nombre, decimal precio, decimal unidad)> productos)
    {
        decimal descuentoTotal = 0;
        var cepillos = productos.FirstOrDefault(p => p.nombre == "Cepillo de dientes");
        var manzanas = productos.FirstOrDefault(p => p.nombre == "Manzanas");

        if (cepillos.nombre == "Cepillo de dientes" && cepillos.unidad >= 3)
        {
            var unidadesGratis = (int)(cepillos.unidad / 3);
            descuentoTotal += unidadesGratis * cepillos.precio;
        }

        if (manzanas.nombre == "Manzanas")
        {
            var subtotalManzanas = manzanas.precio * manzanas.unidad;
            var descuentoManzanas = subtotalManzanas * 0.20m;
            descuentoTotal += descuentoManzanas;
        }

        return descuentoTotal;
    }
}