using Context.Data;
using Context.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.GenericRepository.Implentations;
using Repository.SpecificRepository.Interfaces;

namespace Repository.SpecificRepository.Implentations
{
    public class InventayDetailRepository : GenericRepository<InventaryDetail>, IInventayDetailRepository
    {
        private readonly ApplicationDbContext context;

        public InventayDetailRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<SelectListItem> GetAllDropdownList(string obj)
        {
            if (obj == "Product")
            {
                return context.Products.Where(c => c.State).Select(c => new SelectListItem
                {
                    Text = c.Description,
                    Value = c.Id.ToString()
                });
            }
            return default;
        }
    }
}
