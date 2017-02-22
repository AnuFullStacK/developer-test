using System;
using OrangeBricks.Web.Models;
using System.Linq;
using OrangeBricks.Web.Controllers.Appointments.ViewModels;

namespace OrangeBricks.Web.Controllers.Offers.Commands
{
    public class AcceptOfferCommandHandler
    {
        private readonly IOrangeBricksContext _context;

        public AcceptOfferCommandHandler(IOrangeBricksContext context)
        {
            _context = context;
        }

        public void Handle(AcceptOfferCommand command)
        {
            var offer = _context.Offers.Find(command.OfferId);

            offer.UpdatedAt = DateTime.Now;
            offer.Status = OfferStatus.Accepted;

       
            var appointment = _context.Appointments.FirstOrDefault(x => x.PropertyId == command.PropertyId);
            appointment.Status = (int)SlotStatus.OfferedAccepted;

            _context.SaveChanges();
        }
    }
}