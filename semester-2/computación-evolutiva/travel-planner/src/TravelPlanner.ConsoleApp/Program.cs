using TravelPlanner.Core;
using Path = TravelPlanner.Core.Path;

CityMap cityMap = new();

cityMap.CreateConnection("Tijuana", "Guadalajara", 90.0);
cityMap.CreateConnection("Guadalajara", "Veracruz", 40.0);

double tijGdlCost = cityMap.FindConnectionCost("Tijuana", "Guadalajara");
double gdlVer = cityMap.FindConnectionCost("Guadalajara", "Veracruz");

Console.WriteLine($"Creating Relationship : Tijuana -> Guadalajara : ${tijGdlCost}");
Console.WriteLine($"Creating Relationship : Guadalajara -> Veracruz : ${gdlVer}");

Path validPath = new();
validPath.AddCity("Tijuana");
validPath.AddCity("Guadalajara");
validPath.AddCity("Veracruz");

bool isValidPath = cityMap.VerifyPathExists(validPath);
Console.WriteLine($"\nIs a Valid Path: {isValidPath}");

double tripCost = cityMap.CalculatePathCost(validPath);
Console.WriteLine($"Trip Cost: ${tripCost}");

Path invalidPath = new();
invalidPath.AddCity("Tijuana");
invalidPath.AddCity("Veracruz");
invalidPath.AddCity("Guadalajara");

isValidPath = cityMap.VerifyPathExists(invalidPath);
Console.WriteLine($"\nIs a Valid Path: {isValidPath}");

Console.WriteLine("\nUpdating Guadalajara - > Tijuana Cost");
cityMap.UpdateConnectionCost("Guadalajara", "Tijuana", 600.0);

double gdlTijuana = cityMap.FindConnectionCost("Guadalajara", "Tijuana");
Console.WriteLine($"New Guadalajara -> Tijuana Cost : ${gdlTijuana}");

Path returnPath = new();
returnPath.AddCity("Veracruz");
returnPath.AddCity("Guadalajara");
returnPath.AddCity("Tijuana");

isValidPath = cityMap.VerifyPathExists(validPath);
Console.WriteLine($"\nIs a Valid Path: {isValidPath}");

tripCost = cityMap.CalculatePathCost(validPath);
Console.WriteLine($"Trip Cost: ${tripCost}");

Console.WriteLine("\nAvailable Cities:");
foreach (string city in cityMap.GetCities())
{
    Console.WriteLine(city);
}

Console.WriteLine("\nPress any key to continue . . .");
Console.ReadKey();