
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace MovieApplication.Models
{
    public class Base
    {
        [Key]
        public int Id { get; set; } 
    }
}
