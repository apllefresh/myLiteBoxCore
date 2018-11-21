using AutoMapper;
using BLBaseModels = Products.BLL.Models;
using BLContractModels = Products.BLL.Contract.Models;
using BLContractInterfaces = Products.BLL.Contract.Interfaces;
using DAContractModels = Products.DAL.Contract.Models;

namespace Products.BLL.DI
{
    public class ProductBLLAutoMapperProfile : Profile
    {
        public ProductBLLAutoMapperProfile()
        {
            CreateMap<DAContractModels.Department, BLContractModels.Department>()
                .ReverseMap();
            CreateMap<DAContractModels.ProductGroup, BLContractModels.ProductGroup>()
                .ReverseMap();
            CreateMap<DAContractModels.Product, BLContractModels.Product>()
                .ReverseMap();
            

            CreateMap<BLBaseModels.Department, BLContractModels.Department>()
                .ReverseMap();
            CreateMap<BLBaseModels.ProductGroup, BLContractModels.ProductGroup>()
                .ReverseMap();
            CreateMap<BLBaseModels.Product, BLContractModels.Product>()
                .ReverseMap();
            

            CreateMap<BLBaseModels.Department, DAContractModels.Department>()
                .ReverseMap();
            CreateMap<BLBaseModels.ProductGroup, DAContractModels.ProductGroup>()
                .ReverseMap();
            CreateMap<BLBaseModels.Product, DAContractModels.Product>()
                .ReverseMap();
        }
    }
}
