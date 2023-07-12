using Microsoft.EntityFrameworkCore;
using Movies.DataAccess.Data;
using Movies.DataAccess.Repository.IRepository;

namespace Movies.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContent _context;

        public UnitOfWork (ApplicationDbContent context)
        {
            _context = context;
            movie = new MovieRepository(_context);
            comment = new CommentRepository(_context);
        }
        public ImovieRepository movie{ get; private set; }

        public IComment comment { get; private set; }
        public void save()
        {
            try
            {
                _context.SaveChanges();

            }
            catch(DbUpdateException ex)
            {
                var  InerException = ex.InnerException;
                var errorMessage = InerException.Message;

            }
          
        }
    }
}
