using Sier.Application.Common.Responses;
using MediatR;

namespace Sier.Application.DetalleProducto.Queries
{
    public class GetDetalleProductoPorProductoQuery : IRequest<DetalleProductoResponse>
    {
        public int IdProducto { get; set; }
    }
}
