using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
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
           
            var movie = _context.Movies.Where(m => m.Id == id).SingleOrDefault();

            if (movie == null) 
            {
                return HttpNotFound();
            }

            return View(movie);  
            
        }
        [HttpPost]
        public ActionResult Edit(Movie movie)
        {

            if (ModelState.IsValid)
            {
                _context.Entry(movie).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
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
        public ActionResult CreateRecord([Bind(Include = "Name,ReleasedDate,DateAdded,Quantity")] Movie movie)
        {
            string name = movie.Name;
            DateTime releasedDate = movie.ReleasedDate;
            DateTime dateAdded = movie.DateAdded;
            int quantity = movie.Quantity;

            _context.Movies.Add(movie);

            _context.SaveChanges();


            return RedirectToAction("Index");
        }

        [Route("Movies/Details/{id}")]
        public ActionResult Details(int id)
        {
            var movies = _context.Movies.SingleOrDefault(a => a.Id == id);

            return View(movies);
        }


    }
}