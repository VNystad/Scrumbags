using System;
using System.ComponentModel.DataAnnotations;

namespace Gameblasts.Models
{
    public class Message
    {
        public Message(string subject, string msg, string from, string receiver)
        {
            this.Subject = subject;
            this.Msg = msg;
            this.From = from;
            this.Receiver = receiver;
            this.Date = DateTime.Now;
            this.Read = false;
        }

        [Required]
        [KeyAttribute]
        public int Id { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Msg { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string From{get; set;}
        [Required]
        public string Receiver{get; set;}
        [Required]
        public bool Read { get; set; }
    }
}
