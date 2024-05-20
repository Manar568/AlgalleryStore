namespace OurProject.Models
{
    public class Orders : BaseEntity
    {


        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? OrderDate { get; set; }



        [Column(TypeName = "money")]
        [Required(ErrorMessage = "Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number")]
        public decimal Price { set; get; }


        // Navigation Properties


        [Required]
        [Display(Name = "User Id")]
        [ForeignKey("Customers")]
        public string? UserId { get; set; }
        public virtual User? Customers { set; get; }




        [Required]
        [Display(Name = "Payment Id")]
        [ForeignKey("Payments")]
        public int PaymentId { get; set; }
        public virtual Payments? Payments { set; get; }




        [Required]
        [Display(Name = "Shipment Id")]
        [ForeignKey(nameof(Shipments))]
        public int ShipmentId { get; set; }
        public virtual Shipments? Shipments { set; get; }



        public virtual  ICollection<OrderItems>? OrderItems { set; get; }

    }
}
