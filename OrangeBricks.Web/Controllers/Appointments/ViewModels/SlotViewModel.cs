using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Appointments.ViewModels
{
    public enum SlotStatus
    {
        Available,
        Booked,
        Attended,
        OfferPlaced,
        OfferedAccepted,
        OfferedRejected
    }
    public class SlotViewModel
    {
        public int PropertyId { get; set; }
        public string Address { get; set; }
        public List<SchedulePeriod> Schedules { get; set; }
        public string BuyerUserId { get; set; }
        public SlotViewModel()
        {
            Schedules = new List<SchedulePeriod>();
        }
    }
    public class SchedulePeriod
    {
      //  
        public DateTime ScheduleDate { get; set; }
        public List<Slot> Slots { get; set; }
        public SchedulePeriod()
        {
            Slots = new List<Slot>();
        }
    }

    public class Slot
    {
        //  public int PropertyId { get; set; }
        public DateTime SlotDateTime { get; set; }
        public SlotStatus Status { get; set; }
    }

}