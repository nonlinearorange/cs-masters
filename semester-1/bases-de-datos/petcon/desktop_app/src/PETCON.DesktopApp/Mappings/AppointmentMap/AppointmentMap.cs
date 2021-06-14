using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using PETCON.DesktopApp.Models.Appointment;

namespace PETCON.DesktopApp.Mappings.AppointmentMap
{
    public class AppointmentMap : ClassMapping<Appointment>
    {
        public AppointmentMap()
        {
            Table("appointment");
            Lazy(false);

            Id(x => x.Identifier, m =>
            {
                m.Column("id");
                m.Generator(Generators.Assigned);
            });

            Property(x => x.CreatedBy, m => m.Column("created_by"));
            Property(x => x.DesignatedTo, m => m.Column("designated_to"));
            Property(x => x.DueTo, m => m.Column("due_to"));
            Property(x => x.PatientId, m => m.Column("patient_id"));
            Property(x => x.CreatedAt, m => m.Column("created_at"));
            Property(x => x.IsActive, m => m.Column("is_active"));
        }
    }
}