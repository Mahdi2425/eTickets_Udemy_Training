using eTickets.Data.Base;
using eTickets.Data.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class Movie : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }  
        public double price { get; set; }
        public string ImageMovieURL { get; set; }
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }
        public MovieCategory movieCategory { get; set; }

        public List<Actor_Movie>? Actors_Movies { get; set; }

        public List<Cinema>? Cinemas { get; set;}

        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")]
        public Cinema? Cinema { get; set; }
        /////
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer? Producer { get; set; }  

    }
}
