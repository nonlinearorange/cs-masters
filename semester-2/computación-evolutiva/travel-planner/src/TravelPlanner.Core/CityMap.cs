namespace TravelPlanner.Core
{
    public class CityMap
    {        
        private Dictionary<string, double> Costs { get; }

        private Dictionary<string, (string, string)> Connections { get; }

        public CityMap()
        {
            Costs = new Dictionary<string, double>();
            Connections = new Dictionary<string, (string, string)>();
        }

        private static (string, string) GeneratePairIdentifiers(string origin, string destination)
        {
            return ($"{origin}-{destination}", $"{destination}-{origin}");
        }

        public void CreateConnection(string origin, string destination, double cost)
        {
            (string main, string inverse) = GeneratePairIdentifiers(origin, destination);

            bool mainExists = Connections.ContainsKey(main);
            bool inverseExists = Connections.ContainsKey(inverse);

            if (mainExists || inverseExists) return;

            Connections.Add(main, new ValueTuple<string, string>(origin, destination));
            RegisterCost(main, cost);
        }

        public void RegisterCost(string identifier, double value)
        {
            Costs.Add(identifier, value);
        }

        public double FindConnectionCost(string origin, string destination)
        {
            (string main, string inverse) = GeneratePairIdentifiers(origin, destination);

            bool mainFound = Costs.TryGetValue(main, out double cost);
            if (mainFound) return cost;

            bool inverseFound = Costs.TryGetValue(inverse, out cost);
            if (inverseFound) return cost;

            const double error = -9999;            
            return error;
        }

        public void UpdateConnectionCost(string origin, string destination, double cost)
        {
            (string main, string inverse) = GeneratePairIdentifiers(origin, destination);
            if(Costs.ContainsKey(main))
                Costs[main] = cost;

            if (Costs.ContainsKey(inverse))
                Costs[inverse] = cost;
        }

        public bool VerifyConnectionExist(string origin, string destination)
        {
            (string main, string inverse) = GeneratePairIdentifiers(origin, destination);

            bool mainExists = Connections.ContainsKey(main);
            bool inverseExists = Connections.ContainsKey(inverse);

            return mainExists || inverseExists;
        }

        public bool VerifyPathExists(Path path)
        {
            string[] cities = path.GetCities().ToArray();

            for (int i = 0; i < cities.Length - 1; i++)
            {
                string origin = cities[i];
                string destination = cities[i + 1];
                bool connectionExists = VerifyConnectionExist(origin, destination);
                if(!connectionExists) return false;
            }

            return true;
        }

        public double CalculatePathCost(Path path)
        {
            const double error = -9999;
            double accumulated = 0;

            string[] cities = path.GetCities().ToArray();
            for (int i = 0;i < cities.Length - 1; i++)
            {
                string origin = cities[i];
                string destination = cities[i + 1];
                bool connectionExists = VerifyConnectionExist(origin, destination);
                if (!connectionExists) return error;

                double cost = FindConnectionCost(origin, destination);
                accumulated += cost;
            }

            return accumulated;
        }

        public IEnumerable<string> GetCities()
        {
            Dictionary<string, string> cities = new();
            foreach (KeyValuePair<string, (string, string)> connection in Connections)
            {
                (string origin, string destination) = connection.Value;
                
                if(!cities.ContainsKey(origin)) cities.Add(origin, origin);
                if (!cities.ContainsKey(destination)) cities.Add(destination, destination);
            }

            return cities.Keys.ToList();
        }

        public Path CreateRandomPathFromCities()
        {
            return CreateRandomPathFromCities(GetCities().Count());
        }

        public Path CreateRandomPathFromCities(int length)
        {
            int variantLength = Utilities.GetRandomInteger(0, length - 1);
            string[] cities = GetCities().ToArray();
            Path path = new();
            for (int i = 0; i < length - variantLength; i++)
            {
                int randomIndex = Utilities.GetRandomInteger(0, length);
                path.AddCity(cities[randomIndex]);
            }

            return path;
        }
    }
}
