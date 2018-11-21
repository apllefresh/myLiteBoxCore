using AutoMapper;
using Products.DAL.Contract.Interfaces;
using DA = Products.DAL.Contract.Models;
using BL = Products.BLL.Contract.Models;
using BLI = Products.BLL.Contract.Interfaces;

namespace Products.BLL.Services
{
    public class ProductGroupService : BusinessLogicService<BL.ProductGroup, DA.ProductGroup>, BLI.IProductGroupService
    {
        private IProductGroupRepository _repository;
        private IMapper _mapper;

        public ProductGroupService(IProductGroupRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
