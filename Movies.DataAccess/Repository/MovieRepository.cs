using MovieApplication.Models;
using Movies.DataAccess.Data;
using Movies.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DataAccess.Repository
{
    public class MovieRepository : Repository<movie>, IRepository.ImovieRepository
    {
        private readonly ApplicationDbContent _content;
        public MovieRepository(ApplicationDbContent content) :base(content)
        {
            _content = content; 
        }
        public void save()
        {
            _content.SaveChanges();
        }

        public void update(movie movie)
        {
            var moviesdb = _content.movies.FirstOrDefault(u=>u.Id == movie.Id); 
            if(moviesdb != null) 
            { 
                moviesdb.Title = movie.Title;   
                moviesdb.Description =movie.Description;
                moviesdb.Price = movie.Price;
               // moviesdb.details = movie.details;
                moviesdb.DateOfRelease= movie.DateOfRelease; 
                if(moviesdb.Imageurl  != null)
                {
                    moviesdb.Imageurl = movie.Imageurl;

                }
               
            }
        }
    }
}
