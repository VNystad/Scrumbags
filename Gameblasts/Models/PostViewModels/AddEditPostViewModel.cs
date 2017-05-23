
using System.ComponentModel.DataAnnotations;

namespace Gameblasts.Models.PostViewModels
{
    public class AddEditPostViewModel
    {
    

        [Required]
        [Display(Name = "New Title")]
        public string Title{get; set;}

        [Required]
        [Display(Name = "New Body")]
        public string Body{get; set;}
        
        [Required]
        [Display(Name = "Category")]
        public string SubCategory{get; set;}
    }
}
