using MovieApplication.Models;

namespace Movies.DataAccess.Repository.IRepository
{
    public interface ImovieRepository : IRepository<movie>
    {
        void update(movie movie);
        void save();
    }
}
