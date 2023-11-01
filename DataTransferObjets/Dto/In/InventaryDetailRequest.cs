using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjets.Dto.In
{
    public class InventaryDetailRequest
    {
        public int Id { get; set; }
        public int InventaryId { get; set; }
        //public string InventaryName { get; set; } = string.Empty;
        public int ProductId { get; set; }
        //public string ProductName { get; set; } = string.Empty;
        public int StockPrevious { get; set; }
        public int Amount { get; set; }
    }
}
