namespace SuperMarket;

public class Recibo
{
    public List<string> ProductosDetalles { get; set; } = new();
    public decimal Total { get; set; }
    public decimal TotalDescuentos { get; set; }
}