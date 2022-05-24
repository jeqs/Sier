using Sier.Application.Common.Responses;
using MediatR;

namespace Sier.Application.Producto.Commands
{
    public class CreateProductoCommand : IRequest<ProductoResponse> 
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal? Precio { get; set; }
    }
}
