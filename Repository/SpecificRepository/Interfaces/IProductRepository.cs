using Context.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.GenericRepository.Interfaces;

namespace Repository.SpecificRepository.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IEnumerable<SelectListItem> GetAllDropdownList(string obj);
    }
}
