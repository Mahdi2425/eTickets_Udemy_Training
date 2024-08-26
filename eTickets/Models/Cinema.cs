using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Cinema:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "The pictureURL is required")]
        [Display(Name = "Cinema Photo")]
        public string CinemaLogoURL { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "The Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The name must have been beetwen 3 & 50 Char")]
        public string Name { get; set; }
        [Display(Name ="Description")]
        [Required(ErrorMessage = "The Description is required")]
        public string Description { get; set; }

        public List<Movie>? Movies { get; set; }
    }
}
