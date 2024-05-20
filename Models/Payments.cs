namespace AlGallery.Models
{
    public class Payments : BaseEntity
    {


        [Required(ErrorMessage = "Date is required")]
        [Display(Name = "Payment Date")]
        public DateTime Date { get; set; }



        [Required(ErrorMessage = "Payment Method is required")]
        [StringLength(50, ErrorMessage = "Payment Method must be less than 50 characters")]
        [Display(Name = "Payment Method")]
        public string? Method { get; set; }



        [Required(ErrorMessage = "Amount is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive number")]
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }


        // Navigation Properties


        [ForeignKey("Customers")]
        public string? CustomerId { get; set; }
        public virtual User? Customers { get; set; }



        public virtual ICollection<Orders>? Orders { get; set; }



    }
}
