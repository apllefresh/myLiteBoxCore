using AutoMapper;
using BLBaseModels = Inventory.BLL.Models;
using BLContractModels = Inventory.BLL.Contract.Models;
using BLContractInterfaces = Inventory.BLL.Contract.Interfaces;
using DAContractModels = Inventory.DAL.Contract.Models;

namespace Inventory.BLL.DI
{
    public class InventoryBLLAutoMapperProfile : Profile
    {
        public InventoryBLLAutoMapperProfile()
        {
            CreateMap<DAContractModels.InventoryBody, BLContractModels.InventoryBody>()
                .ReverseMap();
            CreateMap<DAContractModels.InventoryDate, BLContractModels.InventoryDate>()
                .ReverseMap();
            CreateMap<DAContractModels.InventoryHead, BLContractModels.InventoryHead>()
                .ReverseMap();
            CreateMap<DAContractModels.InventoryResult, BLContractModels.InventoryResult>()
                .ReverseMap();
            CreateMap<DAContractModels.InventorySpace, BLContractModels.InventorySpace>()
                .ReverseMap();
            CreateMap<DAContractModels.InventoryDateToSpaceMap, BLContractModels.InventoryDateToSpaceMap>()
                .ReverseMap();


            CreateMap<BLBaseModels.InventoryBody, BLContractModels.InventoryBody>()
                .ReverseMap();
            CreateMap<BLBaseModels.InventoryDate, BLContractModels.InventoryDate>()
                .ReverseMap();
            CreateMap<BLBaseModels.InventoryHead, BLContractModels.InventoryHead>()
                .ReverseMap();
            CreateMap<BLBaseModels.InventoryResult, BLContractModels.InventoryResult>()
                .ReverseMap();
            CreateMap<BLBaseModels.InventorySpace, BLContractModels.InventorySpace>()
                .ReverseMap();
            CreateMap<BLBaseModels.InventoryDateToSpaceMap, BLContractModels.InventoryDateToSpaceMap>()
                .ReverseMap();


            CreateMap<BLBaseModels.InventoryBody, DAContractModels.InventoryBody>()
                .ReverseMap();
            CreateMap<BLBaseModels.InventoryDate, DAContractModels.InventoryDate>()
                .ReverseMap();
            CreateMap<BLBaseModels.InventoryHead, DAContractModels.InventoryHead>()
                .ReverseMap();
            CreateMap<BLBaseModels.InventoryResult, DAContractModels.InventoryResult>()
                .ReverseMap();
            CreateMap<BLBaseModels.InventorySpace, DAContractModels.InventorySpace>()
                .ReverseMap();
            CreateMap<BLBaseModels.InventoryDateToSpaceMap, DAContractModels.InventoryDateToSpaceMap>()
                .ReverseMap();
        }
    }
}
