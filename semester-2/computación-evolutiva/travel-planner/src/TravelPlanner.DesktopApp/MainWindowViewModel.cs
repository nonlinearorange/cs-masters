using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
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
        private string? _rate;
        private string? _generations;
        private string? _origin;
        private string? _destination;
        private string? _populationSize;
        private string? _status;
        private string? _resultQuantity;
        private bool _canSearch;
        private int _count;        

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
            get => _rate ?? "";
            set
            {
                _rate = value;
                OnPropertyChanged(nameof(Rate));
            }
        }

        public string Generations
        {
            get => _generations ?? "";
            set
            {
                _generations = value;
                OnPropertyChanged(nameof(Generations));
            }
        }

        public string Origin
        {
            get => _origin ?? "";
            set
            {
                _origin = value;
                OnPropertyChanged(nameof(Origin));
            }
        }

        public string Destination
        {
            get => _destination ?? "";
            set
            {
                _destination = value;
                OnPropertyChanged(nameof(Destination));
            }
        }

        public string PopulationSize 
        {
            get => _populationSize ?? "";
            set
            {
                _populationSize = value;
                OnPropertyChanged(nameof(PopulationSize));
            }
        }

        public string Status
        {
            get => _status ?? "";
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));                
            }
        }

        public string ResultQuantity
        {
            get => _resultQuantity ?? "";
            set
            {
                _resultQuantity = value;
                OnPropertyChanged(nameof(ResultQuantity));
            }
        }

        public bool CanSearch
        {
            get => _canSearch;
            set
            {
                _canSearch = value;
                OnPropertyChanged(nameof(CanSearch));
                EvaluateStatus();
            }
        }        

        public int Count 
        {
            get => _count;
            set
            {
                _count = value;
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
            Status = (_canSearch == true)? "Ready": "Busy";
        }

        private void LoadRelationships()
        {
            CityMap map = new();
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

            if (string.Equals(Origin, Destination))
            {
                const string message = "Cities can't be the same.";
                const string title = "IARN Research : Same Cities";
                MessageBox.Show(message, title, MessageBoxButton.OK);
                return;
            }

            Count = 0;
            CanSearch = false;
            FoundTrips.Clear();
            
            List<Trip> sucessfullTrips = new();
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
