using AlGallery.Models;

namespace AlGallery.Interfaces
{
    public interface IOrderItemRepo
    {
        public List<OrderItems> GetAll();
        public OrderItems GetById(int productId, int orderId);
        public void Add(OrderItems item);
        public void Update(int productId, int orderId, OrderItems item);
        public void Delete(int productId, int orderId);
        public void Save();
    }
}
