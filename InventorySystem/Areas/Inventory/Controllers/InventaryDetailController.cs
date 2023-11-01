using BusinessLogic.Contracts;
using DataTransferObjets.Configuration;
using DataTransferObjets.Dto.In;
using DataTransferObjets.Dto.Out;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Areas.Inventory.Controllers
{
    [Area("Inventory")]
    public class InventaryDetailController : Controller
    {
        private readonly IInventaryDetailService service;

        public InventaryDetailController(IInventaryDetailService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            bool ResultState = false;
            InventaryDetailResponse result = new();
            if (id is not null)
                result = await service.GetById(id.GetValueOrDefault());
            else
                ResultState = true;
            return ResultState ? NotFound() : View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(InventaryDetailRequest data, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                bool resp = false;
                string process = "";
                if (data.Id == 0)
                {
                    resp = await service.Add(data, cancellationToken);
                    process = "created";
                }
                else
                {
                    resp = await service.Update(data.Id, data, cancellationToken);
                    process = "updated";
                }
                TempData[StaticDefination.Successful] = resp ? $"Successfully {process} mark" : $"Error {process} InventaryDetail";
                return RedirectToAction(nameof(Index));
            }
            TempData[StaticDefination.Error] = "Error when trying to save InventaryDetail information";
            return View(data);
        }

        #region API
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<InventaryDetailResponse> result = await service.GetAll();
            return Json(new { data = result });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int? id, CancellationToken cancellationToken)
        {
            bool result = false;
            if (id is not null)
                result = await service.Delete(id.GetValueOrDefault(), cancellationToken);
            return Json(new
            {
                success = result,
                message = !result ? "Error when trying to remove the InventaryDetail" : "InventaryDetail successfully deleted"
            });
        }
        #endregion
    }
}
