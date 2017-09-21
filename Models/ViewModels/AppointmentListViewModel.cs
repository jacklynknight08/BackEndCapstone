using System;
using System.Linq;
using BackEndCapstone.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BackEndCapstone.Models.ViewModels
{
    public class AppointmentListViewModel
    {
        public IEnumerable<AppointmentServiceViewModel> AppointmentServiceViewModel {get; set;}

    }
}