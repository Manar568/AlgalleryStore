namespace AlGallery.Models
{
    public class CartItems : BaseEntity
    {


        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero")]
        public int Quantity { get; set; }



        // Navigation Properties


        // [ForeignKey("Products")]
        public int? ProductId { get; set; }
        public virtual Products? Products { get; set; }


        // [ForeignKey("Customers")]
        public int? CustomerId { get; set; }
        public virtual User ? Customers { get; set; }
    }
}

