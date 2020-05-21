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
            //string name = movie.Name;
            //DateTime releasedDate = movie.ReleasedDate;
            //DateTime dateAdded = movie.DateAdded;
            //int quantity = movie.Quantity;

            return View();
        }

        [HttpPost]
        public ActionResult CreateRecord(Movie movie)
        {
            string name = movie.Name;
            DateTime releasedDate = movie.ReleasedDate;
            DateTime dateAdded = movie.DateAdded;
            int quantity = movie.Quantity;

            _context.Movies.Add(movie);

            _context.SaveChanges();


            return View();
        }


    }
}