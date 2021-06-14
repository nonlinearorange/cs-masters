using System.Configuration;
using System.Data;
using NHibernate;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using PETCON.DesktopApp.Mappings.AppointmentMap;
using PETCON.DesktopApp.Mappings.CustomerMap;
using PETCON.DesktopApp.Mappings.UserMap;
using Configuration = NHibernate.Cfg.Configuration;

namespace PETCON.DesktopApp.Services
{
    public class SessionBuilder
    {
        private static ModelMapper BuildModelMapper()
        {
            ModelMapper mapper = new ModelMapper();
            mapper.AddMapping<AppointmentMap>();
            mapper.AddMapping<ConsolidatedAppointmentMap>();
            mapper.AddMapping<UserMap>();
            mapper.AddMapping<CustomerMap>();

            return mapper;
        }

        private static Configuration BuildConfiguration()
        {
            const string connectionName = "MariaDBConnectionString";
            string connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;

            Configuration cfg = new Configuration();
            cfg.DataBaseIntegration(db =>
            {
                db.ConnectionString = connectionString;
                db.Dialect<MySQLDialect>();
                db.Driver<MySqlDataDriver>();
                db.IsolationLevel = IsolationLevel.ReadCommitted;
                db.HqlToSqlSubstitutions = "true 1, false 0, yes 'Y', no 'N'";
            });
            cfg.AddAssembly(typeof(SessionBuilder).Assembly);

            ModelMapper mapper = BuildModelMapper();

            HbmMapping mappings = mapper.CompileMappingForAllExplicitlyAddedEntities();
            mappings.defaultlazy = false;
            mappings.autoimport = false;
            cfg.AddDeserializedMapping(mappings, null);

            return cfg;
        }

        public static ISession CreateOpenSession()
        {
            Configuration cfg = BuildConfiguration();
            ISessionFactory sessionFactory = cfg.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}