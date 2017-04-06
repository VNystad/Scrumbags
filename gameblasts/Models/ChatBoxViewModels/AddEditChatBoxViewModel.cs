using System.ComponentModel.DataAnnotations;

namespace Gameblasts.Models.PostViewModels
{
    public class AddEditChatBoxViewModel
    {
        [Required]
        [Display(Name = "New Title")]
        public string Title{get; set;}

        [Required]
        [Display(Name = "New Body")]
        public string Body{get; set;}
    }
}
