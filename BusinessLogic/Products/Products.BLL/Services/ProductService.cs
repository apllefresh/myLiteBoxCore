using AutoMapper;
using Products.DAL.Contract.Interfaces;
using DA = Products.DAL.Contract.Models;
using BL = Products.BLL.Contract.Models;
using BLI = Products.BLL.Contract.Interfaces;

namespace Products.BLL.Services
{
    public class ProductService : BusinessLogicService<BL.Product, DA.Product>, BLI.IProductService
    {
        private IProductRepository _repository;
        private IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
