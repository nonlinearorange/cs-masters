namespace TravelPlanner.Core
{
    public class EvolutivePlanner
    {
        public string Origin { get; set; }

        public string Destination { get; set; }

        public int Generations { get; set; }

        public int PopulationSize { get; set; }

        public CityMap CityMap { get; set; }

        private List<Path> Population { get; set; }        

        public EvolutivePlanner(CityMap map)
        {
            Population = new List<Path>();
            CityMap = map;
            Origin = string.Empty;
            Destination = string.Empty;
        }

        public Trip FindOptimalTrip()
        {
            Population.Clear();            
            Trip trip = Search();
            return trip;
        }        
        private Trip Search()
        {
            CreateInitialPopulation();

            for (int i = 0; i < Generations; i++)
            {
                (Path childA, Path childB, Path childC, Path childD) = Crossover();
                Path mutatedA = Mutate(childA);
                Path mutatedB = Mutate(childB);
                Path mutatedC = Mutate(childC);
                Path mutatedD = Mutate(childD);

                List<Path> mutated = new List<Path> { mutatedA, mutatedB, mutatedC, mutatedD};

                PerformReinsertion(mutated);
            }

            Trip trip = FilterBest();
            return trip;
        }

        private Trip FilterBest()
        {
            List<Path> viable = new List<Path>();
            foreach (Path path in Population)
            {
                bool isViable = VerifyIsViable(path);
                if (isViable)
                {
                    viable.Add(path);
                }
            }

            List<Trip> trips = BuildTrips(viable).ToList();
            return trips.OrderBy(t => t.Cost).FirstOrDefault() ?? new Trip();
        }

        private IEnumerable<Trip> BuildTrips(IEnumerable<Path> paths)
        {
            foreach (Path path in paths)
            {
                yield return new Trip
                {
                    Path = path,
                    Cost = CityMap.CalculatePathCost(path)
                };
            }
        }
        private void PerformReinsertion(IEnumerable<Path> paths)
        {
            List<Path> viable = new List<Path>();
            foreach (Path path in paths)
            {
                bool isViable = VerifyIsViable(path);
                if (!isViable) continue;
                viable.Add(path);
            }

            if (!viable.Any()) return;

            Dictionary<int, int> usedIndexes = new();
            foreach (Path path in viable)
            {                
                while (true)
                {
                    int index = Utilities.GetRandomInteger(0, PopulationSize);
                    if (!usedIndexes.ContainsKey(index))
                    {
                        usedIndexes.Add(index, index);
                        Population[index] = path;
                        break;
                    }
                }
            }
        }               
        private bool VerifyIsViable(Path path)
        {
            bool matchesTrip = PathMatchesTrip(path);
            bool isValid = CityMap.VerifyPathExists(path);
            return isValid && matchesTrip;
        }
        private bool PathMatchesTrip(Path path)
        {
            return Origin == path.GetOrigin() && Destination == path.GetDesination();            
        }

        private void CreateInitialPopulation()
        {
            for (int i = 0; i < PopulationSize; i++)
            {
                Path path = CityMap.CreateRandomPathFromCities();
                Population.Add(path);
            }
        }

        private int[] GetDistinctIndexes()
        {
            const int quantity = 4;

            Dictionary<int, int> usedIndexes = new();
            for (int i = 0; i < quantity; i++)
            {
                while (true)
                {
                    int index = Utilities.GetRandomInteger(0, PopulationSize);
                    if (!usedIndexes.ContainsKey(index))
                    {
                        usedIndexes[index] = index;
                        break;
                    }
                }
            }

            return usedIndexes.Keys.ToArray();
        }

        private (Path, Path, Path, Path) Crossover()
        {
            int[] indexes = GetDistinctIndexes();
            Path a = Population[indexes[0]];
            Path b = Population[indexes[1]];
            Path c = Population[indexes[2]];
            Path d = Population[indexes[3]];
            
            (Path childA, Path childB) = CrossPair(a, b);
            (Path childC, Path childD) = CrossPair(c, d);            

            return (childA, childB, childC, childD);
        }

        private Path Mutate(Path path)
        {
            int operation = Utilities.GetRandomInteger(0, 3);            

            return operation switch
            {
                0 => Flip(path),
                1 => Shrink(path),
                2 => RandomLose(path),
                _ => throw new ArgumentException(),
            };
        }

        private static Path RandomLose(Path path)
        {
            int index = Utilities.GetRandomInteger(0, path.GetCityCount());
            List<string> cities = path.GetCities().ToList();
            cities.RemoveAt(index);
            return new Path(cities);
        }

        private static Path Shrink(Path path)
        {
            string[] cities = path.GetCities().ToArray();
            string[] reduced = new string[cities.Length - 1];
            Array.Copy(cities, 0, reduced, 0, reduced.Length);
            return new Path(reduced);
        }

        private Path Flip(Path path)
        {
            string[] currentCities = path.GetCities().ToArray();
            string city = SelectRandomCity();
            currentCities[^1] = city;
            return new Path(currentCities);
        }

        private string SelectRandomCity()
        {
            string[] cities = CityMap.GetCities().ToArray();
            int index = Utilities.GetRandomInteger(0, cities.Length);
            return cities[index];
        }
        private static (Path a, Path b) CrossPair(Path a, Path b)
        {
            int minimumLength = Math.Min(a.GetCityCount(), b.GetCityCount());           

            string[] citiesA = a.GetCities().ToArray();
            (string[] leftA, string[] rightA) = Split(citiesA, minimumLength);

            string[] citiesB = b.GetCities().ToArray();
            (string[] leftB, string[] rightB) = Split(citiesB, minimumLength);

            string[] childA = Join(leftA, rightB);
            string[] childB = Join(leftB, rightA);

            return (new Path(childA), new Path(childB));
        }

        private static (string[], string[]) Split(string[] array, int length)
        {
            int middle = length / 2;

            string[] left = new string[middle];
            Array.Copy(array, 0, left, 0, middle);

            string[] right = new string[middle];
            Array.Copy(array, middle, right, 0, middle);

            return (left, right);
        }

        private static string[] Join(string[] a, string[] b)
        {
            int length = a.Length + b.Length;
            string[] array = new string[length];
            Array.Copy(a, 0, array, 0, a.Length);
            Array.Copy(b, 0, array, b.Length, b.Length);

            return array;
        }
    }
}
