using Movies.Model.Models;

namespace Movies.DataAccess.Repository.IRepository
{
    public interface IComment : IRepository<Comments>
    {
        void save();
    }
}
