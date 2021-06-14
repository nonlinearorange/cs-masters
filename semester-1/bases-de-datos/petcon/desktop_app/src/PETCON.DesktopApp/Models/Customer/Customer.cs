using System;

namespace PETCON.DesktopApp.Models.Customer
{
    public class Customer
    {
        public Guid Identifier { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsActive { get; set; }
    }
}