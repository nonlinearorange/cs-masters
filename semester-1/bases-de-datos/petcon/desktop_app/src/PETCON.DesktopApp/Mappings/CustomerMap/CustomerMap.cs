using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using PETCON.DesktopApp.Models.Customer;

namespace PETCON.DesktopApp.Mappings.CustomerMap
{
    public class CustomerMap : ClassMapping<Customer>
    {
        public CustomerMap()
        {
            Table("customer");
            Lazy(false);

            Id(x => x.Identifier, m =>
            {
                m.Column("id");
                m.Generator(Generators.Assigned);
            });

            Property(x => x.FirstName, m => m.Column("first_name"));
            Property(x => x.LastName, m => m.Column("last_name"));
            Property(x => x.Email, m => m.Column("email"));
            Property(x => x.CreatedAt, m => m.Column("created_at"));
            Property(x => x.IsActive, m => m.Column("is_active"));
        }
    }
}