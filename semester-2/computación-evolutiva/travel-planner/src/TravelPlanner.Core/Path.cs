namespace TravelPlanner.Core
{
    public class Path
    {
        private List<string> Content { get; set; }

        public Path()
        {
            Content = new List<string>();
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

        public static Path CreateRandom()
        {
            throw new NotImplementedException();
        }
    }
}
