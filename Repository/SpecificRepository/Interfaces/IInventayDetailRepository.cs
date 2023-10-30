using Context.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.GenericRepository.Interfaces;

namespace Repository.SpecificRepository.Interfaces
{
    public interface IInventayDetailRepository : IGenericRepository<InventaryDetail>
    {
        IEnumerable<SelectListItem> GetAllDropdownList(string obj);
    }
}
