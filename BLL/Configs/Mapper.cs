using AutoMapper;
using EPAM_entity.Entities;

namespace EPAM_entity.Configs
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<Product, ProductDTO>();
            CreateMap<Supplier, SupplierDTO>();
        }
    }
}