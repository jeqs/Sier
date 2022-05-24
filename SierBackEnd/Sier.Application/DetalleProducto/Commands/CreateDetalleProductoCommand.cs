using Sier.Application.Common.Responses;
using MediatR;

namespace Sier.Application.DetalleProducto.Commands
{
    public class CreateDetalleProductoCommand : IRequest<DetalleProductoResponse> 
    {
        public int? IdProducto { get; set; }
        public int? Cantidad { get; set; }
        public decimal? ValorTotal { get; set; }
        public decimal? ValorIva { get; set; }
    }
}
