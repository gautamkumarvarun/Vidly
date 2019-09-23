using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly1.Models;

namespace Vidly1.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult MovieList()
        {
            var movie = _context.Movies.ToList();

            return View(movie);

            //return RedirectToAction("errorPage","home");
        }

        public ActionResult MovieDetails(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m=>m.Id==id);
            
            if (movie == null)
            {
                return HttpNotFound();
            }


            return View(movie);

            //return RedirectToAction("errorPage","home");
        }

    }
}