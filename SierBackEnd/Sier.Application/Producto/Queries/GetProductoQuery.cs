using Sier.Application.Common.Responses;
using MediatR;

namespace Sier.Application.Producto.Queries
{
    public class GetProductoQuery : IRequest<ProductoResponse>
    {
        public int ProductoId { get; set; }
    }
}
