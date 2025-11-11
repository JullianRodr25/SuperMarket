using Xunit.Sdk;

namespace SuperMarket;

public class Carrito
{
    private bool _descuentosActivados;
    private readonly Descuentos _calculaDescuentos = new();

    public decimal Calcular(List<(string nombre, decimal precio, decimal unidad)> productos)
    {
        var (total, _) = CalcularTotales(productos);
        return total;
    }

    public Recibo GenerarRecibo(List<(string nombre, decimal precio, decimal unidad)> productos)
    {
        var detalles = productos
            .Select(p => $"{p.nombre} - Precio: {p.precio:C} - Cantidad: {p.unidad}")
            .ToList();

        var (total, descuentos) = CalcularTotales(productos);

        return new Recibo
        {
            ProductosDetalles = detalles,
            Total = total,
            TotalDescuentos = descuentos
        };
    }

    private (decimal total, decimal descuentos) CalcularTotales(
        List<(string nombre, decimal precio, decimal unidad)> productos)
    {
        var subtotal = productos.Sum(p => p.precio * p.unidad);
        var descuentos = AplicaDescuentos(productos);
        var total = subtotal - descuentos;

        return (Math.Round(total, 2), Math.Round(descuentos, 2));
    }

    private decimal AplicaDescuentos(List<(string nombre, decimal precio, decimal unidad)> productos)
    {
        if (!_descuentosActivados) return 0;
        return productos.Sum(producto => _calculaDescuentos.CalcularDescuento(producto.nombre, producto.precio, producto.unidad));
    }

    public void AplicarDescuentosSemana()
    {
        _descuentosActivados = true;
    }
}