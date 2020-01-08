using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly2.Models;

namespace Vidly2.Models.ViewDataModel
{
    public class MovieViewDataModel
    {
        public List<Genre> Genres { get; set; }

        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name = "Release Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        public byte? NumberInStock { get; set; }

        public MovieViewDataModel()
        {
            Id = 0;
        }
        public MovieViewDataModel(Movie movie)
        {
            Id = movie.Id;
            GenreId = movie.GenreId;
            Name = movie.Name;
            NumberInStock = movie.NumberInStock;
            ReleaseDate = movie.ReleaseDate;
        }
    }
}