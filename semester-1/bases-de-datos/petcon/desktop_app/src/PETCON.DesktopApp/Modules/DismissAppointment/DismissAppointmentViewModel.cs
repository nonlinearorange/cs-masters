using System;
using System.Threading.Tasks;
using PETCON.DesktopApp.Helpers;
using PETCON.DesktopApp.Services;

namespace PETCON.DesktopApp.Modules.DismissAppointment
{
    public class DismissAppointmentViewModel : BindableBase
    {
        private readonly Random _random;
        private string _verificationCode;
        private string _expectedVerificationCode;
        private bool _canCancel;

        public DismissAppointmentViewModel()
        {
            _random = new Random();
            ExpectedVerificationCode = GenerateVerificationCode();
        }

        public string VerificationCode
        {
            get => _verificationCode;
            set
            {
                _verificationCode = value;
                OnPropertyChanged(nameof(VerificationCode));
                CanCancel = EvaluateVerificationCode();
            }
        }

        public string ExpectedVerificationCode
        {
            get => _expectedVerificationCode;
            set
            {
                _expectedVerificationCode = value;
                OnPropertyChanged(nameof(ExpectedVerificationCode));
            }
        }

        public bool CanCancel
        {
            get => _canCancel;
            set
            {
                _canCancel = value;
                OnPropertyChanged(nameof(CanCancel));
            }
        }

        public Guid AppointmentId { get; set; }

        private bool EvaluateVerificationCode()
        {
            return VerificationCode == ExpectedVerificationCode;
        }

        private string GenerateVerificationCode()
        {
            string output = string.Empty;
            int length = _random.Next(5, 10);
            for (int i = 0; i < length; i++)
            {
                char character = (char) _random.Next(97, 122);
                output += $"{character}";
            }

            return output;
        }

        public void ProvideAppointment(Guid appointmentId)
        {
            AppointmentId = appointmentId;
        }

        public async Task<bool> ExecuteDismiss()
        {
            CanCancel = false;
            bool canClose = false;
            if (EvaluateVerificationCode())
            {
                canClose = await Task.Run(() => AppointmentService.Disable(AppointmentId));
            }

            CanCancel = true;
            return canClose;
        }
    }
}