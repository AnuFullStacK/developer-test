using System.Collections;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OrangeBricks.Web.Attributes;
using OrangeBricks.Web.Controllers.Appointments.Builders;
using OrangeBricks.Web.Models;
using OrangeBricks.Web.Controllers.Appointments.Commands;
using OrangeBricks.Web.Controllers.Appointments.ViewModels;

namespace OrangeBricks.Web.Controllers.Appointments
{
    public class AppointmentsController : Controller
    {
//
        private readonly IOrangeBricksContext _context;

        public AppointmentsController(IOrangeBricksContext context)
        {
            _context = context;
        }

        // GET: Appointment Slots
        [OrangeBricksAuthorize(Roles = "Buyer")]
        public ActionResult ViewSlot(PropertyInfo property )
        {
            var builder = new SlotViewModelBuilder(_context);
            SlotViewModel scheduleInformation = new SlotViewModel();
            scheduleInformation.Address = property.StreetName;
            scheduleInformation.PropertyId = property.Id;
            scheduleInformation.Schedules.AddRange(builder.Build(property.Id));
            return View(scheduleInformation);
        }

        [HttpPost]
        [OrangeBricksAuthorize(Roles = "Buyer")]
        public ActionResult BookAppointment(BookAppointmentCommand command)
        {
            command.BuyerUserId = User.Identity.GetUserId();
            var builder = new BookAppointmentCommandHandler(_context);
            builder.Handle(command);
            return RedirectToAction("Index", "Property", new { id=command.PropertyId});
        }
    }
}