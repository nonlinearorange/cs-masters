using TravelPlanner.Core;

//void BasicDemo()
//{
//    CityMap cityMap = new();

//    cityMap.CreateConnection("Tijuana", "Guadalajara", 90.0);
//    cityMap.CreateConnection("Guadalajara", "Veracruz", 40.0);

//    double tijGdlCost = cityMap.FindConnectionCost("Tijuana", "Guadalajara");
//    double gdlVer = cityMap.FindConnectionCost("Guadalajara", "Veracruz");

//    Console.WriteLine($"Creating Relationship : Tijuana -> Guadalajara : ${tijGdlCost}");
//    Console.WriteLine($"Creating Relationship : Guadalajara -> Veracruz : ${gdlVer}");

//    Path validPath = new();
//    validPath.AddCity("Tijuana");
//    validPath.AddCity("Guadalajara");
//    validPath.AddCity("Veracruz");

//    bool isValidPath = cityMap.VerifyPathExists(validPath);
//    Console.WriteLine($"\nIs a Valid Path: {isValidPath}");

//    double tripCost = cityMap.CalculatePathCost(validPath);
//    Console.WriteLine($"Trip Cost: ${tripCost}");

//    Path invalidPath = new();
//    invalidPath.AddCity("Tijuana");
//    invalidPath.AddCity("Veracruz");
//    invalidPath.AddCity("Guadalajara");

//    isValidPath = cityMap.VerifyPathExists(invalidPath);
//    Console.WriteLine($"\nIs a Valid Path: {isValidPath}");

//    Console.WriteLine("\nUpdating Guadalajara - > Tijuana Cost");
//    cityMap.UpdateConnectionCost("Guadalajara", "Tijuana", 600.0);

//    double gdlTijuana = cityMap.FindConnectionCost("Guadalajara", "Tijuana");
//    Console.WriteLine($"New Guadalajara -> Tijuana Cost : ${gdlTijuana}");

//    Path returnPath = new();
//    returnPath.AddCity("Veracruz");
//    returnPath.AddCity("Guadalajara");
//    returnPath.AddCity("Tijuana");

//    isValidPath = cityMap.VerifyPathExists(validPath);
//    Console.WriteLine($"\nIs a Valid Path: {isValidPath}");

//    tripCost = cityMap.CalculatePathCost(validPath);
//    Console.WriteLine($"Trip Cost: ${tripCost}");

//    Console.WriteLine("\nAvailable Cities:");
//    foreach (string city in cityMap.GetCities())
//    {
//        Console.WriteLine(city);
//    }
//}

void MediumDemo()
{
    for (int i = 0; i < 20; i++)
    {
        CityMap map = new();
        map.CreateConnection("Morelia", "CDMX", 13.0);
        map.CreateConnection("CDMX", "Puebla", 10.0);
        map.CreateConnection("Morelia", "Puebla", 20.0);
        map.CreateConnection("Guadalajara", "Morelia", 40.0);

        EvolutivePlanner planner = new(map)
        {
            Origin = "Guadalajara",
            Destination = "CDMX",
            Generations = 5000,
            PopulationSize = 5000
        };
        Trip trip = planner.FindOptimalTrip();

        Console.WriteLine("\nMost Optimal Trip from Morelia to Puebla");
        Console.WriteLine($"Trip Details: {trip}");
    }
}

void ComplexDemo()
{
    for (int i = 0; i < 20; i++)
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

        EvolutivePlanner planner = new(map)
        {
            Origin = "Tijuana",
            Destination = "Veracruz",
            Generations = 50000,
            PopulationSize = 10000
        };
        Trip trip = planner.FindOptimalTrip();

        Console.WriteLine("\nMost Optimal Trip from Tijuana to Veracruz");
        Console.WriteLine($"Trip Details: {trip}");
    }
}

//BasicDemo();
MediumDemo();
Console.WriteLine("--------------------------------------");
ComplexDemo();

Console.WriteLine("\nPress any key to continue . . .");
Console.ReadKey();
