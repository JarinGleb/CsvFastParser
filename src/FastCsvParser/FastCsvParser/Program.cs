using FastCsvParser.Models;
using FastCsvParser.Parsers;

var lines = CsvParser.ReadCsv(GetFilePath());

var users = lines
    .Skip(1)
    .Select(parts => new User
    {
        Index = long.Parse(parts[0]),
        Id = parts[1],
        FirstName = parts[2],
        LastName = parts[3],
        Sex = parts[4],
        Email = parts[5],
        Phone = parts[6],
        DateOfBirth = DateTime.Parse(parts[7]),
        JobTitle = parts[8]
    })
    .Take(10)
    .ToList();

foreach (var user in users)
{
    user.PrintUserCard();
    Console.WriteLine("\n");
}

string GetFilePath()
{
    string baseDir = AppContext.BaseDirectory;
    string projectRoot = Directory.GetParent(baseDir).Parent.Parent.Parent.Parent.Parent.Parent.FullName;
    return Path.Combine(projectRoot, "data", "people-100.csv");
}