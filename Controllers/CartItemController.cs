using AlGallery.Interfaces;
using AlGallery.Models;
using AlGallery.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AlGallery.Controllers
{
   // [Authorize]
    public class CartItemController : Controller
    {
        private ICartItemRepo context;
        private IProductRepo productRepo;
        private UserManager<User> userManager;

        public CartItemController(ICartItemRepo context, IProductRepo productRepo, UserManager<User> userManager)
        {
            this.context = context;
            this.productRepo = productRepo;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            List<CartItems> cartItem = context.GetCartItemsOfCustomer(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(cartItem);
        }
        public IActionResult Remove(int productId)
        {
            var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            context.Delete(productId, customerId);
            context.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            var Id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (context.GetById(productId, Id) != null)
            {
                context.GetById(productId, Id).Quantity++;
            }
            else
            {
                CartItems cartItem = new()
                {
                    ProductId = productId,
                    CustomerId = Convert.ToInt32(Id),
                    Quantity = 1,
                };

                context.Add(cartItem);
            }
            context.Save();
            return RedirectToAction("Index", "Product");
        }

        public IActionResult DeleteCartItems()
        {
            List<CartItems> cartItems = context.GetCartItemsOfCustomer(User.FindFirstValue(ClaimTypes.NameIdentifier));

            foreach (CartItems cartItem in cartItems)
            {
                Products product = productRepo.GetById((int)cartItem.ProductId);
                product.Stock -= cartItem.Quantity;
                productRepo.Update(product.Id, product);
                productRepo.Save();
                context.DeleteByCartItem(cartItem);
                context.Save();
            }

            return RedirectToAction("Index", "Shipment");
        }

        public IActionResult IncrementProduct(int productId)
        {

            // get id of the user
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // get product wanted by user 
            CartItems cartItem = context.GetById(productId, userId);

            if (cartItem == null)
            {
                return NoContent();
            }


            // increment
            cartItem.Quantity += 1;

            // update
            context.Update(productId, userId, cartItem);

            context.Save();


            return NoContent();

        }

        public IActionResult decreaseProduct(int productId)
        {
            // get id of the user
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // get product wanted by user 
            CartItems cartItem = context.GetById(productId, userId);

            if (cartItem == null || cartItem.Quantity <= 1)
            {
                return NoContent();
            }

            // decrement
            cartItem.Quantity -= 1;

            // update
            context.Update(productId, userId, cartItem);

            context.Save();

            return NoContent();
        }

        // refresh the page
        public IActionResult UpdateCart()
        {
            context.Save();

            return RedirectToAction(nameof(Index));
        }



    }
}
