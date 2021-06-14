using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;
using PETCON.DesktopApp.Enums;
using PETCON.DesktopApp.Models.User;

namespace PETCON.DesktopApp.Mappings.UserMap
{
    public class UserMap : ClassMapping<User>
    {
        public UserMap()
        {
            Table("user");
            Lazy(false);

            Id(x => x.Identifier, m =>
            {
                m.Column("id");
                m.Generator(Generators.Assigned);
            });

            Property(x => x.Email, m => m.Column("email"));
            Property(x => x.Password, m => m.Column("password"));
            Property(x => x.FirstName, m => m.Column("first_name"));
            Property(x => x.LastName, m => m.Column("last_name"));
            Property(x => x.SystemRole, m =>
            {
                m.Column("system_role_id");
                m.Type<EnumType<SystemRoleType>>();
            });
            Property(x => x.EmployeeRole, m =>
            {
                m.Column("employee_role_id");
                m.Type<EnumType<EmployeeRoleType>>();
            });
            Property(x => x.CreatedAt, m => m.Column("created_at"));
            Property(x => x.IsActive, m => m.Column("is_active"));
        }
    }
}