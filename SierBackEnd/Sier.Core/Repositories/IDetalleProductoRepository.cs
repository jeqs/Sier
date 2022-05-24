using Sier.Core.Repositories.Base;
using System.Threading.Tasks;

namespace Sier.Core.Repositories
{
    public interface IDetalleProductoRepository : IRepository<Entities.DetalleProducto>
    {
        //custom operations
        Task<Core.Entities.DetalleProducto> GetDetalleProductoPorProducto(int idProducto);
    }
}
