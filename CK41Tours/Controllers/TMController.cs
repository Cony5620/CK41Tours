using CK41Tours.Models.ViewModels;
using CK41Tours.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace CK41Tours.Controllers
{
    public class TMController : Controller
    {
        private readonly ITMService _TMService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TMController(ITMService TMService, IWebHostEnvironment webHostEnvironment)
        {
            this._TMService = TMService;
            this._webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Entry()
        {
            return View();
        }
        private string UploadedFile(TMViewModel TMViewModel)
        {
            string uniqueFileName = null;

            if (TMViewModel.photoimg != null)
            {
                
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                uniqueFileName = Guid.NewGuid().ToString() + "_" + TMViewModel.photoimg.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    TMViewModel.photoimg.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        [HttpPost]
        public IActionResult Entry(TMViewModel TMViewModel)
        {
            try
            {
                string uniqueFileName = UploadedFile(TMViewModel);
                TMViewModel.TM02 = uniqueFileName;
                _TMService.Create(TMViewModel, uniqueFileName);
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
        {    var TM=_TMService.GetAll();
            return View(TM);
        }
       public IActionResult Edit(string Id)
        {
            var TM = _TMService.GettBy(Id);
            return View(TM);
        }
        [HttpPost]
        public IActionResult Update(TMViewModel TMViewModel)
        {
            try
            {
                string uniqueFileName = UploadedFile(TMViewModel);
                TMViewModel.TM02 = uniqueFileName;
                _TMService.Update(TMViewModel, uniqueFileName);
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
                _TMService.Delete(Id);
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
