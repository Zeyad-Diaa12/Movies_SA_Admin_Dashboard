﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Movies_SA1_Project_API.DTOs;
using Movies_SA1_Project_API.Services;

namespace Movies_SA1_Project_API.Controllers
{

    // the main api endpoints for movies
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            // initalize object from the user service to deal with incoming data
            _movieService = movieService;
        }


        // add movie endpoint

        [HttpPost]
        public async Task<IActionResult> AddMovie([FromForm]MovieDto newMovie)
        {
            var movie = await _movieService.AddMovie(newMovie);

            if (movie)
            {
                return Ok("Movie Added");
            }

            return BadRequest("Something Went Wrong");
        }


        // get movie by search endpoint
        [HttpGet("get-movie/{searchWord}")]
        public async Task<IActionResult> GetMovie(string searchWord)
        {
            var movie = await _movieService.GetMovieByName(searchWord);
            if (movie != null)
            {
                return Ok(movie);
            }
            return Ok("Movie Not Found");
        }


        // delete movie using id
        [HttpDelete("delete-movie/{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _movieService.DeleteMovie(id);

            if (movie)
            {
                return Ok("Deleted");
            }

            return BadRequest("Couldn't delete the movie");
        }


        // get all movies
        [HttpGet("get-all-movies")]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await _movieService.GetAllMovies();
            if (movies == null)
            {
                return Ok("No Movies Found");
            }
            return Ok(movies);
        }
    }
}
