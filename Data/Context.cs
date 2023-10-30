using ApplicationTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTemplate.Data
{
    public class Context : IContext
    {
        public List<Movie> Movies { get; set; }
        public Context() 
        {
            Movies = new List<Movie>()
            {
                new Movie{Id = 1, Title = "Toy Story"},
                new Movie{Id = 2, Title = "Star Wars"},
                new Movie{Id = 3, Title = "Star Wars"},
                new Movie{Id = 4, Title = "Star Wars"},
                new Movie{Id = 5, Title = "Star Wars"},
                new Movie{Id = 6, Title = "Star Wars"},
                new Movie{Id = 7, Title = "Oceans 11"}

            };
        }

        public Movie GetById(int id)
        {
            return Movies.FirstOrDefault(x => x.Id == id);
        }

        public Movie GetByTitle(string title)
        {
            return Movies.FirstOrDefault(x => x.Title.ToLower() == title);
        }

        public List<Movie> FindMovie(string title) {

            // Find by title
            List<Movie> foundMovies = Movies.Where(x => x.Title.ToLower() == title).ToList();
            return foundMovies;
        }
    }
}
