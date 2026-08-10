using System;
using System.Collections.Generic;
using System.Text;

namespace FastCsvParser.Parsers
{
    public static class CsvParser
    {
        public static string[] Parseline(string line, char delimeter = ',', char quotesType = '"')
        {

            var fields = new List<string>();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] != delimeter)
                {
                    sb.Append(line[i]);
                }
                else
                {
                    fields.Add(sb.ToString());
                    sb.Clear();
                }
            }

            if (sb.Length > 0) 
                fields.Add(sb.ToString());

            return fields.ToArray();
        }
    }
}
