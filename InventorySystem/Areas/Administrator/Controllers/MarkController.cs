using BusinessLogic.Contracts;
using DataTransferObjets.Configuration;
using DataTransferObjets.Dto.In;
using DataTransferObjets.Dto.Out;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class MarkController : Controller
    {
        private readonly IMarkService service;

        public MarkController(IMarkService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            MarkResponse result = new();
            if (id is not null)
                result = await service.GetById(id.GetValueOrDefault());
            else
                result.State = true;
            return result is null ? NotFound() : View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(MarkRequest data, CancellationToken cancellationToken)
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
                TempData[StaticDefination.Successful] = resp ? $"Successfully {process} mark" : $"Error {process} mark";
                return RedirectToAction(nameof(Index));
            }
            TempData[StaticDefination.Error] = "Error when trying to save mark information";
            return View(data);
        }

        #region API
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<MarkResponse> result = await service.GetAll();
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
                message = !result ? "Error when trying to remove the Mark" : "Mark successfully deleted"
            });
        }

        [ActionName("ValidateNameId")]
        public async Task<IActionResult> ValidateNameId(string name, int id = 0)
        {
            return Json(new { data = await service.ValidateNameId(id, name) });
        }

        #endregion
    }
}
