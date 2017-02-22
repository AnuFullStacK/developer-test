namespace OrangeBricks.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Schedule
    {
        [Key]
        public int Id { get; set; }

        public DateTime StartDatetime { get; set; }

        public DateTime EndDatetime { get; set; }

        public int PropertyId { get; set; }

        public int Slottime { get; set; }

        [StringLength(128)]
        public string Createdby { get; set; }

        public DateTime CreatedAt { get; set; }

        public Property Property { get; set; }
    }
}
