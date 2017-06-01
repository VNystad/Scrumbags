
using System;

namespace Gameblasts.Models.AdminPageViewModels
{
    ///This is the view model of the AdminPage. 
    ///This view model specifies which data from the AdminPage view to be sent to the AdminPage controller, 
    //which simply specifies that all variables are to be sent (email, new role).
    public class AdminPageChangeRoleViewModel
    {
        public string Name { get; set; }
        public string Role { get; set;}
    }
}
