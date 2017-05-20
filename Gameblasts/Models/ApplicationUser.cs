using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Gameblasts.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser(){}
        public ApplicationUser(string UserName, string Email)
        {
            this.UserName = UserName;
            this.Email = Email;
            this.AboutInfo = "fillinForTest";
            this.MemberTitle = "TestTitle";
            this.RegisterDate = DateTime.Now.Date;
        }

        [Required]
        public string AboutInfo { get; set; }
        [Required]
        public string MemberTitle { get; set; }
        public string Location { get; set; }
        public string Gender { get; set; }
        public string SocialMediaNames { get; set; }
        public int Age { get; set; }
        public int PostCount { get; set; }
        [Required]
        public DateTime RegisterDate { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        
    }
}
