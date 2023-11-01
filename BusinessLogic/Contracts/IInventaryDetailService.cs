using DataTransferObjets.Dto.In;
using DataTransferObjets.Dto.Out;
using DataTransferObjets.Dto.ViewModels;
using Microsoft.AspNetCore.Http;

namespace BusinessLogic.Contracts
{
    public interface IInventaryDetailService
    {
        #region CRUD
        public Task<bool> Add(ProductRequest requestDto, IFormFileCollection file, CancellationToken cancellationToken);
        public Task<bool> Delete(int id, CancellationToken cancellationToken);
        public Task<bool> Update(int id, ProductRequest requestDto, IFormFileCollection file, CancellationToken cancellationToken);
        public Task<IEnumerable<ProductResponse>> GetAll();
        public Task<ProductResponse> GetById(int id);
        #endregion

        public SelectListItemViewModel GetAllDropdownList();
    }
}
