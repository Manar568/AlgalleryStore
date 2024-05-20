//using AlGallery.Models;
//using Microsoft.AspNetCore.Mvc;
//using System.Diagnostics;

//namespace AlGallery.Controllers
//{
//    public class HomeController : Controller
//    {
//        //private readonly ILogger<HomeController> _logger;

//        //public HomeController(ILogger<HomeController> logger)
//        //{
//        //    _logger = logger;
//        //}       

//        //public IActionResult Home()
//        //{
//        //    return View();
//        //}

//        public IActionResult About()
//        {
//            return View();
//        }

//        public IActionResult Collection()
//        {
//            return View();
//        }

//        public IActionResult Contact()
//        {
//            return View();
//        }

//        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//        public IActionResult Error()
//        {
//            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//        }
//    }
//}
using AlGallery.Data;
using AlGallery.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AlGallery.Controllers
{
    //public class HomeController : Controller
    //{
    //    private readonly ILogger<HomeController> _logger;

    //    public HomeController(ILogger<HomeController> logger)
    //    {
    //        _logger = logger;
    //    }       

    //    public IActionResult Home()
    //    {
    //        return View();
    //    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AlGalleryDBContext _context;

        public HomeController(ILogger<HomeController> logger, AlGalleryDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Home()
        {
            var popularProducts = _context.Products
                .OrderByDescending(p => p.Price) // Assuming Sales indicates popularity
                .Take(8) // Limiting to top 8 products
                .ToList();

            ViewBag.PopularProducts = popularProducts; // Store in ViewBag to pass to the view

            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Collection()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}