using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly2.Dto;
using Vidly2.Models;

namespace Vidly2.Controllers.Api
{
    public class MoviesController : ApiController
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

        [HttpGet]
        public IHttpActionResult GetMovies(string query = null)
        {
            var moviedquery = _context.Movies.Include(m => m.Genre).Where(m => m.NumberAvailable > 0); 

            if (!string.IsNullOrWhiteSpace(query))
                moviedquery = moviedquery.Where(m => m.Name.Contains(query));


          //  moviedquery = moviedquery.Where(m => m.NumberAvailable > 0);
            var moviedto = moviedquery
                .ToList().Select(Mapper.Map<Movie, MovieDto>);
            return Ok(moviedto);
        }
        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();
            return Ok(movie);
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }
        [HttpPut]
        public IHttpActionResult UpdateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieindb = _context.Movies.SingleOrDefault(m => m.Id == movieDto.Id);
            if (movieindb == null)
                return NotFound();

            Mapper.Map<MovieDto, Movie>(movieDto, movieindb);
            _context.SaveChanges();
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var movieindb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieindb == null)
                return NotFound();
            _context.Movies.Remove(movieindb);
            _context.SaveChanges();
            return Ok();

        }
    }
}
