using FastCsvParser.Parsers;
using System.Text;

string filePath = GetFilePath();
var lines = File.ReadLines(filePath, Encoding.UTF8);

using (StreamReader reader = new StreamReader(filePath))
{
    string line;
    while ((line = reader.ReadLine()) != null)
    {
        string[] fields = CsvParser.Parseline(line);
        foreach (string field in fields)
        {
            Console.Write(field + ' ');
        }
        Console.WriteLine();
    }
}

string GetFilePath()
{
    string baseDir = AppContext.BaseDirectory;
    string projectRoot = Directory.GetParent(baseDir).Parent.Parent.Parent.Parent.Parent.Parent.FullName;
    return filePath = Path.Combine(projectRoot, "data", "people-100.csv");
}