using AlGallery.Data;
using AlGallery.Interfaces;
using AlGallery.Models;

namespace AlGallery.Repositories
{
    public class CustomerRepo : ICustomerRepo
    {
        private AlGalleryDBContext context;

        public CustomerRepo(AlGalleryDBContext context)
        {
            this.context = context;
        }

        public List<User> GetAll(string SearchText = "")
        {
            if (SearchText != "" && SearchText != null)
            {
                return context.Users.Where(p => p.FirstName.Contains(SearchText) || p.LastName.Contains(SearchText)).ToList();
            }
            else
            {
                return context.Users.ToList();
            }
        }

        public User GetById(string id)
        {
            return context.Users.FirstOrDefault(u => u.Id == id);
        }


        public void Save()
        {
            context.SaveChanges();
        }
    }
}
