using AutoMapper;
using Products.DAL.Contract.Interfaces;
using DA = Products.DAL.Contract.Models;
using BL = Products.BLL.Contract.Models;
using BLI = Products.BLL.Contract.Interfaces;

namespace Products.BLL.Services
{
    public class DepartmentService : BusinessLogicService<BL.Department, DA.Department>, BLI.IDepartmentService
    {
        private IDepartmentRepository _repository;
        private IMapper _mapper;

        public DepartmentService(IDepartmentRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
