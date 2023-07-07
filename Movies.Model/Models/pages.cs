using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Model.Models
{
    public class pages
    {
        public int TotalItems { get; private set; }
        public int CureentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPage { get; private set; }
        public int StartPage{ get;private set;  }
        public int EndPage { get;private set;}

        public pages()
        {

        }
        public pages(int totalItems, int page, int pageSize =10)
        {
          int  totalpage = (int)Math.Ceiling((decimal)totalItems/(decimal)pageSize);
            int currentPage = page;
            int startPage = currentPage - 5;
            int endPage = currentPage + 4;

            if (startPage < 0)
            {
                endPage = endPage -(startPage-1);
                startPage = 1;
            }
            if (endPage > totalpage)
            {
                endPage = totalpage;
                if(endPage>10)
                {
                    startPage = endPage - 9;
                }
            }
            TotalItems =totalpage;
            CureentPage = currentPage;
            PageSize = pageSize;
            TotalPage = totalpage;
            StartPage = startPage;
            EndPage = endPage;
            
        }
    }
}
