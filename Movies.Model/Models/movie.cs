
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace MovieApplication.Models
{
    public class movie : Base
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public DateTime DateOfRelease { get; set; }
        [ValidateNever]
        public string Imageurl { get; set; }
        public ICollection<moviedetails>? details { get; set; }
        public ICollection<moviecost>? moviecost { get; set; }
    }
}
