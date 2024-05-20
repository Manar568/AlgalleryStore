using AlGallery.Models;

namespace AlGallery.Interfaces
{
    public interface IOrderRepo
    {
        public List<Orders> GetAll();
        public Orders GetById(int id);
        public void Add(Orders order);
        public void Update(int id,Orders order);
        public void Delete(int id);
        public void Save();
    }
}
