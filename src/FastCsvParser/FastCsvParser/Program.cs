using FastCsvParser.Parsers;
using System.Text;

string filePath = GetFilePath();
var lines = File.ReadLines(filePath, Encoding.UTF8);

string line = "zzz,aaa,sss";
var aa = CsvParser.Parseline(line);
foreach (var c in aa)
{
    Console.WriteLine(c);
}



string GetFilePath()
{
    string baseDir = AppContext.BaseDirectory;
    string projectRoot = Directory.GetParent(baseDir).Parent.Parent.Parent.Parent.Parent.Parent.FullName;
    return filePath = Path.Combine(projectRoot, "data", "people-100.csv");
}