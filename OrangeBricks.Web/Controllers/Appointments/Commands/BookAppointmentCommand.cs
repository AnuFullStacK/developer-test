using OrangeBricks.Web.Controllers.Appointments.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Appointments.Commands
{
    public class BookAppointmentCommand
    {
        public DateTime StartDatetime { get; set; }
        public DateTime EndDatetime { get; set; }
        public int PropertyId { get; set; }
        public string BuyerUserId { get; set; }
        public SlotStatus Status { get; set; }
    }
}