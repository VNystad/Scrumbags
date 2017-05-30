using System;
using System.ComponentModel.DataAnnotations;

namespace Gameblasts.Models.MessageViewModels
{
    public class MessageViewModel
    {
        [Required]
        public string Subject{ get; set;}

        [Required]
        public string Msg{ get; set;}
        
        [Required]
        public string Sender{ get; set;}
        [Required]
        public string Receiver { get; set; }

        public DateTime Date { get; set; }
    }
}
