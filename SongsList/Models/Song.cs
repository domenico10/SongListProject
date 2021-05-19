using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SongsList.Models
{
    public class Song
    {
        public int SongId { get; set; }

        [Required(ErrorMessage = "Please enter a song name")] //TEXT MESSAGE TO SHOW IN THE WEB PAGE
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter a year")] //TEXT MESSAGE TO SHOW IN THE WEB PAGE
        [Range(1900,2021,ErrorMessage = "Year must be between 1900 and 2021")] //TEXT MESSAGE TO SHOW IN THE WEB PAGE
        public int? Year { get; set; } //NULLABLE INTEGER FOR CUSTOM MESSAGE

        [Required(ErrorMessage = "Please enter the rating")]
        [Range(1,5,ErrorMessage = "Rating must be between 1 and 5")]
        public int? Rating { get; set; }

        [Required(ErrorMessage = "Please enter genre")]
        public string GenreId { get; set; }
        public Genre Genre { get; set; }


        public string Slug => Name?.Replace(" ", "-").ToLower() + '-' + Year?.ToString();
    }
}
