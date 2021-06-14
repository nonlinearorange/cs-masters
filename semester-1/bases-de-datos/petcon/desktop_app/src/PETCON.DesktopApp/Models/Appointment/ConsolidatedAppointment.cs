using System;

namespace PETCON.DesktopApp.Models.Appointment
{
    public class ConsolidatedAppointment
    {
        public Guid Identifier { get; set; }

        public DateTime DueTo { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid PatientId { get; set; }

        public string PatientName { get; set; }

        public DateTime PatientDateOrBirth { get; set; }

        public double PatientWeight { get; set; }

        public Guid CustomerId { get; set; }

        public string CustomerFirstName { get; set; }

        public string CustomerLastName { get; set; }

        public Guid UserId { get; set; }

        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }

        public string UserEmail { get; set; }

        public bool IsActive { get; set; }
    }
}