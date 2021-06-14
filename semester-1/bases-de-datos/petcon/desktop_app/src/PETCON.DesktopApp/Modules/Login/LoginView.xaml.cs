using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PETCON.DesktopApp.Modules.Main;

namespace PETCON.DesktopApp.Modules.Login
{
    public partial class LoginView
    {
        public LoginView()
        {
            DataContext = new LoginViewModel();
            InitializeComponent();
        }

        public LoginViewModel ViewModel => DataContext as LoginViewModel;

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            if (ViewModel == null) return;
            if (DesignerProperties.GetIsInDesignMode(this)) return;

            Loaded += OnLoaded;
            LoginButton.Click += LoginButtonOnClick;
            CleanButton.Click += CleanButtonOnClick;
            PasswordBox.PasswordChanged += PasswordBoxOnPasswordChanged;
            EmailTextBox.KeyDown += EmailTextBoxOnKeyDown;
            PasswordBox.KeyDown += PasswordBoxOnKeyDown;
        }

        private async void PasswordBoxOnKeyDown(object sender, KeyEventArgs e)
        {
            await EnterTriggerLogin(e);
        }

        private async void EmailTextBoxOnKeyDown(object sender, KeyEventArgs e)
        {
            await EnterTriggerLogin(e);
        }

        private async Task EnterTriggerLogin(KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                await PerformLogin();
            }
        }

        private void PasswordBoxOnPasswordChanged(object sender, RoutedEventArgs e)
        {
            ViewModel.Password = PasswordBox.Password;
        }

        private async void LoginButtonOnClick(object sender, RoutedEventArgs e)
        {
            await PerformLogin();
        }

        private async Task PerformLogin()
        {
            bool canLogin = await ViewModel.Login();
            if (!canLogin) return;

            MainView view = new MainView();
            view.Show();
            Close();
        }

        private void CleanButtonOnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.Clean();
            PasswordBox.Password = string.Empty;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
        }
    }
}