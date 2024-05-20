namespace AlGallery.Models
{
    public class OrderItems : BaseEntity
    {

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero")]
        public int Quantity { get; set; }



        [Column(TypeName = "money")]
        [Required(ErrorMessage = "Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number")]
        public double Price { get; set; }


        // Navigation Properties


        [Required(ErrorMessage = "Product Id is required")]
        [ForeignKey("Products")]
        public int ProductId { get; set; }
        public virtual Products? Products { get; set; }




        [Required(ErrorMessage = "Order Id is required")]
        [ForeignKey("Orders")]
        public int OrderId { get; set; }
        public virtual Orders? Orders { get; set; }
    }
}
