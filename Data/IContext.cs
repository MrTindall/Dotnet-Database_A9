using ApplicationTemplate.Models;
using System.Collections.Generic;
using System;

namespace ApplicationTemplate.Data
{
    public interface IContext
    {
        Movie GetById(int id);
        Movie GetByTitle(string title);

        List<Movie> FindMovie(String title);
    }
}