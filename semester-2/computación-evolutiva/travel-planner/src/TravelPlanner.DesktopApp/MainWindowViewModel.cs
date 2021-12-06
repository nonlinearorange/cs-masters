using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
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
        private string? populationSize;
        private string? status;
        private string? resultQuantity;
        private bool canSearch;
        private int count;        

        public MainWindowViewModel()
        {
            CanSearch = false;
            Origin = string.Empty;
            Destination = string.Empty;
            Generations = "5000";
            PopulationSize = "5000";
            ResultQuantity = "5";
            Status = string.Empty;
            Rate = "1";
            AvailableCities = new ObservableCollection<string>();
            FoundTrips = new ObservableCollection<Trip>();
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
            get => populationSize ?? "";
            set
            {
                populationSize = value;
                OnPropertyChanged(nameof(PopulationSize));
            }
        }

        public string Status
        {
            get => status ?? "";
            set
            {
                status = value;
                OnPropertyChanged(nameof(Status));                
            }
        }

        public string ResultQuantity
        {
            get => resultQuantity ?? "";
            set
            {
                resultQuantity = value;
                OnPropertyChanged(nameof(ResultQuantity));
            }
        }

        public bool CanSearch
        {
            get => canSearch;
            set
            {
                canSearch = value;
                OnPropertyChanged(nameof(CanSearch));
                EvaluateStatus();
            }
        }        

        public int Count 
        {
            get => count;
            set
            {
                count = value;
                OnPropertyChanged(nameof(Count));
            }
        }

        public ObservableCollection<string> AvailableCities { get; set; }

        public ObservableCollection<Trip> FoundTrips { get; set; }

        private EvolutivePlanner? Planner { get; set; }

        internal void Load()
        {
            LoadRelationships();
            LoadCities();

            CanSearch = true;
            EvaluateStatus();
        }

        private void EvaluateStatus()
        {
            Status = (canSearch == true)? "Ready": "Busy";
        }

        private void LoadRelationships()
        {
            CityMap map = new CityMap();
            map.CreateConnection("Tijuana", "Guadalajara", 110.0);
            map.CreateConnection("Tijuana", "Monterrey", 100.0);
            map.CreateConnection("Guadalajara", "León", 25.0);
            map.CreateConnection("Guadalajara", "Morelia", 40.0);
            map.CreateConnection("Monterrey", "Veracruz", 85.0);
            map.CreateConnection("Monterrey", "León", 40.0);
            map.CreateConnection("León", "CDMX", 15.0);
            map.CreateConnection("Morelia", "CDMX", 15.0);
            map.CreateConnection("Morelia", "Puebla", 15.0);
            map.CreateConnection("Veracruz", "Puebla", 5.0);
            map.CreateConnection("Puebla", "CDMX", 5.0);

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

        public async Task Search()
        {
            if (Planner == null) return;

            Count = 0;
            CanSearch = false;
            FoundTrips.Clear();
            
            List<Trip> sucessfullTrips = new List<Trip>();
            int.TryParse(ResultQuantity, out int resultQuantity);

            int local = 0;            
            while(true)
            {
                if(local >= resultQuantity || Count > 100)
                {
                    break;
                }                

                int.TryParse(Generations, out int generations);
                Planner.Generations = generations;

                int.TryParse(PopulationSize, out int populationSize);
                Planner.PopulationSize = populationSize;

                Planner.Origin = Origin;
                Planner.Destination = Destination;

                Trip trip = await Task.Run(() => Planner.FindOptimalTrip()); 

                if(trip.Path?.GetCityCount() > 0)
                {
                    sucessfullTrips.Add(trip);
                    local++;
                }

                Count++;
            }
            
            foreach (Trip trip in sucessfullTrips.OrderBy(t => t.Cost))
            {
                FoundTrips.Add(trip);
            }

            CanSearch = true;
            Count = 0;
        }
    }
}
