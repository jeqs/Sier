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
    public class CreateDetalleProductoHandler : IRequestHandler<CreateDetalleProductoCommand, DetalleProductoResponse>
    {
        private readonly IRepository<Core.Entities.DetalleProducto> _detalleProductoRepository;

        public CreateDetalleProductoHandler(IRepository<Core.Entities.DetalleProducto> detalleProductoRepository)
        {
            _detalleProductoRepository = detalleProductoRepository;
        }

        public async Task<DetalleProductoResponse> Handle(CreateDetalleProductoCommand request, CancellationToken cancellationToken)
        {
            // Mapeo de la entidad
            var detalleProductoEntitiy = SierMapper.Mapper.Map<Core.Entities.DetalleProducto>(request);
            if (detalleProductoEntitiy is null)
            {
                throw new ApplicationException("Error en el mapeo de la entidad");
            }

            // Agregar Detalle Producto
            var newDetalleProducto = await _detalleProductoRepository.AddAsync(detalleProductoEntitiy);
            return SierMapper.Mapper.Map<DetalleProductoResponse>(newDetalleProducto);
        }
    }
}
