using System.Threading.Tasks;
using PETCON.DesktopApp.Helpers;
using PETCON.DesktopApp.Models.User;
using PETCON.DesktopApp.Services;

namespace PETCON.DesktopApp.Modules.Login
{
    public class LoginViewModel : BindableBase
    {
        private string _password;
        private string _email;
        private bool _canLogin;
        private string _notification;

        public LoginViewModel()
        {
            CanLogin = true;
        }

        public bool CanLogin
        {
            get => _canLogin;
            set
            {
                _canLogin = value;
                OnPropertyChanged(nameof(CanLogin));
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string Notification
        {
            get => _notification;
            set
            {
                _notification = value;
                OnPropertyChanged(nameof(Notification));
            }
        }

        public async Task<bool> Login()
        {
            CanLogin = false;

            User user = await Task.Run(() => LoginService.VerifyUserExists(Email, Password));
            if (user == null)
            {
                Notification = "Correo o contraseña incorrectos.";
            }
            else
            {
                Globals.CurrentUser = user;
            }

            CanLogin = true;


            return user != null;
        }

        public void Clean()
        {
            Email = string.Empty;
            Password = string.Empty;
        }
    }
}