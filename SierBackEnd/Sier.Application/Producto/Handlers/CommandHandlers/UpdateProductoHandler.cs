using MediatR;
using Sier.Application.Common.Mapper;
using Sier.Application.Common.Responses;
using Sier.Application.Producto.Commands;
using Sier.Core.Repositories.Base;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sier.Application.Producto.Handlers.CommandHandlers
{
    public class UpdateProductoHandler : IRequestHandler<UpdateProductoCommand, ProductoResponse>
    {
        private readonly IRepository<Core.Entities.Producto> _productoRepository;

        public UpdateProductoHandler(IRepository<Core.Entities.Producto> productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<ProductoResponse> Handle(UpdateProductoCommand request, CancellationToken cancellationToken)
        {
            // Obtener Producto
            var productoEntitiy = await _productoRepository.GetByIdAsync(request.Id);
            if (productoEntitiy is null)
            {
                throw new ApplicationException("Producto no encontrado");
            }

            // Mapeo de la entidad
            SierMapper.Mapper.Map(request, productoEntitiy);
            if (productoEntitiy is null)
            {
                throw new ApplicationException("Error en el mapeo de la entidad");
            }

            // Actualizar Producto
            await _productoRepository.UpdateAsync(productoEntitiy);
            return SierMapper.Mapper.Map<ProductoResponse>(productoEntitiy);
        }
    }
}
