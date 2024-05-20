using AlGallery.Data;
using AlGallery.Interfaces;
using AlGallery.Models;

namespace AlGallery.Repositories
{
    public class OrderItemRepo : IOrderItemRepo
    {
        private AlGalleryDBContext context;
        public OrderItemRepo(AlGalleryDBContext context)
        {
            this.context = context;
        }
        public void Add(OrderItems item)
        {
            context.OrderItems.Add(item);
        }

        public void Delete(int productId, int orderId)
        {
            context.OrderItems.Remove(GetById(productId,orderId));
        }

        public List<OrderItems> GetAll()
        {
            return context.OrderItems.ToList();
        }

        public OrderItems GetById(int productId, int orderId)
        {
            return context.OrderItems.SingleOrDefault(i => i.ProductId == productId && i.OrderId == orderId);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(int productId, int orderId, OrderItems item)
        {
            if (GetById(productId, orderId) != null)
            {
                context.OrderItems.Update(item);
            }
        }
    }
}
