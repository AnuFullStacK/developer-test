using System;
using OrangeBricks.Web.Models;
using System.Linq;
using OrangeBricks.Web.Controllers.Appointments.ViewModels;

namespace OrangeBricks.Web.Controllers.Offers.Commands
{
    public class RejectOfferCommandHandler
    {
        private readonly IOrangeBricksContext _context;

        public RejectOfferCommandHandler(IOrangeBricksContext context)
        {
            _context = context;
        }

        public void Handle(RejectOfferCommand command)
        {
            var offer = _context.Offers.Find(command.OfferId);

            offer.UpdatedAt = DateTime.Now;
            offer.Status = OfferStatus.Rejected;

            var appointment = _context.Appointments.FirstOrDefault(x => x.PropertyId == command.PropertyId);
            appointment.Status = (int)SlotStatus.OfferedRejected;

            _context.SaveChanges();
        }
    }
}