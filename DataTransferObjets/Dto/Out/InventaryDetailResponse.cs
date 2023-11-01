using DataTransferObjets.Dto.ViewModels;

namespace DataTransferObjets.Dto.Out
{
    public class InventaryDetailResponse : SelectListItemViewModelInventaryDetail
    {
        public int Id { get; set; }
        public int InventaryId { get; set; }
        //public string InventaryName { get; set; } = string.Empty;
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int StockPrevious { get; set; }
        public int Amount { get; set; }
    }
}
