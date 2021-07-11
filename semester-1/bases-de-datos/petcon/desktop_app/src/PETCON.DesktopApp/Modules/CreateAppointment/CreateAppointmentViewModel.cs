using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using PETCON.DesktopApp.Helpers;
using PETCON.DesktopApp.Models.Appointment;
using PETCON.DesktopApp.Models.Patient;
using PETCON.DesktopApp.Models.User;
using PETCON.DesktopApp.Services;

namespace PETCON.DesktopApp.Modules.CreateAppointment
{
    public class CreateAppointmentViewModel : BindableBase
    {
        private bool _canRegister;

        public CreateAppointmentViewModel()
        {
            CanRegister = true;
            Patients = new ObservableCollection<Patient>();
            Users = new ObservableCollection<User>();
        }

        public bool CanRegister
        {
            get => _canRegister;
            set
            {
                _canRegister = value;
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        public ObservableCollection<Patient> Patients { get; }

        public ObservableCollection<User> Users { get; }

        public async Task CreateAppointment()
        {
            CanRegister = false;

            NewAppointment appointment = new NewAppointment
            {
                Identifier = Guid.NewGuid(),
                CreatedBy = Guid.Parse("db61e1ec-7d83-11eb-b598-704d7b2d5b37"),
                DesignatedTo = Guid.Parse("b610c483-7268-11eb-b696-704d7b2d5b37"),
                PatientId = Guid.Parse("0dd210f7-7d85-11eb-b598-704d7b2d5b37"),
                DueTo = DateTime.Now
            };
            await Task.Run(() => AppointmentService.Create(appointment));

            CanRegister = true;
        }

        public async Task Load()
        {
            await LoadUsers();
            await LoadPatients();
        }

        private async Task LoadPatients()
        {
            Patients.Clear();
            List<Patient> patients = await Task.Run(() => PatientService.GetAll().ToList());
            foreach (Patient patient in patients)
            {
                Patients.Add(patient);
            }
        }

        private async Task LoadUsers()
        {
            Users.Clear();
            List<User> users = await Task.Run(() => UserService.GetAll().ToList());
            foreach (User user in users)
            {
                Users.Add(user);
            }
        }
    }
}