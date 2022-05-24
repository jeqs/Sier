using Sier.Application.Common.Responses;
using MediatR;

namespace Sier.Application.Producto.Commands
{
    public class UpdateProductoCommand : IRequest<ProductoResponse> 
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal? Precio { get; set; }
    }
}
