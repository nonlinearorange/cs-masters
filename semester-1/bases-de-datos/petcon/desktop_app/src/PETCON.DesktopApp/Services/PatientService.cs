using System.Collections.Generic;
using System.Linq;
using NHibernate;
using PETCON.DesktopApp.Models.Patient;

namespace PETCON.DesktopApp.Services
{
    public static class PatientService
    {
        public static IEnumerable<Patient> GetAll()
        {
            ISession session = SessionBuilder.CreateOpenSession();
            List<Patient> patients = session.Query<Patient>()
                .Where(p => p.IsActive)
                .ToList();

            return patients;
        }
    }
}