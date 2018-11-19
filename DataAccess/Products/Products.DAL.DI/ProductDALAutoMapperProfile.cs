using AutoMapper;
using BaseModels = Products.DAL.Models;
using ContractModels = Products.DAL.Contract.Models;

namespace Products.DAL.DI
{
    public class ProductDALAutoMapperProfile : Profile
    {
        public ProductDALAutoMapperProfile()
        {
            CreateMap<BaseModels.Department, ContractModels.Department>()
                    .ReverseMap();
            CreateMap<BaseModels.ProductGroup, ContractModels.ProductGroup>()
                    .ReverseMap();
            CreateMap<BaseModels.Product, ContractModels.Product>()
                    .ReverseMap();
        }
    }
}
