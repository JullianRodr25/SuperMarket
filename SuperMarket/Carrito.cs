using Xunit.Sdk;

namespace SuperMarket;

public class Carrito
{
    
    private bool _descuentosActivados;
    
    public decimal Calcular(List<(string nombre, decimal precio, decimal unidad)> productos)
    {
        var subtotal = productos.Sum(p => p.precio * p.unidad);
        var descuento = AplicaDescuentos(productos);
        var total = subtotal - descuento;
        return Math.Round(total, 2);
    }

    private decimal AplicaDescuentos(List<(string nombre, decimal precio, decimal unidad)> productos)
    {
        decimal descuentoTotal = 0;
        var cepillos = productos.FirstOrDefault(p => p.nombre == "Cepillo de dientes");
        var manzanas = productos.FirstOrDefault(p => p.nombre == "Manzanas");
        var arroz = productos.FirstOrDefault(p => p.nombre == "Arroz");

        if (_descuentosActivados)
        {
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

            if (arroz.nombre == "Arroz")
            {
                descuentoTotal += 0.25m;
            }

            return descuentoTotal;
        }
        return 0;
    }

    public void AplicarDescuentosSemana()
    {
        _descuentosActivados = true;
    }
}