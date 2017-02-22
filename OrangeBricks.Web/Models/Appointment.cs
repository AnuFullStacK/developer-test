namespace OrangeBricks.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;


    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        public int PropertyId { get; set; }

        public DateTime StartDatetime { get; set; }

        public DateTime EndDatetime { get; set; }

        public byte Status { get; set; }

        [Required]
        public string BuyerUserId { get; set; }

        public virtual Property Property { get; set; }
    }
}
