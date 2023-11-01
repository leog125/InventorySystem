using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjets.Dto.ViewModels
{
    public class SelectListItemViewModelInventaryDetail
    {
        public IEnumerable<SelectListItem> InventaryDropDownList { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> ProductDropDownList { get; set; } = new List<SelectListItem>();
    }
}
