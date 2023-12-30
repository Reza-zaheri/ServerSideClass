using Microsoft.AspNetCore.Mvc;
using projectZ.Models;

namespace projectZ.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AAController : Controller
    {
        private readonly Context db;
        private readonly ILogger<AAController> _logger;
        private readonly IWebHostEnvironment WebHostEnvironment;
        public AAController(ILogger<AAController> logger, Context context,IWebHostEnvironment WebHostEnvironment)
        {
            db = context;
            _logger = logger;
            this.WebHostEnvironment=WebHostEnvironment;
        }
        public IActionResult Index()
        {
            var query = db.Productss.ToList();
            return View(query);
        }
        public IActionResult SaveP(Products obj)
        {
            #region Upload
            string UniqueFileName ="images/"+Guid.NewGuid()+obj.image.FileName;
            string UploadFolder = Path.Combine(WebHostEnvironment.WebRootPath, UniqueFileName);
            using(FileStream fs = new FileStream(UploadFolder, FileMode.Create))
            {
                obj.image.CopyTo(fs);
            }
            #endregion
            #region saveDB
            obj.imagepath = UniqueFileName;
            db.Productss.Add(obj);
            db.SaveChanges(); 
            #endregion
            return RedirectToAction("Index");
        }
        public IActionResult PForm()
        {
            return View();
        }
    }
}
