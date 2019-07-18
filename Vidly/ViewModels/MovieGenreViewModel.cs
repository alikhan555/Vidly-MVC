using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieGenreViewModel
    {
        public IEnumerable<Genre> Genre { get; set; }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Range(1, 20)]
        [Required]
        public short? Stock { get; set; }

        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        public MovieGenreViewModel()
        {
            this.Id = 0;
        }

        public MovieGenreViewModel(Movie movie)
        {
            this.Id = movie.Id;
            this.Name = movie.Name;
            this.ReleaseDate = movie.ReleaseDate;
            this.DateAdded = movie.DateAdded;
            this.GenreId = movie.GenreId;
            this.Stock = movie.Stock;
        }
    }
}