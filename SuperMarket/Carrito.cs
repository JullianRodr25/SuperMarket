using Xunit.Sdk;

namespace SuperMarket;

public class Carrito
{
    private bool _descuentosActivados;
    private readonly Descuentos _calculaDescuentos = new();

    public decimal Calcular(List<(string nombre, decimal precio, decimal unidad)> productos)
    {
        var subtotal = productos.Sum(p => p.precio * p.unidad);
        var descuento = AplicaDescuentos(productos);
        var total = subtotal - descuento;
        return Math.Round(total, 2);
    }

    private decimal AplicaDescuentos(List<(string nombre, decimal precio, decimal unidad)> productos)
    {
        if (!_descuentosActivados) return 0;

        decimal descuentoTotal = 0;

        foreach (var producto in productos)
        {
            descuentoTotal += _calculaDescuentos.CalcularDescuento(
                producto.nombre,
                producto.precio,
                producto.unidad
            );
        }

        return descuentoTotal;
    }

    public void AplicarDescuentosSemana()
    {
        _descuentosActivados = true;
    }

    public Recibo GenerarRecibo(List<(string nombre, decimal precio, decimal unidad)> productos)
    {
        var detalles = productos
            .Select(p => $"{p.nombre} - Precio: {p.precio:C} - Cantidad: {p.unidad}")
            .ToList();

        var total = Calcular(productos);

        return new Recibo
        {
            ProductosDetalles = detalles,
            Total = total,
            TotalDescuentos = 0m
        };
    }
}