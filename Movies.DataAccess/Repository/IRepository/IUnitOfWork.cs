using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ImovieRepository ImovieRepository { get; }

        void save();
    }
}
