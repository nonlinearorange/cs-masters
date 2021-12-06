namespace TravelPlanner.Core
{
    public class Path
    {
        private List<string> Content { get; set; }

        public Path()
        {
            Content = new List<string>();
        }

        public Path(IEnumerable<string> cities)
        {
            Content = new List<string>();
            foreach (string city in cities)
            {
                Content.Add(city);
            }
        }

        public void AddCity(string name)
        {
            Content.Add(name);
        }

        public IEnumerable<string> GetCities()
        {
            return Content;
        }

        public int GetCityCount()
        {
            return Content.Count();
        }

        public string GetOrigin()
        {
            return Content[0];
        }

        public string GetDesination()
        {
            return Content[^1];
        }

        public override string ToString()
        {
            string output = string.Empty;
            foreach (string city in Content)
            {
                output += $"[{city}]";
            }

            return output;
        }
    }
}
