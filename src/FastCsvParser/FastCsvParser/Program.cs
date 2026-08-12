using FastCsvParser.Parsers;
using System.Text;

string filePath = GetFilePath();
var lines = File.ReadLines(filePath, Encoding.UTF8);

string line = "13,C03fDADdAadAdCe,Mandy,Blake,Male,jefferynoble@example.org,(992)466-1305x4947,2007-12-08,\"Scientist, clinical (histocompatibility and immunogenetics)\",\"qqq \"\"EEE\"\"\"";
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