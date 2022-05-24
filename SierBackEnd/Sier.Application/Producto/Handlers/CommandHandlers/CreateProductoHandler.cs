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
    public class CreateProductoHandler : IRequestHandler<CreateProductoCommand, ProductoResponse>
    {
        private readonly IRepository<Core.Entities.Producto> _productoRepository;

        public CreateProductoHandler(IRepository<Core.Entities.Producto> productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<ProductoResponse> Handle(CreateProductoCommand request, CancellationToken cancellationToken)
        {
            // Mapeo de la entidad
            var productoEntitiy = SierMapper.Mapper.Map<Core.Entities.Producto>(request);
            if (productoEntitiy is null)
            {
                throw new ApplicationException("Error en el mapeo de la entidad");
            }

            // Agregar Producto
            var newProducto = await _productoRepository.AddAsync(productoEntitiy);
            return SierMapper.Mapper.Map<ProductoResponse>(newProducto);
        }
    }
}
