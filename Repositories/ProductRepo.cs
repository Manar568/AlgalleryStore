using AlGallery.Data;
using AlGallery.Interfaces;
using AlGallery.Models;

namespace E_Commerce_MVC.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private AlGalleryDBContext context;

        public ProductRepo(AlGalleryDBContext context)
        {
            this.context = context;
        }
        public void Add(Products product)
        {
            context.Products.Add(product);
        }

        public void Delete(int id)
        {
            context.Products.Remove(GetById(id));
        }

        public List<Products> GetAll(string SearchText = "")
        {
            if (SearchText != "" &&  SearchText != null)
            {
                return context.Products.Where(p => p.Name.Contains(SearchText)).ToList();
            }
            else
            {
				return context.Products.ToList();
			}    
        }

        public Products GetById(int id)
        {
            return context.Products.SingleOrDefault(p => p.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(int id, Products prod)
        {
            if (GetById(id) != null)
            {
                context.Products.Update(prod);
            }

        }
    }
}
