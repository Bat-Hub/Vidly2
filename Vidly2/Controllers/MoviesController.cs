using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.Models.ViewDataModel;

using System.Data.Entity;

namespace Vidly2.Controllers
{
    public class MoviesController : Controller
    {
        public ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Movies
        public ActionResult Index()
        {
            var movie = _context.Movies.Include(c => c.Genre).ToList();
            return View(movie);
        }

        public ActionResult Create()
        {
            var moviedatamodel = new MovieViewDataModel()
            {
                Genres = _context.Genre.ToList(),
            };
            return View("MovieForm", moviedatamodel);
        }
       
        public ActionResult Edit(int id)
        {
            var movieindb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieindb == null)
                return new HttpNotFoundResult();
            var moviedatamodel = new MovieViewDataModel(movieindb)
            {
                Genres = _context.Genre.ToList()
            };

            return View("MovieForm", moviedatamodel);

        }
        public ActionResult Save(Movie Movie)
        {

            if (!ModelState.IsValid)
            {
                var moviedatamodel = new MovieViewDataModel(Movie)
                {
                    Genres = _context.Genre.ToList(),

                };
                return View("MovieForm", moviedatamodel);
            }

            if (Movie.Id != 0)
            {
                var movieindb = _context.Movies.SingleOrDefault(c => c.Id == Movie.Id);
                movieindb.GenreId = Movie.GenreId;
                movieindb.NumberInStock = Movie.NumberInStock;
                movieindb.Name = Movie.Name;
                movieindb.ReleaseDate = Movie.ReleaseDate;
            }
            else
            {
                Movie.DateAdded = DateTime.Today;
                _context.Movies.Add(Movie);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}