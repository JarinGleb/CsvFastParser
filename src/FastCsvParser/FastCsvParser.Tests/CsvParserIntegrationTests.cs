using Xunit;
using FastCsvParser.Parsers;
using System.IO;

namespace FastCsvParser.Tests
{
    public class CsvParserIntegrationTests
    {
        // Integration tests for ReadCsv method

        [Fact]
        public void ReadCsv_ValidFile_ReturnsRows()
        {
            string tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile,
                "1,John,30,New York\n" +
                "2,Jane,25,Los Angeles\n");

            var rows = CsvParser.ReadCsv(tempFile);
            var list = rows.ToList();

            Assert.Equal(2, list.Count);
            Assert.Equal(new[] { "1", "John", "30", "New York" }, list[0]);
            Assert.Equal(new[] { "2", "Jane", "25", "Los Angeles" }, list[1]);

            File.Delete(tempFile);
        }

        [Fact]
        public void ReadCsv_EmptyFile_ReturnsEmpty()
        {
            string tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, "");

            var rows = CsvParser.ReadCsv(tempFile);
            var list = rows.ToList();

            Assert.Empty(list);

            File.Delete(tempFile);
        }

        [Fact]
        public void ReadCsv_FileWithQuotes_ReturnsCorrectFields()
        {
            string tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile,
                "1,John,\"Scientist, clinical\"\n");

            var rows = CsvParser.ReadCsv(tempFile);
            var list = rows.ToList();

            Assert.Single(list);
            Assert.Equal("1", list[0][0]);
            Assert.Equal("John", list[0][1]);
            Assert.Equal("Scientist, clinical", list[0][2]);

            File.Delete(tempFile);
        }

        [Fact]
        public void ReadCsv_MissingFile_ThrowsException()
        {
            string invalidPath = "non_existent_file.csv";

            Assert.Throws<FileNotFoundException>(() => CsvParser.ReadCsv(invalidPath).ToList());
        }

        // Integration tests for ReadCsvSpan method

        [Fact]
        public void ReadCsvSpan_ValidFile_ReturnsRows()
        {
            string tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile,
                "1,John,30,New York\n" +
                "2,Jane,25,Los Angeles\n");

            var rows = CsvParser.ReadCsv(tempFile);
            var list = rows.ToList();

            Assert.Equal(2, list.Count);
            Assert.Equal(new[] { "1", "John", "30", "New York" }, list[0]);
            Assert.Equal(new[] { "2", "Jane", "25", "Los Angeles" }, list[1]);

            File.Delete(tempFile);
        }

        [Fact]
        public void ReadCsvSpan_EmptyFile_ReturnsEmpty()
        {
            string tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, "");

            var rows = CsvParser.ReadCsv(tempFile);
            var list = rows.ToList();

            Assert.Empty(list);

            File.Delete(tempFile);
        }

        [Fact]
        public void ReadCsvSpan_FileWithQuotes_ReturnsCorrectFields()
        {
            string tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile,
                "1,John,\"Scientist, clinical\"\n");

            var rows = CsvParser.ReadCsv(tempFile);
            var list = rows.ToList();

            Assert.Single(list);
            Assert.Equal("1", list[0][0]);
            Assert.Equal("John", list[0][1]);
            Assert.Equal("Scientist, clinical", list[0][2]);

            File.Delete(tempFile);
        }

        [Fact]
        public void ReadCsvSpan_MissingFile_ThrowsException()
        {
            string invalidPath = "non_existent_file.csv";

            Assert.Throws<FileNotFoundException>(() => CsvParser.ReadCsv(invalidPath).ToList());
        }
    }
}
