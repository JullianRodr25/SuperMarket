namespace SuperMarket;

public class Descuentos
{
    public decimal CalcularDescuento(string nombreProducto, decimal precio, decimal unidad)
    {
        return nombreProducto switch
        {
            "Cepillo de dientes" => DescuentoCepillos(precio, unidad),
            "Manzanas" => DescuentoManzanas(precio, unidad),
            "Arroz" => DescuentoArroz(precio, unidad),
            "Pasta de dientes" => DescuentoPastaDental(precio, unidad),
            "Tomates cherry" => DescuentoTomates(precio, unidad),
            _ => 0
        };
    }

    private decimal DescuentoCepillos(decimal precio, decimal unidad)
    {
        if (unidad < 3) return 0;

        var unidadesGratis = (int)(unidad / 3);
        return unidadesGratis * precio;
    }

    private decimal DescuentoManzanas(decimal precio, decimal unidad)
    {
        var subtotal = precio * unidad;
        return subtotal * 0.20m;
    }

    private decimal DescuentoArroz(decimal precio, decimal unidad)
    {
        var subtotal = precio * unidad;
        return subtotal * 0.10m;
    }

    private decimal DescuentoPastaDental(decimal precio, decimal unidad)
    {
        if (unidad < 5) return 0;

        var paquetes = (int)(unidad / 5);
        var precioNormal = paquetes * 5 * precio;
        var precioPromocional = paquetes * 7.49m;
        return precioNormal - precioPromocional;
    }

    private decimal DescuentoTomates(decimal precio, decimal unidad)
    {
        if (unidad < 2) return 0;

        var paquetes = (int)(unidad / 2);
        var precioNormal = paquetes * 2 * precio;
        var precioPromocional = paquetes * 0.99m;
        return precioNormal - precioPromocional;
    }
}