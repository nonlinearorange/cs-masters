using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using PETCON.DesktopApp.Models.Appointment;

namespace PETCON.DesktopApp.Services
{
    public static class AppointmentService
    {
        public static IEnumerable<ConsolidatedAppointment> GetAllConsolidated()
        {
            using (ISession session = SessionBuilder.CreateOpenSession())
            {
                List<ConsolidatedAppointment> consolidated = session.Query<ConsolidatedAppointment>()
                    .Where(c => c.IsActive)
                    .ToList();

                return consolidated;
            }
        }

        public static IEnumerable<Appointment> GetAll()
        {
            using (ISession session = SessionBuilder.CreateOpenSession())
            {
                List<Appointment> appointments = session.Query<Appointment>()
                    .Where(a => a.IsActive)
                    .ToList();

                return appointments;
            }
        }

        public static bool Disable(Guid id)
        {
            using (ISession session = SessionBuilder.CreateOpenSession())
            using (ITransaction tx = session.BeginTransaction())
            {
                Appointment appointment = session.Query<Appointment>().FirstOrDefault(x => x.Identifier == id);
                if (appointment != null)
                {
                    appointment.IsActive = false;
                    session.Update(appointment);
                }
                else
                {
                    return false;
                }

                tx.Commit();

                return true;
            }
        }

        public static void Create(NewAppointment newAppointment)
        {
            using (ISession session = SessionBuilder.CreateOpenSession())
            using (ITransaction tx = session.BeginTransaction())
            {
                Appointment appointment = new Appointment
                {
                    Identifier = newAppointment.Identifier,
                    CreatedBy = newAppointment.CreatedBy,
                    DesignatedTo = newAppointment.DesignatedTo,
                    PatientId = newAppointment.PatientId,
                    DueTo = newAppointment.DueTo,
                    CreatedAt = DateTime.Now, // Change to DB default.
                    IsActive = true // Change to DB default.
                };

                session.Save(appointment);

                tx.Commit();
            }
        }
    }
}