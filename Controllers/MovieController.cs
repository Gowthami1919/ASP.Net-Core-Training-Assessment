using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCrudOpe.Data;
using MovieCrudOpe.Models;

namespace MovieCrudOpe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly DataContext _content;
        public MovieController(DataContext content)
        {
            _content = content;
        }
        //get movie by id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var movie = _content.Movies.Where(x => x.id == id).FirstOrDefault();
            return Ok(movie);
        }
        [HttpPost]
        public IActionResult post([FromBody] Movie movie)
        {
            _content.Movies.Add(movie);
            _content.SaveChanges();
            return Ok("Added");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movie = _content.Movies.Where(x => x.id == id).FirstOrDefault();
            _content.Movies.Remove(movie);
            _content.SaveChanges();
            return Ok("Deleted");
        }

        [HttpPut("{id}")]

        public IActionResult Put(int id, [FromBody]Movie movie)
        {
            var movies = _content.Movies.Where(x => x.id == id).FirstOrDefault();
            movies.MovieName = movie.MovieName;
            movies.Rating = movie.Rating;
            _content.Movies.Update(movies);
            _content.SaveChanges();
            return Ok("Updated");

        }




    }
}
        
