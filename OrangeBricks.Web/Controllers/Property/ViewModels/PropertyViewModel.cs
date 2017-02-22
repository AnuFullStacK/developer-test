using OrangeBricks.Web.Controllers.Appointments.ViewModels;
namespace OrangeBricks.Web.Controllers.Property.ViewModels
{
    public class PropertyViewModel
    {
        public string StreetName { get; set; }
        public string Description { get; set; }
        public int NumberOfBedrooms { get; set; }
        public string PropertyType { get; set; }
        public int Id { get; set; }
        public bool IsListedForSale { get; set; }
        public int AppointmentId { get; set; }
        public SlotStatus AppointmentStatus { get; set; }
    }
}