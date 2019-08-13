using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MovieRental
    {
        public int Id { get; set; }

        [Required]
        public Movies Movies { get; set; }

        [Required]
        public Customers Customers { get; set; }

        public DateTime DateAdded { get; set; }
        
        public DateTime? DateReturned { get; set; }
    }
}