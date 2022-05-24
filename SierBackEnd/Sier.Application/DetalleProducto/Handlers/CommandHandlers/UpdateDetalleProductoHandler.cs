using MediatR;
using Sier.Application.Common.Mapper;
using Sier.Application.Common.Responses;
using Sier.Application.DetalleProducto.Commands;
using Sier.Core.Repositories.Base;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sier.Application.DetalleProducto.Handlers.CommandHandlers
{
    public class UpdateDetalleProductoHandler : IRequestHandler<UpdateDetalleProductoCommand, DetalleProductoResponse>
    {
        private readonly IRepository<Core.Entities.DetalleProducto> _detalleProductoRepository;

        public UpdateDetalleProductoHandler(IRepository<Core.Entities.DetalleProducto> detalleProductoRepository)
        {
            _detalleProductoRepository = detalleProductoRepository;
        }

        public async Task<DetalleProductoResponse> Handle(UpdateDetalleProductoCommand request, CancellationToken cancellationToken)
        {
            // Obtener Producto
            var detalleProductoEntitiy = await _detalleProductoRepository.GetByIdAsync(request.IdDetalleProducto);
            if (detalleProductoEntitiy is null)
            {
                throw new ApplicationException("Detalle Producto no encontrado");
            }

            // Mapeo de la entidad
            SierMapper.Mapper.Map(request, detalleProductoEntitiy);
            if (detalleProductoEntitiy is null)
            {
                throw new ApplicationException("Error en el mapeo de la entidad");
            }

            // Actualizar Producto
            await _detalleProductoRepository.UpdateAsync(detalleProductoEntitiy);
            return SierMapper.Mapper.Map<DetalleProductoResponse>(detalleProductoEntitiy);
        }
    }
}
