using MediatR;
using Sier.Application.Common.Mapper;
using Sier.Application.Common.Responses;
using Sier.Application.Producto.Queries;
using Sier.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sier.Application.Producto.Handlers.CommandHandlers
{
    public class GetAllProductoHandler : IRequestHandler<GetAllProductoQuery, List<ProductoResponse>>
    {
        private readonly IRepository<Core.Entities.Producto> _productoRepository;

        public GetAllProductoHandler(IRepository<Core.Entities.Producto> productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<List<ProductoResponse>> Handle(GetAllProductoQuery request, CancellationToken cancellationToken)
        {
            // Obtener Productos
            var productoEntitiy = await _productoRepository.GetAllAsync();
            if (productoEntitiy is null)
            {
                throw new ApplicationException("Productos no encontrados");
            }

            return SierMapper.Mapper.Map<List<ProductoResponse>>(productoEntitiy);
        }

    }
}
