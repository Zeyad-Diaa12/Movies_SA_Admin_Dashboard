﻿using Microsoft.EntityFrameworkCore;
using Movies_SA1_Project_API.Data;
using Movies_SA1_Project_API.DTOs;
using Movies_SA1_Project_API.Models;
using Movies_SA1_Project_API.Services;

namespace Movies_SA1_Project_API.Implementations
{
    // The implementation of the Movie interface
    public class MovieService : IMovieService
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public MovieService(DataContext context, IWebHostEnvironment webHostEnvironment)
        {
            // Initailize the object to deal with the User database
            _context = context;
            // object to deal with the files of the website
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<bool> AddMovie(MovieDto movieDto)
        {
            try
            {
                // Make a name for the cover photo of the movie
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + movieDto.CoverPhoto.FileName;

                // Define the full path
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", uniqueFileName);


                // add the file to the full path
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await movieDto.CoverPhoto.CopyToAsync(stream);
                }

                // change form movieDto to movie 

                var movie = new Movie
                {
                    Title = movieDto.Title,
                    Description = movieDto.Description,
                    Author = movieDto.Author,
                    Genre = movieDto.Genre,
                    CoverPhoto = Path.Combine("uploads", uniqueFileName),
                    Downloads = movieDto.Downloads,
                    Likes = movieDto.Likes,
                    Views = movieDto.Views,
                    Rating = movieDto.Rating
                };


                // add movie to database
                _context.Movies.Add(movie);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteMovie(int movieID)
        {
            try
            {
                // get the movie from the database using id
                var movie = await _context.Movies.FindAsync(movieID);

                if (movie == null)
                    return false;

                // delete the photo from the uploads files
                var fullPath = Path.Combine(_webHostEnvironment.WebRootPath, movie.CoverPhoto.TrimStart('\\', '/'));

                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }

                // delete the movie from the database

                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> GetMovieById(int movieID)
        {
            var movie = await _context.Movies.FindAsync(movieID);

            return movie;
        }

        public async Task<Movie> GetMovieByName(string movieTitle)
        {
            return await _context.Movies.FirstOrDefaultAsync(m => m.Title == movieTitle);
        }
    }
}
