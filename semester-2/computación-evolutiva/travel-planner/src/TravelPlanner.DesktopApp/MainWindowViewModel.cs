using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using TravelPlanner.Core;

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

    internal class MainWindowViewModel : BindableBase
    {
        private string? rate;
        private string? generations;
        private string? origin;
        private string? destination;
        private string populationSize;

        public MainWindowViewModel()
        {
            Origin = string.Empty;
            Destination = string.Empty;
            Generations = "5000";
            PopulationSize = "5000";
            Rate = "1";
            AvailableCities = new ObservableCollection<string>();
        }

        public string Rate
        {
            get => rate ?? "";
            set
            {
                rate = value;
                OnPropertyChanged(nameof(Rate));
            }
        }

        public string Generations
        {
            get => generations ?? "";
            set
            {
                generations = value;
                OnPropertyChanged(nameof(Generations));
            }
        }

        public string Origin
        {
            get => origin ?? "";
            set
            {
                origin = value;
                OnPropertyChanged(nameof(Origin));
            }
        }

        public string Destination
        {
            get => destination ?? "";
            set
            {
                destination = value;
                OnPropertyChanged(nameof(Destination));
            }
        }

        public string PopulationSize 
        {
            get => populationSize;
            set
            {
                populationSize = value;
                OnPropertyChanged(nameof(PopulationSize));
            }
        }

        public ObservableCollection<string> AvailableCities { get; set; }

        private EvolutivePlanner? Planner { get; set; }

        internal void Load()
        {
            LoadRelationships();
            LoadCities();
        }

        private void LoadRelationships()
        {
            CityMap map = new CityMap();
            map.CreateConnection("Morelia", "CDMX", 13.0);
            map.CreateConnection("CDMX", "Puebla", 10.0);
            map.CreateConnection("Morelia", "Puebla", 20.0);
            map.CreateConnection("Guadalajara", "Morelia", 40.0);

            Planner = new EvolutivePlanner(map);
        }

        private void LoadCities()
        {
            if (Planner == null) return;
            AvailableCities.Clear();
            List<string> cities = Planner.CityMap.GetCities().ToList();
            foreach (string city in cities)
            {
                AvailableCities.Add(city);
            }

            Origin = AvailableCities[0];
            Destination = AvailableCities[1];
        }
    }
}
