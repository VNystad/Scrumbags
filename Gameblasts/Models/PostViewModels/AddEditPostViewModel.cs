
using System.ComponentModel.DataAnnotations;


namespace Gameblasts.Models.PstViewModels
{
    public class PostViewModel
    {
        [Required]
        [Display(Name = "New Title")]
        public string Title{get; set;}

        [Required]
        [Display(Name = "New Body")]
        public string Body{get; set;}
    }
}
