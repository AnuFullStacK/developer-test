using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrangeBricks.Web.Models;
using OrangeBricks.Web.Controllers.Appointments.Commands;
using OrangeBricks.Web.Controllers.Appointments.ViewModels;
using System.Globalization;

namespace OrangeBricks.Web.Controllers.Appointments.Builders
{
    public class MarkAttendanceCommandHandler
    {
        private readonly IOrangeBricksContext _context;

        public MarkAttendanceCommandHandler(IOrangeBricksContext context)
        {
            _context = context;
        }

        public void Handle(int id)
        {
            var appointment = _context.Appointments.Find(id);
            if (appointment != null)
            {
                appointment.Status = (int) SlotStatus.Attended;
            }
            _context.SaveChanges();
        }
    }
}