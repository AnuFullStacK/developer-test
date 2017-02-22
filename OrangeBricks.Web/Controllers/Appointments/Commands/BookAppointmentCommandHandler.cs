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
            //Schedule schedule = new Schedule();
            //schedule.Createdby = command.BuyerUserId;
            //schedule.PropertyId = command.PropertyId;
//            string AppoinmentDateTime = command.StartDatetime;
            //command.EndDatetime =  command.StartDatetime.AddMinutes(30);
            //   sDateDate = Convert.ToDateTime(AppoinmentDateTime);
            //schedule.StartDatetime = AppointmentDate;
            //schedule.EndDatetime = AppointmentDate.AddMinutes(30);
            DateTime dt1 = Convert.ToDateTime(command.StartDatetime); //, "dd/MM/yyyy hh:mm:ss", CultureInfo.InvariantCulture);


            var appointment = new Models.Appointment
            {
                PropertyId = command.PropertyId,
                StartDatetime = dt1,
                EndDatetime = dt1.AddMinutes(30),
                Status = (int) SlotStatus.Booked,
                BuyerUserId = command.BuyerUserId
            };
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }
    }
}