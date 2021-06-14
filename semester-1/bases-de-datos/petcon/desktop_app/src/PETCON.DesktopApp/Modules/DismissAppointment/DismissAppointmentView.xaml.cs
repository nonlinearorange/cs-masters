using System;
using System.Windows;

namespace PETCON.DesktopApp.Modules.DismissAppointment
{
    public partial class DismissAppointmentView
    {
        public DismissAppointmentView()
        {
            DataContext = new DismissAppointmentViewModel();
            InitializeComponent();

            CancelButton.Click += CancelButtonOnClick;
            ReturnButton.Click += ReturnButtonOnClick;
        }

        private void ReturnButtonOnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void CancelButtonOnClick(object sender, RoutedEventArgs e)
        {
            bool canClose = await ViewModel.ExecuteDismiss();
            if (!canClose) return;

            ItemDeleted.Invoke(ViewModel.AppointmentId);
            Close();
        }

        public DismissAppointmentViewModel ViewModel => DataContext as DismissAppointmentViewModel;

        public Action<Guid> ItemDeleted;
    }
}