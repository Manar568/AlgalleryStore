//using AlGallery.Data;
//using Microsoft.AspNetCore.Mvc;

//namespace AlGallery.Controllers


//{

//    public class CollectionController : Controller
//    {
//        private readonly ILogger<CollectionController> _logger;
//        private readonly AlGalleryDBContext _context;


//        public CollectionController(ILogger<CollectionController> logger, AlGalleryDBContext context)
//        {
//            _logger = logger;
//            _context = context;
//        }

//        public IActionResult Index()
//        {
//            var popularProducts = _context.Products
//                .OrderByDescending(p => p.Price) // Assuming Sales indicates popularity
//                .Take(8) // Limiting to top 8 products
//                .ToList();
//            var DropdownContent = _context.Categories.ToList();



//            ViewBag.PopularProducts = popularProducts;
//            // Store in ViewBag to pass to the view
//            ViewBag.DropdownContent = DropdownContent;

//            return View();
//        }





//    }
//}
using AlGallery.Data;
using AlGallery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AlGallery.Controllers
{
    public class CollectionController : Controller
    {
        private readonly ILogger<CollectionController> _logger;
        private readonly AlGalleryDBContext _context;

        public CollectionController(ILogger<CollectionController> logger, AlGalleryDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index(int? categoryId, string categoryName)
        {
            try
            {
                var productsQuery = _context.Products.AsQueryable();

                if (!string.IsNullOrEmpty(categoryName))
                {
                    var category = await _context.Categories
                        .FirstOrDefaultAsync(c => c.Name == categoryName);

                    if (category != null)
                    {
                        categoryId = category.Id;
                    }
                }

                if (categoryId.HasValue)
                {
                    productsQuery = productsQuery.Where(p => p.CategoryId == categoryId.Value);
                }

                var popularProducts = await productsQuery
                    .OrderByDescending(p => p.Price) // Assuming Price indicates popularity
                    .Take(8)
                    .ToListAsync();

                var dropdownContent = await _context.Categories.ToListAsync();

                ViewBag.PopularProducts = popularProducts;
                ViewBag.Categories = dropdownContent;

                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving data for the Index view.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

