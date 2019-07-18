using System;
using System.Data.Entity;
using System.Collections.Generic;
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

        public MoviesController()
        {
            _context = new Models.ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Index()
        {
            if(User.IsInRole(RolesNames.CanManageMovies))
                return View("List");

            return View("ReadOnlyList");
        }

        
        public ActionResult Detail(int id)
        {
            var movies = _context.Movies.Include(M => M.Genre).SingleOrDefault(M => M.Id == id);
            return View(movies);
        }

        [Authorize(Roles = RolesNames.CanManageMovies)]
        public ActionResult New()
        {
            var GenreMovie = new MovieGenreViewModel()
            {
                Genre = _context.Genre.ToList()
            };

            return View("MovieForm", GenreMovie);
        }

        [Authorize(Roles = RolesNames.CanManageMovies)]
        public ActionResult Edit(int Id)
		{
            var movie = _context.Movies.Single(m => m.Id == Id);

            var MovieGenre = new MovieGenreViewModel(movie)
            {
                Genre = _context.Genre.ToList()
            };

			return View("MovieForm",MovieGenre);
		}

		[HttpPost]
        [Authorize(Roles = RolesNames.CanManageMovies)]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var MovieGenre = new MovieGenreViewModel(movie)
                {
                    Genre = _context.Genre.ToList()
                };

                return View("MovieForm", MovieGenre);
            }

            if(movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
			else
			{
				var MovieInDB = _context.Movies.Single(m => m.Id == movie.Id);

				MovieInDB.Name = movie.Name;
				MovieInDB.ReleaseDate = movie.ReleaseDate;
				MovieInDB.Stock = movie.Stock;
				MovieInDB.GenreId = movie.GenreId;
			}

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
        
    }
}