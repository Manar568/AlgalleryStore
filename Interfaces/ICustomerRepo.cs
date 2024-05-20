using AlGallery.Models;

namespace AlGallery.Interfaces
{
    public interface ICustomerRepo
    {
        public List<User> GetAll(string SearchText = "");
        public User GetById(string id);
        public void Save();

    }
}
