using System.ComponentModel.DataAnnotations;

namespace Gameblasts.Models.ChatBoxViewModels
{
    public class AddEditChatBoxViewModel
    {
        [Required]
        [Display(Name = "New Message")]
        public string Message{get; set;}
    }
}
