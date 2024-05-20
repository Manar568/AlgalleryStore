namespace AlGallery.Models
{
    public class Products : BaseEntity
    {

        [Column(TypeName = "money")]
        [Required(ErrorMessage = "Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number")]
        public decimal Price { get; set; }



        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string? Description { get; set; }



        [Required(ErrorMessage = "Stock is required")]
        public int Stock { get; set; }



        [Required(ErrorMessage = "Image is required")]
        public string? Image { get; set; }




        // Navigation Properties


        [Display(Name = "Category")]
        [ForeignKey("Categories")]
        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }
        public virtual Categories? Categories { get; set; }


        public virtual  ICollection<OrderItems>? OrderItems { get; set; }


        public virtual  ICollection<CartItems>? CartItems { get; set; }
    }
}
