using DataTransferObjets.Dto.In;
using DataTransferObjets.Dto.Out;
using DataTransferObjets.Dto.ViewModels;
using Microsoft.AspNetCore.Http;

namespace BusinessLogic.Contracts
{
    public interface IInventaryDetailService
    {
        #region CRUD
        public Task<bool> Add(InventaryDetailRequest requestDto, CancellationToken cancellationToken);
        public Task<bool> Delete(int id, CancellationToken cancellationToken);
        public Task<bool> Update(int id, InventaryDetailRequest requestDto, CancellationToken cancellationToken);
        public Task<IEnumerable<InventaryDetailResponse>> GetAll();
        public Task<InventaryDetailResponse> GetById(int id);
        #endregion

        public SelectListItemViewModel GetAllDropdownList();
    }
}
