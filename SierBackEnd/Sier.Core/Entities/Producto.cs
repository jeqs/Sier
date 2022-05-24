using System;
using System.Collections.Generic;

#nullable disable

namespace Sier.Core.Entities
{
    public partial class Producto
    {
        public Producto()
        {
            DetalleProductos = new HashSet<DetalleProducto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal? Precio { get; set; }

        public virtual ICollection<DetalleProducto> DetalleProductos { get; set; }
    }
}
