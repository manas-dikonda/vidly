using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movies
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        [Range(1, 20)]
        [Display(Name = "Number in stock")]
        public int NumberInStock { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public string ReleaseDate { get; set; }

        public string DateAdded { get; set; }

        public byte NumberAvailable { get; set; }
    }
}