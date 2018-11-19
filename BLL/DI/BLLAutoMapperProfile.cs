using AutoMapper;
using D = InventoryDAL.Entities;
using ND = Inventory.DAL.Contract.Models;
using B = BLL.Entities;

namespace BLL.DI
{
    public class BLLAutoMapperProfile : Profile
    {
        public BLLAutoMapperProfile()
        {
            #region Inventory
            CreateMap<D.InventoryBody, B.InventoryBody>()
                .ReverseMap();
            CreateMap<D.InventoryDate, B.InventoryDate>()
                .ReverseMap();
            CreateMap<D.InventoryHead, B.InventoryHead>()
                .ReverseMap();
            CreateMap<D.InventoryResult, B.InventoryResult>()
                .ReverseMap();


            CreateMap<ND.InventoryBody, B.InventoryBody>()
               .ReverseMap();
            CreateMap<ND.InventoryDate, B.InventoryDate>()
                .ReverseMap();
            CreateMap<ND.InventoryHead, B.InventoryHead>()
                .ReverseMap();
            CreateMap<ND.InventoryResult, B.InventoryResult>()
                .ReverseMap();
            #endregion

            CreateMap<D.Department, B.Department>()
                .ReverseMap();
            CreateMap<D.GoodGroup, B.GoodGroup>()
                .ReverseMap();
            CreateMap<D.Good, B.Good>()
                .ReverseMap();

        }
    }
}
