namespace AlGallery.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First Name must be between 2 and 50 characters")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last Name must be between 2 and 50 characters")]
        public string? LastName { get; set; }

        //[Required(ErrorMessage = "Product/Order Inquiry is required")]
        //public string? ProductOrder { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Address must be between 5 and 100 characters")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Mobile Phone is required")]
        [Phone(ErrorMessage = "Invalid Mobile Phone Number")]
        public string? MobilePhone { get; set; }

        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string?Phone { get; set; }



        [Required(ErrorMessage = "Contact Box is required")]
        public string? ContactBox { get; set; }


        // Navigation Properties
       //  [ForeignKey("User")]
        public string? UserId { get; set; }
        public virtual User ? Customers { get; set; }
    }
}

