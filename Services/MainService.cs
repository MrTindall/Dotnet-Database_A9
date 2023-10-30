using ApplicationTemplate.Data;
using ApplicationTemplate.Models;
using System;
using System.Collections.Generic;

namespace ApplicationTemplate.Services;

/// <summary>
///     You would need to inject your interfaces here to execute the methods in Invoke()
///     See the commented out code as an example
/// </summary>
public class MainService : IMainService
{

    private readonly IContext _context;
    public MainService(IContext context)
    {
        _context = context;
    }
    public void Invoke()
    {

        // Provide an option to the user
        // 1. select by id
        // 2. select by title
        // 3. find movie by title
        while (true)
        {
            Console.Write($"Search for a movie:\n1: Id\n2: Title\n3: Movies with same name\n4: Exit\nEnter: ");
            var idOrTitleAnswer = Console.ReadLine();
            if( idOrTitleAnswer == "1" ) 
            {
                Console.Write($"Enter an Id: ");
                var idValue = Console.ReadLine();

                var movie = _context.GetById(Convert.ToInt32(idValue));
                if( movie != null ) 
                { 
                    Console.WriteLine($"\nYour movie is {movie.Title}\n"); 
                }
                else
                {
                    Console.WriteLine("\nThat is not in the database\n");
                }

            }
            else if (idOrTitleAnswer == "2")
            {
                Console.Write($"Enter a movie Title: ");
                var titleValue = Console.ReadLine().ToLower();

                var movie = _context.GetByTitle(titleValue);
                if( movie != null )
                {
                    Console.WriteLine($"\nYour movie is {movie.Title}\n");
                       
                }
                else
                {
                    Console.WriteLine($"That movie is not in the database\n");
                        
                }

            }
            else if (idOrTitleAnswer == "3")
            {
                Console.Write($"Enter list of movies with matching titles: ");
                var listTitleValue = Console.ReadLine().ToLower();

                var movies = _context.FindMovie(listTitleValue);

                if(movies.Count > 0)
                {
                    Console.WriteLine();
                    foreach (var movie in movies)
                    {
                        Console.WriteLine(movie.Title);
                    }
                    Console.WriteLine();
                }
                else if (movies.Count <= 0)
                {
                    Console.WriteLine("That movie is not on in the database\n");
                }
                    

            }
            else if (idOrTitleAnswer == "4")
            {
                Console.WriteLine("\nExiting the program...");
                break;
            }
            else
            {
                Console.WriteLine($"That is not a valid input\n");
            }
        }
       
    }
}