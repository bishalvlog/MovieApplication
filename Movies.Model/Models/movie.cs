

namespace MovieApplication.Models
{
    public class movie :Base
    {
        
        public string Title { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }   
        public DateTime DateOfRelease { get; set; }   
        public string Imageurl { get; set; }
       public ICollection<moviedetails> details { get; set; }    
       public ICollection<moviecost> moviecost { get; set; }
    }
}
