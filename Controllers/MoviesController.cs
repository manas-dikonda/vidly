using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers 
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public  MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        public ViewResult Index()
        {
            if(User.IsInRole(RoleName.CanManageMovies))
                return View("List");

            return View("ReadOnlyList");
        }

        // GET: Movies/Details/{id}
        public ActionResult Edit(int id)
        {
            var movies = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movies == null)
                return HttpNotFound();
            else
            {
                return View("MovieForm", movies);
            }
        }

        [Authorize(Roles=RoleName.CanManageMovies)]
        public ActionResult New()
        {
            return View("MovieForm");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movies movies)
        {
            try
            {
                if (movies.Id == 0)
                    _context.Movies.Add(movies);
                else
                {
                    var movieInDb = _context.Movies.Single(c => c.Id == movies.Id);

                    movieInDb.Name = movies.Name;
                    movieInDb.ReleaseDate = movies.ReleaseDate;
                    movieInDb.Genre = movies.Genre;
                    movieInDb.NumberInStock = movies.NumberInStock;

                }

                _context.SaveChanges();

                return RedirectToAction("Index", "Movies");
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                            ve.PropertyName, eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName), ve.ErrorMessage);
                    }
                }
                throw;
            }

        }
    }
}