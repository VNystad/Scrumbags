using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;

namespace Gameblasts.Models
{
    /** ApplicationUser class:
    *   Parameter:  UserName(string), Email(string)
    *   Properties: ImgAdress(string, url to the profile image), MemberTitle(string, ranking system in forum),
    *               Location(string, user location), Gender(string), SocialMediaNames(string), 
    *               Age(int, user age), PostCount(int, count of posts made by user), 
    *               MsgSent(int, count of msgs sent by user, not working), 
    *               UnreadMsg(bool, true if user got an unread msg),
    *               RegisterDate(Date), Posts(Post, List of posts the user has made),
    *               Messages(Message, List of messages the user had made, not working).
    */
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser(){}
        public ApplicationUser(string UserName, string Email)
        {
            this.UserName = UserName;
            this.Email = Email;
            this.About = "Not set";
            this.MemberTitle = "Not set";
            this.Gender = "Not set";
            this.Location = "Not set";
            this.SocialMediaNames = "Not set";
            this.PostCount = 0;
            this.Age = 0;
            this.RegisterDate = DateTime.Now.Date;
            this.UnreadMsg = false;
        }

        [Required]
        public string About { get; set; }
        public string ImgAdress { get; set;}
        [Required]
        public string MemberTitle { get; set; }
        public string Location { get; set; }
        public string Gender { get; set; }
        public string SocialMediaNames { get; set; }
        public int Age { get; set; }
        public int PostCount { get; set; }
        public int MsgSent { get; set; }
        public bool UnreadMsg { get; set; }
        [Required]
        public DateTime RegisterDate { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
        
    }
}
