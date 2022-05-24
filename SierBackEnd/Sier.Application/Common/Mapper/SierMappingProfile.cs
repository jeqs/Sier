using AutoMapper;
using Sier.Application.Common.Responses;
using Sier.Application.DetalleProducto.Commands;
using Sier.Application.Producto.Commands;

namespace Sier.Application.Common.Mapper
{
    public class SierMappingProfile : Profile
    {
        public SierMappingProfile()
        {
            CreateMap<Core.Entities.Producto, ProductoResponse>().ReverseMap();
            CreateMap<Core.Entities.Producto, CreateProductoCommand>().ReverseMap();
            CreateMap<Core.Entities.Producto, UpdateProductoCommand>().ReverseMap();

            CreateMap<Core.Entities.DetalleProducto, DetalleProductoResponse>().ReverseMap();
            CreateMap<Core.Entities.DetalleProducto, CreateDetalleProductoCommand>().ReverseMap();
            CreateMap<Core.Entities.DetalleProducto, UpdateDetalleProductoCommand>().ReverseMap();
        }
    }
}
