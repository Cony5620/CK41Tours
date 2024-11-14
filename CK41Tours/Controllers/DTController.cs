using CK41Tours.Models.ViewModels;
using CK41Tours.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace CK41Tours.Controllers
{
    public class DTController : Controller
    {
        private readonly IDTService _DTService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DTController(IDTService DTService, IWebHostEnvironment webHostEnvironment)
        {
            this._DTService = DTService;
            this._webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Entry()
        {
            return View();
        }
        private string UploadedFile(DTViewModel DTViewModel)
        {
            string uniqueFileName = null;

            if (DTViewModel.photoimg != null)
            {
                
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                uniqueFileName = Guid.NewGuid().ToString() + "_" + DTViewModel.photoimg.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    DTViewModel.photoimg.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        [HttpPost]
        public IActionResult Entry(DTViewModel DTViewModel)
        {
            try
            {
                string uniqueFileName = UploadedFile(DTViewModel);
                DTViewModel.DT03 = uniqueFileName;
                _DTService.Create(DTViewModel, uniqueFileName);
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
        {    var DT=_DTService.GetAll();
            return View(DT);
        }
       public IActionResult Edit(string Id)
        {
            var DT = _DTService.GettBy(Id);
            return View(DT);
        }
        [HttpPost]
        public IActionResult Update(DTViewModel DTViewModel)
        {
            try
            {
                string uniqueFileName = UploadedFile(DTViewModel);
                DTViewModel.DT03 = uniqueFileName;
                _DTService.Update(DTViewModel, uniqueFileName);
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
                _DTService.Delete(Id);
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
