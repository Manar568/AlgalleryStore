
using AlGallery.Data;
using AlGallery.Interfaces;
using AlGallery.Models;
using System.Collections.Generic;
using System.Linq;

namespace AlGallery.Repositories
{
    public class CartItemRepo : ICartItemRepo
    {
        private readonly AlGalleryDBContext context;

        public CartItemRepo(AlGalleryDBContext context)
        {
            this.context = context;
        }

        public void Add(CartItems item)
        {
            context.CartItems.Add(item);
        }

        public void Delete(int productId, string customerId)
        {
            context.CartItems.Remove(GetById(productId, customerId));
        }

        public List<CartItems> GetAll()
        {
            return context.CartItems.ToList();
        }

        //public CartItems GetById(int productId, string customerId)
        //{
        //    return context.CartItems.SingleOrDefault(i => i.ProductId == productId && i.CustomerId == customerId);
        //}
        public CartItems GetById(int productId, string customerId)
        {
            return context.CartItems.SingleOrDefault(i => i.ProductId == productId && i.CustomerId.ToString() == customerId);
        }


        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(int productId, string customerId, CartItems item)
        {
            if (GetById(productId, customerId) != null)
            {
                context.CartItems.Update(item);
            }
        }

        public void DeleteByCartItem(CartItems cartItem)
        {
            context.CartItems.Remove(cartItem);
        }

        public decimal GetTotalPrice(string customerId)
        {
            decimal totalPrice = 0;
            foreach (CartItems cartItem in GetCartItemsOfCustomer(customerId))
            {
                totalPrice += (cartItem.Products.Price * cartItem.Quantity);
            }
            return totalPrice;
        }

        //Convert items.CustomerId to a string
        public List<CartItems> GetCartItemsOfCustomer(string customerId)
        {
            return GetAll().Where(items => items.CustomerId.ToString() == customerId).ToList();
        }

        public decimal GetTotalPriceOfOneItem(CartItems item)
        {
            return item.Quantity * item.Products.Price;
            
        }
    }
}

