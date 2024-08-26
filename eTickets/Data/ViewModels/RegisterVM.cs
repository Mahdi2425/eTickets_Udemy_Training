using System.ComponentModel.DataAnnotations;

namespace eTickets.Data.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "The Full name is required")]
        [Display(Name = "Full name")]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "The Email Adrress is required")]
        [Display(Name = "Email Adrress")]
        public string Emailadrress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Confrim Password")]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password" , ErrorMessage = "Password do not match!")]
        public string ConfrimPassword { get; set; }

    }
}
