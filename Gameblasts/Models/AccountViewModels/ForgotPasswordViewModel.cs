using System.ComponentModel.DataAnnotations;

namespace Gameblasts.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
