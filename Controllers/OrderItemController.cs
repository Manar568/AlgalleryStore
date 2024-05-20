using AlGallery.Interfaces;
using AlGallery.Models;
using AlGallery.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AlGallery.Controllers
{
    public class OrderItemController : Controller
    {
        private IOrderItemRepo context;
        private ICartItemRepo cartItemRepo;
        public OrderItemController(IOrderItemRepo context, ICartItemRepo cartItemRepo)
        {
            this.context = context;
            this.cartItemRepo = cartItemRepo;
        }
        public IActionResult Index()
        {
            List<OrderItems> orderItems = context.GetAll();
            return View(orderItems);
        }

        public IActionResult AddOrderItem()
        {
            List<CartItems> cartItems = cartItemRepo.GetCartItemsOfCustomer(User.FindFirstValue(ClaimTypes.NameIdentifier));


            foreach (CartItems cartItem in cartItems)
            {
                OrderItems orderItem = new OrderItems()
                {
                    Quantity = cartItem.Quantity,
                    Price = (double)cartItemRepo.GetTotalPriceOfOneItem(cartItem), // Explicitly cast to double
                    OrderId = (int)TempData["OrderId"],               
                    ProductId = cartItem.ProductId.Value // Access the Value property of the nullable int
                };

                context.Add(orderItem);
                context.Save();
            }

            return RedirectToAction("DeleteCartItems", "CartItem");
        }
    }
}
