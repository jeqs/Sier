using System;
using System.Collections.Generic;

#nullable disable

namespace Sier.Core.Entities
{
    public partial class DetalleProducto
    {
        public int IdDetalleProducto { get; set; }
        public int? IdProducto { get; set; }
        public int? Cantidad { get; set; }
        public decimal? ValorTotal { get; set; }
        public decimal? ValorIva { get; set; }

        public virtual Producto IdProductoNavigation { get; set; }
    }
}
