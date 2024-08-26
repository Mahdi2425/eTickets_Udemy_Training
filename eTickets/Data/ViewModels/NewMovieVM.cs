using eTickets.Data.Base;
using eTickets.Data.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class NewMovieVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Movie Name is required")]
        [Display(Name = "Movie Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Description is required")]
        [Display(Name = "Movie Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "The Price is required")]
        [Display(Name = "Movie Price in $")]
        public double price { get; set; }
        [Required(ErrorMessage = "The ImageURL is required")]
        [Display(Name = "Movie Image")]
        public string ImageMovieURL { get; set; }
        [Required(ErrorMessage = "The StartingDate is required")]
        [Display(Name = "Movie Starts at")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "The EndDate is required")]
        [Display(Name = "Movie Ends at")]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Select the MovieCategory")]
        [Display(Name = "Select the MovieCategory")]
        public MovieCategory movieCategory { get; set; }
        [Required(ErrorMessage = "Select the ActorsIds")]
        [Display(Name = "Select the ActorsIds")]
        public List<int> ActorsIds { get; set; }
        [Required(ErrorMessage = "Select the Cinemas")]
        [Display(Name = "Select the Cinemas")]
        public int CinemaId { get; set; }
        [Required(ErrorMessage = "Select the Producer")]
        [Display(Name = "Select the Producer")]
        public int ProducerId { get; set; }
    }
}
