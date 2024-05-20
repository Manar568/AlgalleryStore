using AlGallery.Models;

namespace AlGallery.Interfaces
{
    public interface IProductRepo
    {
        public List<Products> GetAll(string SearchText = "");
        public Products GetById(int id);
        public void Add(Products product);
        public void Update(int id,Products product);
        public void Delete(int id);
        public void Save();
    }
}
