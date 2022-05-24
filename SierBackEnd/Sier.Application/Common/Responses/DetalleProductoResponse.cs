namespace Sier.Application.Common.Responses
{
    public class DetalleProductoResponse
    {
        public int IdDetalleProducto { get; set; }
        public int? IdProducto { get; set; }
        public int? Cantidad { get; set; }
        public decimal? ValorTotal { get; set; }
        public decimal? ValorIva { get; set; }

    }
}
