namespace SuperMarket;

public class Recibo
{
    public List<string> ProductosDetalles { get; set; }
    public decimal Total { get; set; }
    public decimal TotalDescuentos { get; set; }
}