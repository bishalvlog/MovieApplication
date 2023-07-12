using Movies.DataAccess.Data;
using Movies.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DataAccess.Repository
{
    public class CommentRepository : Repository<Comments>, IRepository.IComment
    {
        private readonly ApplicationDbContent _content;
        public CommentRepository(ApplicationDbContent content) :base(content)
        {
            _content = content;

        }
        public void save()
        {
            _content.SaveChanges();
           
        }
    }
}
