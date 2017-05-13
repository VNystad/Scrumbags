using System;
using System.ComponentModel.DataAnnotations;

/* Modellen for chatmessage nå ha en id som bli auto-inkrementert.
   Den må også ha hvilken bruker som lagde meldingen, datoen til når den var sendt,
   og innholdet til meldingen. 

   Alle feltene MÅ være med når en skal lage nye meldinger. 
*/

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

        [Required(ErrorMessage="* A {0} is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "* {0} must be between {2} and {1} characters in length.")]
        public string Message{get; set;}
    }
}