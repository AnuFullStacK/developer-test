using OrangeBricks.Web.Models;
using System;

namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class CreatePropertyCommandHandler
    {
        private readonly IOrangeBricksContext _context;

        public CreatePropertyCommandHandler(IOrangeBricksContext context)
        {
            _context = context;
        }

        public void Handle(CreatePropertyCommand command)
        {
            var property = new Models.Property
            {
               PropertyType = command.PropertyType,
               StreetName = command.StreetName,
               Description = command.Description,
               NumberOfBedrooms = command.NumberOfBedrooms
            };

            property.SellerUserId = command.SellerUserId;
            _context.Properties.Add(property);

            // adding a default Schedule for 3 days from next day from post of the advertisment between 09:00 - 11:00 of 30 mins slot each.
            // perhaps it is a bigh workflow in real time.

            var schedule = new Models.Schedule
            {
                Createdby = command.SellerUserId,
                StartDatetime = DateTime.Now.AddDays(1).Date.AddHours(9),
                EndDatetime = DateTime.Now.AddDays(3).Date.AddHours(11),
                PropertyId = property.Id,
                Slottime = 30,
                CreatedAt = DateTime.Now
            };
            _context.Schedules.Add(schedule);
            _context.SaveChanges();
        }
    }
}