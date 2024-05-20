using AlGallery.Models;

namespace AlGallery.Interfaces
{
    public interface ICartItemRepo
    {
        public List<CartItems> GetAll();
        public CartItems GetById(int productId, string customerId);
        public void Add(CartItems item);
        public void Update(int productId, string customerId, CartItems item);
        public void Delete(int productId, string customerId);
        public void DeleteByCartItem(CartItems cartItem);

        public decimal GetTotalPrice(string customerId);

        public List<CartItems> GetCartItemsOfCustomer(string customerId);

        public decimal GetTotalPriceOfOneItem(CartItems item);
		public void Save();
    }
}
