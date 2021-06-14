using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using PETCON.DesktopApp.Models.Appointment;
using PETCON.DesktopApp.Modules.DismissAppointment;
using PETCON.DesktopApp.Modules.Login;

namespace PETCON.DesktopApp.Modules.Main
{
    public partial class MainView
    {
        public MainView()
        {
            DataContext = new MainViewModel();
            InitializeComponent();
        }

        public MainViewModel ViewModel => DataContext as MainViewModel;

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            if (ViewModel == null) return;
            if (DesignerProperties.GetIsInDesignMode(this)) return;

            Loaded += OnLoaded;
            LogoutButton.Click += LogoutButtonOnClick;
        }

        private void LogoutButtonOnClick(object sender, RoutedEventArgs e)
        {
            LoginView view = new LoginView();
            view.Show();
            Close();
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.Load();
        }

        private async void AttendButtonOnClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (!(button?.Tag is ConsolidatedAppointment appointment)) return;
            {
                button.IsEnabled = false;

                await ViewModel.AttendAppointment(appointment.Identifier);

                button.IsEnabled = true;
            }
        }

        private void DismissButtonOnClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (!(button?.Tag is ConsolidatedAppointment appointment)) return;
            {
                button.IsEnabled = false;

                DismissAppointmentView view = new DismissAppointmentView();
                view.ItemDeleted += ItemDeleted;
                view.ViewModel.ProvideAppointment(appointment.Identifier);
                view.ShowDialog();

                button.IsEnabled = true;
            }
        }

        private async void ItemDeleted(Guid guid)
        {
            await ViewModel.DismissAppointment(guid);
        }
    }
}