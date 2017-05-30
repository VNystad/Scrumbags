using System;
using System.ComponentModel.DataAnnotations;

namespace Gameblasts.Models
{
    public class Message
    {
        public Message(){}
        public Message(string subject, string msg, string sender, ApplicationUser receiver)
        {
            this.Subject = subject;
            this.Msg = msg;
            this.Sender = sender;
            this.Receiver = receiver;
            this.Date = DateTime.Now;
            this.Read = false;
        }

        [Required]
        [KeyAttribute]
        public int Id { get; set; }
        [Required]
        public ApplicationUser Receiver { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Msg { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Sender{get; set;}
        [Required]
        public bool Read { get; set; }
    }
}
