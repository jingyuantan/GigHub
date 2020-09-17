using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class GigsController : Controller
    {
        // added to read data from database and display at view
        private readonly ApplicationDbContext _context;
        // initialize _context
        public GigsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            // create a model to pass to view page for dropdown list
            var viewModel = new GigFormViewModel
            {
                Genres = _context.Genres.ToList()
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            // below's method pay too many round of visits to the database so we avoid that
            // get data from database using _context
            /*var artistId = User.Identity.GetUserId(); // declare here first for next line comparision !important
            var artist = _context.Users.Single(u => u.Id == artistId); // if match current user
            var genre = _context.Genres.Single(g => g.Id == viewModel.Genre); // if match user input (dropdown lsit of genre)*/

            if (!ModelState.IsValid) {
                viewModel.Genres = _context.Genres.ToList(); // if not valid, need to re-initialized whatever needed to be initialized in create() above
                return View("Create", viewModel); // return to create gig page to fill in the form again if error
            }

            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };

            //finally add created gig object into database
            _context.Gigs.Add(gig);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home"); // redirect to index action of home controller
        }
    }
}