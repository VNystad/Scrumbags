using System;

namespace Gameblasts.Models.ProfileViewModels
{
    public class ProfileViewModel
    {
        public string Username { get; set; }
        public string AboutInfo { get; set; }
        public string MemberTitle { get; set; }
        public string Location { get; set; }
        public string Gender { get; set; }
        public string SocialMediaNames { get; set; }
        public int Age { get; set; }
        public int PostCount { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
