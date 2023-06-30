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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContent _context;

        public UnitOfWork (ApplicationDbContent context)
        {
            _context = context;
            movie = new MovieRepository(_context);
        }
        public ImovieRepository movie{ get; private set; }
        public void save()
        {
           _context.SaveChanges();
        }
    }
}
