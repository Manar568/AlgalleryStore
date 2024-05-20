using AlGallery.Interfaces;
using AlGallery.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace AlGallery.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepo context;
        public OrderController(IOrderRepo context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Orders> orders = context.GetAll();
            return View(orders);
        }

        public IActionResult AddOrder()
        {
            Orders order = new Orders()
            {
                OrderItems = new List<OrderItems>(),
                OrderDate = DateTime.Now,
                Price = decimal.Parse(TempData["Amount"] as string),
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                PaymentId = (int)TempData["PaymentId"],
                ShipmentId = (int)TempData["ShipmentId"],


            };

            context.Add(order);
            context.Save();

            TempData["OrderId"] = order.Id;

            return RedirectToAction("AddOrderItem", "OrderItem");
        }
    }
}
