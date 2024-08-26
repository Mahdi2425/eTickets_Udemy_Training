using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Producer:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Picture")]
        [Required(ErrorMessage = "The pictureURL is required")]
        public string PictureProfileURL { get; set; }
        [Display(Name = "FullName")]
        [Required(ErrorMessage = "The Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The name must have been beetwen 3 & 50 Char")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "The Bio is required")]
        public string Bio { get; set; }
        public List<Movie>? Movies { get; set; }
    }
}
