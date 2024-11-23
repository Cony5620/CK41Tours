using CK41Tours.Models.ViewModels;
using CK41Tours.Services;
using Microsoft.AspNetCore.Mvc;

namespace CK41Tours.Controllers
{
    public class DDController : Controller
    {
        private readonly IDDService _dDService;
        private readonly IDTService _dTService;
        private readonly ITTService _tTService;
        private readonly ITMService _tMService;
        private readonly ITGService _tGService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DDController(IDDService dDService,
            IDTService dTService,
            ITTService tTService,
            ITMService tMService,
            ITGService tGService,
            IWebHostEnvironment webHostEnvironment)
        {
            this._dDService = dDService;
            this._dTService = dTService;
            this._tTService = tTService;
            this._tMService = tMService;
            this._tGService = tGService;
            this._webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Entry()
        {
            BindDTdata();
            BindTTdata();
            BindTMdata();
            BindTGdata();
            return View();
        }

        private void BindTGdata()
        {
            var TG = _tGService.GetTG();
            ViewBag.TGdata = TG;
        }

        private void BindTMdata()
        {
            var TM = _tMService.GetTM();
            ViewBag.TMdata = TM;
        }

        private void BindTTdata()
        {
            var TT = _tTService.GetTT();
            ViewBag.TTdata = TT;
        }

        private void BindDTdata()
        {
            var DT = _dTService.GetDT();
            ViewBag.DTdata = DT;
        }
        private string UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("No file uploaded or file is empty.");
            }

            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return uniqueFileName;
        }

        [HttpPost]
        public IActionResult Entry(DDViewModel dDViewModel)
        {
            try
            {
             
                string photoUrl = dDViewModel.photoimg != null
                    ? UploadFile(dDViewModel.photoimg)
                    : throw new Exception("Detail photo is required.");

                string gallery1Url = dDViewModel.gallery1 != null
                    ? UploadFile(dDViewModel.gallery1)
                    : null;

                string gallery2Url = dDViewModel.gallery2 != null
                    ? UploadFile(dDViewModel.gallery2)
                    : null;

             
                _dDService.Create(dDViewModel, photoUrl, gallery1Url, gallery2Url);

                ViewData["Info"] = "Successfully saved data to the system.";
                ViewData["status"] = true;
            }
            catch (Exception e)
            {
                ViewData["Info"] = "Error occurred while saving data to the system: " + e.Message;
                ViewData["status"] = false;
            }
            BindDTdata();
            BindTTdata();
            BindTMdata();
            BindTGdata();
            return View();
        }
        public IActionResult List()
        {    var DD=_dDService.GetAll();
             return View(DD);
        }
        public IActionResult Edit(string Id) 
        { var DD=_dDService.GettBy(Id);
            BindDTdata();
            BindTTdata();
            BindTMdata();
            BindTGdata();
            return View(DD);
        }
        public IActionResult Delete(string Id)
        {
            try
            {
                _dDService.Delete(Id);
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
        [HttpPost]
        public IActionResult Update(DDViewModel dDViewModel)
        {
            try
            {


                // Check if a photo image is provided; otherwise, keep it null for optional updates
                string photoUrl = dDViewModel.photoimg != null
                    ? UploadFile(dDViewModel.photoimg)
                    : null;

                // Handle optional gallery updates
                string gallery1Url = dDViewModel.gallery1 != null
                    ? UploadFile(dDViewModel.gallery1)
                    : null;

                string gallery2Url = dDViewModel.gallery2 != null
                    ? UploadFile(dDViewModel.gallery2)
                    : null;

                _dDService.Update(dDViewModel, photoUrl, gallery1Url, gallery2Url);

                ViewData["Info"] = "Successfully saved data to the system.";
                ViewData["status"] = true;
            }
            catch (Exception e)
            {
                ViewData["Info"] = "Error occurred while saving data to the system: " + e.Message;
                ViewData["status"] = false;
            }

            return RedirectToAction("List");
        }
    }
}

