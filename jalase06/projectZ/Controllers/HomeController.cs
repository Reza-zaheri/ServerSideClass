using Microsoft.AspNetCore.Mvc;
using projectZ.Models;
using System.Diagnostics;
using System.Globalization;

namespace projectZ.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context db;
        private readonly ILogger<HomeController> _logger;
        //string kol = default;

        public HomeController(ILogger<HomeController> logger,Context context)
        {
            db= context; 
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SaveUser(Users obj)
        {
            PersianCalendar pc = new PersianCalendar();
            var value =obj.Birthday.ToString();
            obj.Birthdaysh = value;
            // Convert to Miladi
            DateTime dt = DateTime.Parse(value, new CultureInfo("fa-IR"));
            obj.Birthday= dt;
            db.Userss.Add(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Store(Users userss)
        {
            var p = db.Userss.ToList();
            return View(p);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}