using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FastCsvParser.Parsers
{
    public static class CsvParser
    {
        public static string[] ParseLine(string line, char delimeter = ',', char quotesSymbol = '"')
        {
            if (line is null)
                throw new ArgumentNullException(nameof(line));

            var fields = new List<string>();
            bool inQuotes = false;
            var sb = new StringBuilder();

            for (int i = 0; i < line.Length; i++)
            {
                char current = line[i];

                if (current == quotesSymbol)
                {
                    if (i + 1 < line.Length && line[i + 1] == quotesSymbol)
                    {
                        sb.Append(quotesSymbol);
                        i++;
                    }
                    else
                    {
                        inQuotes = !inQuotes;
                    }
                }
                else if (current == delimeter && !inQuotes)
                {
                    fields.Add(sb.ToString());
                    sb.Clear();
                }
                else
                {
                    sb.Append(current);
                }
            }

            fields.Add(sb.ToString());
            return fields.ToArray();
        }

        public static string[] ParseLineSpan(ReadOnlySpan<char> kine, char delimeter = ',', char quotesSymbol = '"')
        {
            if (line is null)
                throw new ArgumentNullException(nameof(line));

            var fields = new List<string>();
            bool inQuotes = false;
            var sb = new StringBuilder();

            for (int i = 0; i < line.Length; i++)
            {
                char current = line[i];

                if (current == quotesSymbol)
                {
                    if (i + 1 < line.Length && line[i + 1] == quotesSymbol)
                    {
                        sb.Append(quotesSymbol);
                        i++;
                    }
                    else
                    {
                        inQuotes = !inQuotes;
                    }
                }
                else if (current == delimeter && !inQuotes)
                {
                    fields.Add(sb.ToString());
                    sb.Clear();
                }
                else
                {
                    sb.Append(current);
                }
            }

            fields.Add(sb.ToString());
            return fields.ToArray();
        }

        public static IEnumerable<string[]> ReadCsv(string filePath, char delimeter = ',', char quotesSymbol = '"')
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException(nameof(filePath));

            using (var reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return ParseLine(line, delimeter, quotesSymbol);
                }
            }
        }
    }
}