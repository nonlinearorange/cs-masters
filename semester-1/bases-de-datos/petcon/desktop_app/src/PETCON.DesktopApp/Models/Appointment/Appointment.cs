using System;

namespace PETCON.DesktopApp.Models.Appointment
{
    public class Appointment
    {
        public Guid Identifier { get; set; }

        public Guid CreatedBy { get; set; }

        public Guid DesignatedTo { get; set; }

        public Guid PatientId { get; set; }

        public DateTime DueTo { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsActive { get; set; }
    }
}