using System;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Models;
using OrangeBricks.Web.Controllers.Appointments.ViewModels;

namespace OrangeBricks.Web.Controllers.Property.Builders
{
    public class PropertiesViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public PropertiesViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public PropertiesViewModel Build(PropertiesQuery query)
        {
            var properties = _context.Properties
                .Where(p => p.IsListedForSale);

            if (!string.IsNullOrWhiteSpace(query.Search))
            {
                properties = properties.Where(x => x.StreetName.Contains(query.Search) 
                    || x.Description.Contains(query.Search));
            }

            return new PropertiesViewModel
            {
                Properties = properties
                    .ToList()
                    .Select(MapViewModel)
                    .ToList(),
                Search = query.Search
            };
        }

        private PropertyViewModel MapViewModel(Models.Property property)
        {
            return new PropertyViewModel
            {
                Id = property.Id,
                StreetName = property.StreetName,
                Description = property.Description,
                NumberOfBedrooms = property.NumberOfBedrooms,
                PropertyType = property.PropertyType,
                AppointmentId = _context.Appointments.FirstOrDefault(x => x.PropertyId == property.Id) == null ? 0 : _context.Appointments.FirstOrDefault(x => x.PropertyId == property.Id).Id,
                AppointmentStatus = _context.Appointments.FirstOrDefault(x => x.PropertyId == property.Id) == null ? SlotStatus.Available : (SlotStatus)_context.Appointments.FirstOrDefault(x => x.PropertyId == property.Id).Status
            };
        }
    }
}