namespace SuperMarket;

public class Descuentos
{
    public decimal CalcularDescuento(string nombreProducto, decimal precio, decimal unidad)
    {
        return nombreProducto switch
        {
            "Cepillo de dientes" => CalcularDescuentoCepillos(precio, unidad),
            "Manzanas" => CalcularDescuentoManzanas(precio, unidad),
            "Arroz" => CalcularDescuentoArroz(precio, unidad),
            "Pasta de dientes" => CalcularDescuentoPastaDental(precio, unidad),
            "Tomates cherry" => CalcularDescuentoTomates(precio, unidad),
            _ => 0
        };
    }

    private decimal CalcularDescuentoCepillos(decimal precio, decimal unidad)
    {
        if (unidad < 3) return 0;

        var unidadesGratis = (int)(unidad / 3);
        return unidadesGratis * precio;
    }

    private decimal CalcularDescuentoManzanas(decimal precio, decimal unidad)
    {
        var subtotal = precio * unidad;
        return subtotal * 0.20m;
    }

    private decimal CalcularDescuentoArroz(decimal precio, decimal unidad)
    {
        var subtotal = precio * unidad;
        return subtotal * 0.10m;
    }

    private decimal CalcularDescuentoPastaDental(decimal precio, decimal unidad)
    {
        if (unidad < 5) return 0;

        var paquetes = (int)(unidad / 5);
        var precioNormal = paquetes * 5 * precio;
        var precioPromocional = paquetes * 7.49m;
        return precioNormal - precioPromocional;
    }

    private decimal CalcularDescuentoTomates(decimal precio, decimal unidad)
    {
        if (unidad < 2) return 0;

        var paquetes = (int)(unidad / 2);
        var precioNormal = paquetes * 2 * precio;
        var precioPromocional = paquetes * 0.99m;
        return precioNormal - precioPromocional;
    }
}