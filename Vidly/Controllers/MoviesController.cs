using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        MyDbContext _context = new MyDbContext();

        // GET: Movies
       /* public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };

            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }*/



        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        public ActionResult Index()
        {
            var movie = _context.Movies.ToList();
            return View(movie);
        }

        public ActionResult CreateRecord()
        {
            return View();
        }



        /*private IEnumerable<Movie> GetMovies()
        {      
            return new List<Movie>
            {
                new Movie {Id = 1, Name = "Star Trek",Genre = Genre.Comedy},
                new Movie {Id = 2, Name = "Sholay"}
            };
        }*/
        
    }
}