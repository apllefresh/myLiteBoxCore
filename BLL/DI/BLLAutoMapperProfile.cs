using AutoMapper;
using D = DAL.Entities;
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
            #endregion

            CreateMap<D.Department, B.Department>()
                .ReverseMap();
            CreateMap<D.Good, B.Good>()
                .ReverseMap();

        }
    }
}
