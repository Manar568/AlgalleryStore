using System.ComponentModel.DataAnnotations;

namespace AlGallery.ViewModels
{
	public class AdminVM
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		[Compare("Password")]
        [Display(Name = "Confirmed Password")]

        public string ConfirmedPassword { get; set; }

	}
}
