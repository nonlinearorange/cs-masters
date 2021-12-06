namespace TravelPlanner.Core
{
    public class Trip
    {
        public double Cost { get; set; }

        public Path? Path { get; set; }

        public string FriendlyCost => $"Cost: ${Cost}";

        public string FriendlyPath
        {
            get
            {
                List<string> cities = Path?.GetCities().ToList() ?? new List<string>();
                string assembled = string.Empty;
                for (int i = 0; i < cities.Count - 1; i++)
                {
                    assembled += $"{cities[i]}, ";
                }

                assembled += $"{cities[cities.Count - 1]}";
                return $"Cities: {assembled}";
            }
        }

        public override string ToString()
        {
            return $"Trip -> {Path?.ToString() ?? "No path data available."}, Cost: ${Cost}";
        }
    }
}
