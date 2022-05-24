using Sier.Application.Common.Responses;
using MediatR;

namespace Sier.Application.DetalleProducto.Queries
{
    public class GetDetalleProductoQuery : IRequest<DetalleProductoResponse>
    {
        public int IdDetalleProducto { get; set; }
    }
}
