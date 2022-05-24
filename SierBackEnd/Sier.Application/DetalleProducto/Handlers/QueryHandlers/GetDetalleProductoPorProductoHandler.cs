using MediatR;
using Sier.Application.Common.Mapper;
using Sier.Application.Common.Responses;
using Sier.Application.DetalleProducto.Queries;
using Sier.Core.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sier.Application.DetalleProducto.Handlers.CommandHandlers
{
    public class GetDetalleProductoPorProductoHandler : IRequestHandler<GetDetalleProductoPorProductoQuery, DetalleProductoResponse>
    {
        private readonly IDetalleProductoRepository _detalleProductoRepository;

        public GetDetalleProductoPorProductoHandler(IDetalleProductoRepository detalleProductoRepository)
        {
            _detalleProductoRepository = detalleProductoRepository;
        }

        public async Task<DetalleProductoResponse> Handle(GetDetalleProductoPorProductoQuery request, CancellationToken cancellationToken)
        {
            // Obtener Detalle Producto
            var productoEntitiy = await _detalleProductoRepository.GetDetalleProductoPorProducto(request.IdProducto);
            if (productoEntitiy is null)
            {
                throw new ApplicationException("Detalle Producto no encontrado");
            }

            return SierMapper.Mapper.Map<DetalleProductoResponse>(productoEntitiy);
        }

    }
}
