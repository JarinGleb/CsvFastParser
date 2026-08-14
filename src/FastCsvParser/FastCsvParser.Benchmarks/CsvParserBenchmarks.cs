using BenchmarkDotNet.Attributes;
using FastCsvParser.Parsers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastCsvParser.Benchmarks
{
    [MemoryDiagnoser]

    public class CsvParserBenchmarks
    {
        private string _simpleLine;
        private string _complexLine;

        [GlobalSetup]
        public void Setup()
        {
            _simpleLine = "John,Doe,30,USA";
            _complexLine = "13,C03fDADdAadAdCe,Mandy,Blake,Male,jefferynoble@example.org,(992)466-1305x4947,2007-12-08,\"Scientist, clinical (histocompatibility and immunogenetics)\"";
        }

        [Benchmark(Baseline = true)]
        public string[] ParseLine_StringBuilder_Simple() => CsvParser.ParseLine(_simpleLine);

        [Benchmark]
        public string[] ParseLine_Span_Simple() => CsvParser.ParseLineSpan(_simpleLine);

        [Benchmark]
        public string[] ParseLine_StringBuilder_Complex() => CsvParser.ParseLine(_complexLine);

        [Benchmark]
        public string[] ParseLine_Span_Complex() => CsvParser.ParseLineSpan(_complexLine);
    }
}
