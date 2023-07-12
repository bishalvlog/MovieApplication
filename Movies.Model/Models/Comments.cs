using MovieApplication.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.Model.Models
{
    public class Comments : Base
    {
        public string? Comment { get; set; } 

        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public movie Movie { get; set; }
        

    }
}
