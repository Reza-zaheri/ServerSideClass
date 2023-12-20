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
        string kol = default;

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
            // Convert to Miladi
            DateTime dt = DateTime.Parse(value, new CultureInfo("fa-IR"));
            obj.Birthday= dt;
            db.Userss.Add(obj);
            db.SaveChanges();
            return RedirectToAction("index");
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
            PersianCalendar pc = new PersianCalendar();
                var s = db.Userss.Select(x => x.Birthday.ToString()).ToList();

                DateTime dt = DateTime.Parse(s[0], new CultureInfo("en"));
                int y = pc.GetYear(dt);

                int m = pc.GetMonth(dt);

                int d = pc.GetDayOfMonth(dt);

                ViewBag.persianDate = string.Format("{0}/{1}/{2}", y, m, d);

            var p = db.Userss.Where(x=>x.Name!=null).ToList();
            return View(p);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}