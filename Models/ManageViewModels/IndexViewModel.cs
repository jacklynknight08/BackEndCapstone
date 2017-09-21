using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BackEndCapstone.Models.ManageViewModels
{
    public class IndexViewModel
    {
        // Set an instance of an application user, inherits from Identity
        public ApplicationUser AppUser { get; set; }
        public bool HasPassword { get; set; }

        public IList<UserLoginInfo> Logins { get; set; }

        public string PhoneNumber { get; set; }

        public bool TwoFactor { get; set; }

        public bool BrowserRemembered { get; set; }

        // Give appuser access to appointments
        public ICollection<Appointment> Appointments { get; set; }

        // IndexViewModel will be used in ManageController for Index.cshtml and Edit.cshtml
        public IndexViewModel()
        {
            AppUser = new ApplicationUser();
        }
    }
}
