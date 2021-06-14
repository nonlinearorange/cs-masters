using System.Linq;
using NHibernate;
using PETCON.DesktopApp.Models.User;

namespace PETCON.DesktopApp.Services
{
    public static class LoginService
    {
        public static User VerifyUserExists(string email, string password)
        {
            ISession session = SessionBuilder.CreateOpenSession();
            User user = session.Query<User>().FirstOrDefault(u => u.Email == email &&
                                                                  u.Password == password &&
                                                                  u.IsActive);

            return user;
        }
    }
}