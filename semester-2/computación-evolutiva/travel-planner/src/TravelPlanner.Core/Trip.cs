namespace TravelPlanner.Core
{
    public class Trip
    {
        public double Cost { get; set; }

        public Path? Path { get; set; }

        public override string ToString()
        {
            return $"Trip -> {Path?.ToString() ?? "No path data available."}, Cost: ${Cost}";
        }
    }
}
