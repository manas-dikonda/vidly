using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieDetailsViewModel
    {
        public List<Movies> Movies { get; set; }
        public List<Customers> Customers { get; set; }
    }
}