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

        [Fact]
        public void ProgramPrintsExpectedOutputFromInputFile()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
              _global_name_sorter = PrepareNameSorterProcess(_global_name_sorter, "../../../Examples/03-two-items.txt");
            } else {
              _global_name_sorter = PrepareNameSorterProcess(_global_name_sorter, @"..\..\..\Examples\03-two-items.txt");
            }
            _global_name_sorter.Start();
            string output = _global_name_sorter.StandardOutput.ReadToEnd();
            _global_name_sorter.WaitForExit();
            Assert.Matches("Second Will Be First\nFirst Middle Last\n", output);
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
