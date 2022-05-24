using Microsoft.EntityFrameworkCore;
using Sier.Core.Repositories;
using Sier.Infrastructure.Data;
using Sier.Infrastructure.Repositories.Base;
using System.Linq;
using System.Threading.Tasks;

namespace Sier.Infrastructure.Repositories
{
    public class DetalleProductoRepository : Repository<Core.Entities.DetalleProducto>, IDetalleProductoRepository
    {
        public DetalleProductoRepository(sierContext sierContext) : base(sierContext)
        {
        }

        // Custom Methods here
        public async Task<Core.Entities.DetalleProducto> GetDetalleProductoPorProducto(int idProducto)
        {
            return await _sierContext.DetalleProductos
                .Where(m => m.IdProducto == idProducto)
                .FirstOrDefaultAsync();
        }
    }
}
