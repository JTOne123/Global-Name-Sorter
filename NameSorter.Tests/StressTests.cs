using System;
using System.IO;
using System.Collections.Generic;
using Xunit;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace NameSorter.Tests
{
    public class StressTests
    {
        private static Random random = new Random();
        private static string simple_name_characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private static Process _global_name_sorter;

        private static string GenerateSimpleName()
        {
            var new_name = new StringBuilder();
            for (int character_count = random.Next(50); character_count > 0; character_count--)
            {
                new_name.Append(simple_name_characters[random.Next(simple_name_characters.Length)]);
            }
            new_name.Append(" ");
            for (int character_count = random.Next(50); character_count > 0; character_count--)
            {
                new_name.Append(simple_name_characters[random.Next(simple_name_characters.Length)]);
            }
            return new_name.ToString();
        }

        private static string[] GenerateSimpleNameList(int name_count)
        {
           string[] random_names = new string[name_count];
           for(; name_count > 0 ; name_count--)
           {
               random_names[name_count-1] = GenerateSimpleName();
           }
           return random_names;

        }

        public StressTests()
        {
        }

        [Theory]
        [InlineData(1000)]
        [InlineData(10000)]
        [InlineData(100000)]
        public void StressTest1000Names(int name_count)
        {

            string[] generated_names = GenerateSimpleNameList(name_count);
            System.IO.File.WriteAllLines(@"1000.txt", generated_names);

            _global_name_sorter = PrepareNameSorterProcess(_global_name_sorter, "1000.txt");
            _global_name_sorter.Start();
            string output = _global_name_sorter.StandardOutput.ReadToEnd();
            _global_name_sorter.WaitForExit();

            Assert.True(System.IO.File.Exists(@"sorted-names-list.txt"));
            string[] output_file_lines = System.IO.File.ReadAllLines(@"sorted-names-list.txt");
            Assert.Equal(generated_names.Length, output_file_lines.Length);
            Assert.Equal(String.Concat(generated_names).Length, String.Concat(output_file_lines).Length);
            System.IO.File.Delete(@"1000.txt");
            System.IO.File.Delete(@"sorted-names-list.txt");
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
