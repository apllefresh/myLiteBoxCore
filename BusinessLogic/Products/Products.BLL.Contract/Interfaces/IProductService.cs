using BL = Products.BLL.Contract.Models;
using DA = Products.DAL.Contract.Models;

namespace Products.BLL.Contract.Interfaces
{
    public interface IProductService : IBusinessLogicService<BL.Product, DA.Product>
    {
    }
}
