using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApplication.Models
{
    public class moviecost :Base 
    {
        public string FirstPhase { get; set; }  
        public string MiddlePhase { get; set; } 
        public string LastPhase { get; set; }  
        
        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public movie movies { get; set; }   


    }
}
