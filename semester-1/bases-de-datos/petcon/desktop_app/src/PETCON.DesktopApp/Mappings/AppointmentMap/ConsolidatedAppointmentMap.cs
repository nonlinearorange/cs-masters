using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using PETCON.DesktopApp.Models.Appointment;

namespace PETCON.DesktopApp.Mappings.AppointmentMap
{
    public class ConsolidatedAppointmentMap : ClassMapping<ConsolidatedAppointment>
    {
        public ConsolidatedAppointmentMap()
        {
            Table("appointment_consolidated");
            Lazy(false);

            Id(x => x.Identifier, m =>
            {
                m.Column("appointment_id");
                m.Generator(Generators.Assigned);
            });
            Property(x => x.DueTo, m => { m.Column("appointment_due_to"); });
            Property(x => x.CreatedAt, m => { m.Column("appointment_created_at"); });
            Property(x => x.PatientId, m => { m.Column("patient_id"); });
            Property(x => x.PatientName, m => { m.Column("patient_name"); });
            Property(x => x.PatientDateOrBirth, m => { m.Column("patient_date_of_birth"); });
            Property(x => x.PatientWeight, m => { m.Column("patient_weight"); });
            Property(x => x.CustomerId, m => { m.Column("customer_id"); });
            Property(x => x.CustomerFirstName, m => { m.Column("customer_first_name"); });
            Property(x => x.CustomerLastName, m => { m.Column("customer_last_name"); });
            Property(x => x.UserId, m => { m.Column("user_id"); });
            Property(x => x.UserFirstName, m => { m.Column("user_first_name"); });
            Property(x => x.UserLastName, m => { m.Column("user_last_name"); });
            Property(x => x.UserEmail, m => { m.Column("user_email"); });
            Property(x => x.IsActive, m => { m.Column("is_active"); });
        }
    }
}