using System;
using System.ComponentModel.DataAnnotations;

namespace Gameblasts.Models
{
    public class ChatMessage
    {
        public ChatMessage(){}
        public ChatMessage(string user, string message)
        {
            this.User = user;
            this.Message = message;
            this.Date = DateTime.Now;
        }

        [Required]
        [KeyAttribute]
        public int Id{get; set;}

        [Required]
        public string User{get; set;}

        [Required]
        public DateTime Date{get; set;}

        [Required]
        public string Message{get; set;}
    }
}