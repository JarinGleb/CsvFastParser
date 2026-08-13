using Xunit;
using FastCsvParser.Parsers;

namespace FastCsvParser.Tests
{
    public class CsvParserTests
    {
        // Tests for ParseLine method

        [Fact]
        public void Parseline_SimpleString_ReturnsCorrectFields()
        {
            string input = "John,Doe,30,USA";

            string[] expected = { "John", "Doe", "30", "USA" };

            string[] result = CsvParser.ParseLine(input);
    
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Parseline_WithQuotes_RemovesQuotes()
        {
            string input = "John,Doe,30,USA,\"Programmer\"";

            string[] expected = { "John", "Doe", "30", "USA", "Programmer" };

            string[] result = CsvParser.ParseLine(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Parseline_WithCommaInsideQuotes_KeepsField()
        {
            string input = "John,Doe,30,USA,\"Programmer, Driver\"";

            string[] expected = { "John", "Doe", "30", "USA", "Programmer, Driver" };

            string[] result = CsvParser.ParseLine(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Parseline_EmptyFields_ReturnsEmptyStrings()
        {
            string input = "John,Doe,30,,";

            string[] expected = { "John", "Doe", "30", "", ""};

            string[] result = CsvParser.ParseLine(input);

            Assert.Equal(expected, result);
        }
        [Fact]
        public void Parseline_EmptyField_ReturnsEmptyString()
        {
            string input = "";

            string[] expected = { "" };

            string[] result = CsvParser.ParseLine(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Parseline_DoubleQuotes_HandlesEscaping()
        {
            string input = "John,Doe,30,USA,\"Programmer \"\"Seniour\"\"\"";

            string[] expected = { "John", "Doe", "30", "USA", "Programmer \"Seniour\"" };

            string[] result = CsvParser.ParseLine(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Parseline_NullInput_ThrowsException()
        {
            string input = null;

            Assert.Throws<ArgumentNullException>(() => CsvParser.ParseLine(input));
        }
    }
}
