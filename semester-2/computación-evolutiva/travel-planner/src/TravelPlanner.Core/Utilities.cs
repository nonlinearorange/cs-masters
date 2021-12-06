namespace TravelPlanner.Core
{
    internal static class Utilities
    {
        public static readonly Random Random = new();

        public static int GetRandomInteger(int min, int max)
        {
            return Random.Next(min, max);
        }
    }
}
