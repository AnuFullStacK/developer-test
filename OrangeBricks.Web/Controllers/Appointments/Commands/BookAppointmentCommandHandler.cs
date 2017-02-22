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
    public class BookAppointmentCommandHandler
    {
        private readonly IOrangeBricksContext _context;

        public BookAppointmentCommandHandler(IOrangeBricksContext context)
        {
            _context = context;
        }

        public void Handle(BookAppointmentCommand command)
        {
            var appointment = new Models.Appointment
            {
                PropertyId = command.PropertyId,
                StartDatetime = Convert.ToDateTime(command.StartDatetime),
                EndDatetime = Convert.ToDateTime(command.StartDatetime).AddMinutes(30),
                Status = (int) SlotStatus.Booked,
                BuyerUserId = command.BuyerUserId
            };
            _context.Appointments.Add(appointment);

            _context.SaveChanges();
        }
    }
}