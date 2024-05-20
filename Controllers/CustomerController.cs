using Microsoft.AspNetCore.Mvc;

namespace AlGallery.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
