using MediatR;
using Sier.Application.Common.Mapper;
using Sier.Application.Common.Responses;
using Sier.Application.DetalleProducto.Queries;
using Sier.Core.Repositories.Base;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sier.Application.DetalleProducto.Handlers.CommandHandlers
{
    public class GetDetalleProductoHandler : IRequestHandler<GetDetalleProductoQuery, DetalleProductoResponse>
    {
        private readonly IRepository<Core.Entities.DetalleProducto> _productoRepository;

        public GetDetalleProductoHandler(IRepository<Core.Entities.DetalleProducto> productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<DetalleProductoResponse> Handle(GetDetalleProductoQuery request, CancellationToken cancellationToken)
        {
            // Obtener Detalle Producto
            var productoEntitiy = await _productoRepository.GetByIdAsync(request.IdDetalleProducto);
            if (productoEntitiy is null)
            {
                throw new ApplicationException("Detalle Producto no encontrado");
            }

            return SierMapper.Mapper.Map<DetalleProductoResponse>(productoEntitiy);
        }

    }
}
