using OrangeBricks.Web.Controllers.Appointments.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Appointments.Commands
{
    public class AppointmentStatusCommand
    {
        public int Id { get; set; }
        public SlotStatus Status { get; set; }
    }
}