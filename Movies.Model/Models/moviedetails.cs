using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApplication.Models
{
    public class moviedetails :Base
    {
        public string ProducerName { get; set; }    
        public string DirectorName { get; set; }    
        public string ActorName { get; set; }   
        public string ActressName { get; set; } 
        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public movie movies { get; set; }   
       
    }
}
