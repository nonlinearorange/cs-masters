using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TravelPlanner.DesktopApp
{
    internal class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    internal class MainWindowViewModel
    {
        public double Rate { get; set; }

        public double Size { get; set; }

        public double Generations { get; set; }

        internal void Load()
        {
            throw new NotImplementedException();
        }
    }
}
