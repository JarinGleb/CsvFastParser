using BenchmarkDotNet.Running;
using FastCsvParser.Benchmarks;

var summarySimple = BenchmarkRunner.Run<CsvParserBenchmarks>();