using Sier.Application.Common.Responses;
using MediatR;
using System.Collections.Generic;

namespace Sier.Application.Producto.Queries
{
    public class GetAllProductoQuery : IRequest<List<ProductoResponse>>
    {
    }
}
