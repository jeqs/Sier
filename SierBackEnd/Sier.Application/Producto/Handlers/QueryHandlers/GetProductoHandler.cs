using MediatR;
using Sier.Application.Common.Mapper;
using Sier.Application.Common.Responses;
using Sier.Application.Producto.Queries;
using Sier.Core.Repositories.Base;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sier.Application.Producto.Handlers.CommandHandlers
{
    public class GetProductoHandler : IRequestHandler<GetProductoQuery, ProductoResponse>
    {
        private readonly IRepository<Core.Entities.Producto> _productoRepository;

        public GetProductoHandler(IRepository<Core.Entities.Producto> productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<ProductoResponse> Handle(GetProductoQuery request, CancellationToken cancellationToken)
        {
            // Obtener Producto
            var productoEntitiy = await _productoRepository.GetByIdAsync(request.ProductoId);
            if (productoEntitiy is null)
            {
                throw new ApplicationException("Producto no encontrado");
            }

            return SierMapper.Mapper.Map<ProductoResponse>(productoEntitiy);
        }

    }
}
