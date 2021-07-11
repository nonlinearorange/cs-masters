using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Threading;
using PETCON.DesktopApp.Helpers;
using PETCON.DesktopApp.Models.Appointment;
using PETCON.DesktopApp.Models.User;
using PETCON.DesktopApp.Services;

namespace PETCON.DesktopApp.Modules.Main
{
    public class MainViewModel : BindableBase
    {
        private string _currentTime;
        private User _currentUser;
        private string _userFullName;
        private string _searchQuery;

        public MainViewModel()
        {
            DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.Render)
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Tick += TimerOnTick;
            timer.Start();

            WorkingAppointments = new ObservableCollection<ConsolidatedAppointment>();
            ReferenceAppointments = new List<ConsolidatedAppointment>();
        }

        public string CurrentTime
        {
            get => _currentTime;
            set
            {
                _currentTime = value;
                OnPropertyChanged(nameof(CurrentTime));
            }
        }

        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }

        public string UserFullName
        {
            get => _userFullName;
            set
            {
                _userFullName = value;
                OnPropertyChanged(nameof(UserFullName));
            }
        }

        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value;
                OnPropertyChanged(nameof(SearchQuery));
                SearchForAppointment();
            }
        }

        public ObservableCollection<ConsolidatedAppointment> WorkingAppointments { get; }

        private List<ConsolidatedAppointment> ReferenceAppointments { get; set; }

        public async Task Load()
        {
            LoadUser();
            await LoadAppointments();
        }

        private void TimerOnTick(object sender, EventArgs e)
        {
            CurrentTime = DateTime.Now.ToShortTimeString();
        }

        private void LoadUser()
        {
            CurrentUser = Globals.CurrentUser;
            UpdateUserFullName();
        }

        private void UpdateUserFullName()
        {
            UserFullName = $"{CurrentUser.FirstName} {CurrentUser.LastName}";
        }

        public async Task LoadAppointments()
        {
            WorkingAppointments.Clear();
            ReferenceAppointments.Clear();

            List<ConsolidatedAppointment> appointments = await Task.Run(() => AppointmentService.GetAllConsolidated().ToList());
            foreach (ConsolidatedAppointment appointment in appointments)
            {
                WorkingAppointments.Add(appointment);
                ReferenceAppointments.Add(appointment);
            }
        }

        public async Task DismissAppointment(Guid identifier)
        {
            await Task.Run(() => AppointmentService.Disable(identifier));
            RemoveAppointmentLocally(identifier);
        }

        private void RemoveAppointmentLocally(Guid identifier)
        {
            ConsolidatedAppointment appointment = WorkingAppointments.FirstOrDefault(a => a.Identifier == identifier);
            WorkingAppointments.Remove(appointment);
            ReferenceAppointments.Remove(appointment);
        }

        private void SearchForAppointment()
        {
            WorkingAppointments.Clear();

            List<ConsolidatedAppointment> matches;
            if (string.IsNullOrEmpty(SearchQuery.Trim()))
            {
                matches = ReferenceAppointments;
            }
            else
            {
                string treatedSearchQuery = SearchQuery.ToLower().Trim();
                matches = ReferenceAppointments
                    .Where(x => x.PatientName.ToLower().Contains(treatedSearchQuery) ||
                                x.CustomerFirstName.ToLower().Contains(treatedSearchQuery) ||
                                x.CustomerLastName.ToLower().Contains(treatedSearchQuery) ||
                                x.UserEmail.ToLower().Contains(treatedSearchQuery) ||
                                x.UserFirstName.ToLower().Contains(treatedSearchQuery) ||
                                x.UserLastName.ToLower().Contains(treatedSearchQuery))
                    .ToList();
            }


            foreach (ConsolidatedAppointment match in matches)
            {
                WorkingAppointments.Add(match);
            }
        }

        public async Task AttendAppointment(Guid identifier)
        {
            await Task.Run(() => AppointmentService.Disable(identifier));
            RemoveAppointmentLocally(identifier);
        }
    }
}