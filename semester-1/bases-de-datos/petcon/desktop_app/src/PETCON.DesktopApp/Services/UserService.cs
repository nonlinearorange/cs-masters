using System.Collections.Generic;
using System.Linq;
using NHibernate;
using PETCON.DesktopApp.Models.User;

namespace PETCON.DesktopApp.Services
{
    public static class UserService
    {
        public static IEnumerable<User> GetAll()
        {
            ISession session = SessionBuilder.CreateOpenSession();
            List<User> users = session.Query<User>().ToList();

            return users;
        }
    }
}