using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Gameblasts.Extensions;
using Microsoft.AspNetCore.Authentication;

namespace Gameblasts.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        /*public async Task<ClaimsIdentity> GenerateUserIdentityAsync(
                UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in 
            // CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }*/

        public ApplicationUser(){}
        public ApplicationUser(string UserName, string Email)
        {
            this.UserName = UserName;
            this.Email = Email;
            this.AboutInfo = "Not set";
            this.MemberTitle = "Not set";
            this.Gender = "Not set";
            this.Location = "Not set";
            this.SocialMediaNames = "Not set";
            this.PostCount = 0;
            this.Age = 0;
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
