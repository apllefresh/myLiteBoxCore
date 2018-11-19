using AutoMapper;
using BaseModels = Inventory.DAL.Models;
using ContractModels = Inventory.DAL.Contract.Models;

namespace DAL.DI
{
    public class InventoryDALAutoMapperProfile : Profile
    {
        public InventoryDALAutoMapperProfile()
        {
            CreateMap<BaseModels.InventoryDate, ContractModels.InventoryDate>()
                    .ReverseMap();
            CreateMap<BaseModels.InventoryHead, ContractModels.InventoryHead>()
                    .ReverseMap();
            CreateMap<BaseModels.InventoryBody, ContractModels.InventoryBody>()
                    .ReverseMap();
            CreateMap<BaseModels.InventoryResult, ContractModels.InventoryResult>()
                    .ReverseMap();
            CreateMap<BaseModels.InventorySpace, ContractModels.InventorySpace>()
                    .ReverseMap();
            CreateMap<BaseModels.InventoryDateToSpaceMap, ContractModels.InventoryDateToSpaceMap>()
                    .ReverseMap();
        }
    }
}
