using System;
using System.ComponentModel;
using System.Windows;

namespace PETCON.DesktopApp.Modules.CreateAppointment
{
    public partial class CreateAppointmentView
    {
        public CreateAppointmentView()
        {
            DataContext = new CreateAppointmentViewModel();
            InitializeComponent();
        }

        public CreateAppointmentViewModel ViewModel => DataContext as CreateAppointmentViewModel;

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            if (ViewModel == null) return;
            if (DesignerProperties.GetIsInDesignMode(this)) return;
            Loaded += OnLoaded;
            RegisterAppointmentButton.Click += RegisterAppointmentButtonOnClick;
            ReturnButton.Click += ReturnButtonOnClick;
        }

        private void ReturnButtonOnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void RegisterAppointmentButtonOnClick(object sender, RoutedEventArgs e)
        {
            await ViewModel.CreateAppointment();
            Close();
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.Load();
        }
    }
}