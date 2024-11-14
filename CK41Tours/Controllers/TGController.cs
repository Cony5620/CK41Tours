using CK41Tours.Models.ViewModels;
using CK41Tours.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace CK41Tours.Controllers
{
    public class TGController : Controller
    {
        private readonly ITGService _tGService;

        public TGController(ITGService tGService)
        {
            this._tGService = tGService;
        }
        public IActionResult Entry()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Entry(TGViewModel tGViewModel)
        {
            try
            {
                _tGService.Create(tGViewModel);
                ViewData["Info"] = "Successfully save data to the system";
                ViewData["status"] = true;
            }
            catch (Exception e)
            {

                ViewData["Info"] = "Error occur when saving data to the system"+e.Message;
                ViewData["status"] = false;
            }
            return View();
        }
        public IActionResult List()
        {    var tG=_tGService.GetAll();
            return View(tG);
        }
       public IActionResult Edit(string Id)
        {
            var tG = _tGService.GettBy(Id);
            return View(tG);
        }
        [HttpPost]
        public IActionResult Update(TGViewModel tGViewModel)
        {
            try
            {
                _tGService.Update(tGViewModel);
                TempData["Info"] = "Successfully update data to the system";
                TempData["status"] = true;
            }
            catch (Exception e)
            {

                TempData["Info"] = "Error occur when updating data to the system" + e.Message;
                TempData["status"] = false;
            }
            return RedirectToAction("List");
        }
        public IActionResult Delete(string Id)
        {
            try
            {
                _tGService.Delete(Id);
                TempData["Info"] = "Successfully delete data to the system";
                TempData["status"] = true;
            }
            catch (Exception e)
            {

                TempData["Info"] = "Error occur when deleting data to the system" + e.Message;
                TempData["status"] = false;
            }
            return RedirectToAction("List");
        }

    }
}
