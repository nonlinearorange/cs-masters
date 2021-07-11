using System;

namespace PETCON.DesktopApp.Models.Patient
{
    public class Patient
    {
        public Guid Identifier { get; set; }

        public string Name { get; set; }

        public double Weight { get; set; }

        public string DateOfBirth { get; set; }

        public int SpeciesId { get; set; }

        public Guid OwnerId { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsActive { get; set; }
    }
}