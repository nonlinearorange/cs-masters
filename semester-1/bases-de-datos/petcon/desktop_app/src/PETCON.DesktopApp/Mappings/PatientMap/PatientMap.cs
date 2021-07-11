using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using PETCON.DesktopApp.Models.Patient;

namespace PETCON.DesktopApp.Mappings.PatientMap
{
    public class PatientMap : ClassMapping<Patient>
    {
        public PatientMap()
        {
            Table("patient");
            Lazy(false);

            Id(x => x.Identifier, m =>
            {
                m.Column("id");
                m.Generator(Generators.Assigned);
            });

            Property(x => x.Name, m => { m.Column("name"); });
            Property(x => x.Weight, m => { m.Column("weight"); });
            Property(x => x.DateOfBirth, m => { m.Column("date_of_birth"); });
            Property(x => x.SpeciesId, m => { m.Column("species_id"); });
            Property(x => x.OwnerId, m => { m.Column("owner_id"); });
            Property(x => x.CreatedAt, m => { m.Column("created_at"); });
            Property(x => x.IsActive, m => { m.Column("is_active"); });
        }
    }
}