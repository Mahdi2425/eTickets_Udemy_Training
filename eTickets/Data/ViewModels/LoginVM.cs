using System.ComponentModel.DataAnnotations;

namespace eTickets.Data.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "The Email Adrress is required")]
        [Display(Name = "Email Adrress")]
        public string Emailadrress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
