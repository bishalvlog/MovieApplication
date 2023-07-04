using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieApplication.Models;

namespace Movies.Model.VM
{
    public class MovieVM
    {
        public movie Movies { get; set; }

        [ValidateNever] 
        public IEnumerable<SelectListItem> MovieList { get; set; }
    }
}
