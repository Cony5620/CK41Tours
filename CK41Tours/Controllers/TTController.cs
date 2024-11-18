using CK41Tours.Models.ViewModels;
using CK41Tours.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
//ammt 20241118
namespace CK41Tours.Controllers
{
    public class TTController : Controller
    {
        private readonly ITTService _TTService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TTController(ITTService TTService, IWebHostEnvironment webHostEnvironment)
        {
            this._TTService = TTService;
            this._webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Entry()
        {
            return View();
        }
        private string UploadedFile(TTViewModel TTViewModel)
        {
            string uniqueFileName = null;

            if (TTViewModel.photoimg != null)
            {
                
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                uniqueFileName = Guid.NewGuid().ToString() + "_" + TTViewModel.photoimg.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    TTViewModel.photoimg.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        [HttpPost]
        public IActionResult Entry(TTViewModel TTViewModel)
        {
            try
            {
                string uniqueFileName = UploadedFile(TTViewModel);
                TTViewModel.TT03 = uniqueFileName;
                _TTService.Create(TTViewModel, uniqueFileName);
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
        {    var TT=_TTService.GetAll();
            return View(TT);
        }
       public IActionResult Edit(string Id)
        {
            var TT = _TTService.GetBy(Id);
            return View(TT);
        }
        [HttpPost]
        public IActionResult Update(TTViewModel TTViewModel)
        {
            try
            {
                string uniqueFileName = UploadedFile(TTViewModel);
                TTViewModel.TT03 = uniqueFileName;
                _TTService.Update(TTViewModel, uniqueFileName);
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
                _TTService.Delete(Id);
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
