using System;
using System.IO;
using System.Collections.Generic;
using Xunit;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace NameSorter.Tests
{
    public class IntegrationTests
    {
        private static Process _global_name_sorter;

        public IntegrationTests()
        {
        }

        [Theory]
        [InlineData("01-empty-input")]
        [InlineData("02-single-item")]
        [InlineData("03-two-items")]
        [InlineData("04-provided-example")]
        public void ProgramWritesExpectedOutputToFile(string example_file)
        {
            string[] expected_output;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
              _global_name_sorter = PrepareNameSorterProcess(_global_name_sorter, "../../../Examples/" + example_file + ".txt");
              expected_output = System.IO.File.ReadAllLines("../../../Examples/" + example_file + "-expected-result.txt");
            } else {
              _global_name_sorter = PrepareNameSorterProcess(_global_name_sorter, @"..\..\..\Examples\03-two-items.txt");
              expected_output = System.IO.File.ReadAllLines(@"..\..\..\Examples\" + example_file + "-expected-result.txt");
            }
            _global_name_sorter.Start();
            _global_name_sorter.StandardOutput.ReadToEnd();
            _global_name_sorter.WaitForExit();

            string[] output_file_lines = System.IO.File.ReadAllLines(@"sorted-names-list.txt");
            System.IO.File.Delete(@"sorted-names-list.txt");
            Assert.Matches(String.Join("\n", expected_output), String.Join("\n", output_file_lines));
        }


        [Theory]
        [InlineData("01-empty-input")]
        [InlineData("02-single-item")]
        [InlineData("03-two-items")]
        [InlineData("04-provided-example")]
        public void ProgramPrintsExpectedOutputFromInputFile(string example_file)
        {
            string[] expected_output;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
              _global_name_sorter = PrepareNameSorterProcess(_global_name_sorter, "../../../Examples/" + example_file + ".txt");
              expected_output = System.IO.File.ReadAllLines("../../../Examples/" + example_file + "-expected-result.txt");
            } else {
              _global_name_sorter = PrepareNameSorterProcess(_global_name_sorter, @"..\..\..\Examples\03-two-items.txt");
              expected_output = System.IO.File.ReadAllLines(@"..\..\..\Examples\" + example_file + "-expected-result.txt");
            }
            _global_name_sorter.Start();
            string output = _global_name_sorter.StandardOutput.ReadToEnd();
            _global_name_sorter.WaitForExit();
            Assert.Matches(String.Join("\n", expected_output), output);
        }

        [Fact]
        public void ProgramPrintsUsageWithoutArgs()
        {
            _global_name_sorter = PrepareNameSorterProcess(_global_name_sorter);
            _global_name_sorter.Start();
            string output = _global_name_sorter.StandardOutput.ReadToEnd();
            _global_name_sorter.WaitForExit();
            Assert.Matches("GlobalNameSorter requires at least one argument. Example usage:\n    GlobalNameSorter <./unsorted-names-list.txt>", output);
        }


        public static Process PrepareNameSorterProcess(Process _global_name_sorter, string args = "")
        {
            if (_global_name_sorter == null) {
                var _global_name_sorter_builder = new Process();
                _global_name_sorter_builder.StartInfo.FileName = @"dotnet";

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    _global_name_sorter_builder.StartInfo.Arguments = "publish -c Release ../../../../../GlobalNameSorter";
                } else {
                    _global_name_sorter_builder.StartInfo.Arguments = @"publish -c Release ..\..\..\..\..\GlobalNameSorter";
                }
                _global_name_sorter_builder.Start();
                _global_name_sorter_builder.WaitForExit();
            }
            var global_name_sorter = new Process();

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                global_name_sorter.StartInfo.FileName = @"dotnet";
                global_name_sorter.StartInfo.Arguments = @"run --project ../../../../GlobalNameSorter/GlobalNameSorter.csproj " + args;
            } else {
                global_name_sorter.StartInfo.FileName = @"dotnet";
                global_name_sorter.StartInfo.Arguments = @"run --project ..\..\..\..\GlobalNameSorter\GlobalNameSorter.csproj " + args;
            }
            global_name_sorter.StartInfo.RedirectStandardOutput = true;
            return global_name_sorter;
        }



    }
}
