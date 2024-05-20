using Microsoft.AspNetCore.Identity;
namespace AlGallery.Models
{
    public class User : IdentityUser
    {

        [Required(ErrorMessage = "FirstName is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "FirstName must be between 3 and 50 characters")]
        public string? FirstName { get; set; }




        [Required(ErrorMessage = "LastName is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "LastName must be between 3 and 50 characters")]
        public string? LastName { get; set; }



        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Address must be between 5 and 100 characters")]
        public string? Address { get; set; }



        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime JoinDate { get; set; }



        [Required(ErrorMessage = "User Type is required")]
        [EnumDataType(typeof(UserType), ErrorMessage = "Invalid User Type")]
        [Display(Name = "User Type")]
        public UserType? UserType { get; set; }



        // Navigation Properties
        public virtual  ICollection<CartItems>? CartItems { get; set; }

        public virtual  ICollection<Payments>? Payments { get; set; }

        public virtual  ICollection<Orders>? Orders { get; set; }

        public virtual  ICollection<Shipments>? Shipments { get; set; }

        public virtual ICollection<Contact>? Contact { get; set; }





    }

    public enum UserType
    {
         Customer,
        Admin
    }
}