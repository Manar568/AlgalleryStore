namespace AlGallery.Models 
{
    public class Categories : BaseEntity
    {

        // Navigation Properties
        public virtual ICollection<Products>? Products { get; set; }

    }
}
