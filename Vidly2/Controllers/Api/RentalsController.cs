using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly2.Dto;
using Vidly2.Models;

namespace Vidly2.Controllers.Api
{
    public class RentalsController : ApiController
    {
        public ApplicationDbContext _context;
        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateRental(RentalDto rentalDto)
        {
            var customer = _context.Customer.SingleOrDefault(c => c.Id == rentalDto.CustomerId);
            if (customer == null)
                return BadRequest();

            if (rentalDto.MovieIds.Count == 0)
                return BadRequest();

            var movies = _context.Movies.Where(c => rentalDto.MovieIds.Contains(c.Id)).ToList() ;

            if (movies.Count != rentalDto.MovieIds.Count)
                return BadRequest();


            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest();

                movie.NumberAvailable--;
                var rental = new Rental()
                {
                    Customer = customer,
                    DateRented = DateTime.Now,
                    Movie = movie
                };

                _context.Rental.Add(rental);
                _context.SaveChanges();
            }

            return Ok();
        }

    }
}
