namespace AlGallery.Models
{
    public class Shipments : BaseEntity
    {

        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Address must be between 5 and 100 characters")]
        public string? Address { get; set; }



        [Required(ErrorMessage = "City is required")]
        public string? City { get; set; }



        [Required(ErrorMessage = "State is required")]
        public string? State { get; set; }



        [Required(ErrorMessage = "Country is required")]
        public string? Country { get; set; }



        [Required(ErrorMessage = "Zip Code is required")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip Code")]
        public string? ZipCode { get; set; }



        [Required(ErrorMessage = "Status is required")]
        public string? Status { get; set; }



        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }



        // Navigation Properties

        [ForeignKey("Customers")]
        public string? CustomerId { get; set; }
        public virtual User? Customers { get; set; }


        public virtual  ICollection<Orders>? Orders { get; set; }


    }
    public enum ShipmentStatus
    {
        Pending,
        Shipped,
        Delivered
    }
}

