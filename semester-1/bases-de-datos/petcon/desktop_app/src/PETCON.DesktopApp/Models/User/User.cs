using System;
using PETCON.DesktopApp.Enums;

namespace PETCON.DesktopApp.Models.User
{
    public class User
    {
        public Guid Identifier { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public SystemRoleType SystemRole { get; set; }

        public EmployeeRoleType EmployeeRole { get; set; }

        public DateTime CreatedAt { get; set; }
        
        public bool IsActive { get; set; }
    }
}