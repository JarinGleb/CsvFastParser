using System;
using System.Collections.Generic;
using System.Text;

namespace FastCsvParser.Parsers
{
    public static class CsvParser
    {
        public static string[] Parseline(string line, char delimeter = ',', char quotesSymbol = '"')
        {
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
    }
}
