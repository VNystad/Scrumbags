using System;

namespace Gameblasts.Models.ProfileViewModels
{
    public class EditProfileViewModel
    {
        public string Username { get; set; }
        public string ImgAdress { get; set;}
        public string About { get; set; }
        public string Location { get; set; }
        public string Gender { get; set; }
        public string SocialMediaNames { get; set; }
        public int Age { get; set; }
    }
}
