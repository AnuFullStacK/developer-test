using OrangeBricks.Web.Controllers.Appointments.ViewModels;
using OrangeBricks.Web.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace OrangeBricks.Web.Controllers.Appointments.Builders
{
    public class SlotViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public SlotViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public IEnumerable<SchedulePeriod> Build(int id)
        {
            // Default Slot set to 30 mins.
            int slotTime = 30; 
            var schedule = _context.Schedules.SingleOrDefault(x=> x.PropertyId == id);
                    
            var appointments = _context.Appointments.Where(x => x.PropertyId == id).ToList();

            return GenerateSlots(schedule, appointments, slotTime);
        }

        private  List<SchedulePeriod> GenerateSlots(Schedule scheduled, IEnumerable<Appointment> appointments, int slotInterval)
        {
            List <SchedulePeriod> dateWiseSchedules= new List<SchedulePeriod>();

            double dateDifference =  (scheduled.EndDatetime.Date - scheduled.StartDatetime.Date).TotalDays;
            for(int days=0;days <= dateDifference; days++)
            {
                var currentStarttime = scheduled.StartDatetime.AddDays(days);
                var currentEndtime = currentStarttime.Date.AddHours(scheduled.EndDatetime.Hour).AddMinutes(scheduled.EndDatetime.Minute);
                var dateSlot = new SlotViewModel();
                SchedulePeriod schedule = new SchedulePeriod();
                schedule.ScheduleDate = currentStarttime.Date;
                var dayslots = new List<Slot>();
                while (currentStarttime < currentEndtime)
                {
                    var slot = new Slot()
                    {
                        SlotDateTime = currentStarttime,
                        Status = (appointments.FirstOrDefault(x => x.StartDatetime == currentStarttime) != null) ? SlotStatus.Booked : SlotStatus.Available
                    };
                    dayslots.Add(slot);
                    currentStarttime = currentStarttime.AddMinutes(30);
                }
                schedule.Slots.AddRange(dayslots); 
                dateWiseSchedules.Add(schedule);
            }

            return dateWiseSchedules;
        }
    }
}