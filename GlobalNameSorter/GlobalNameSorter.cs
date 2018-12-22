using System;
using System.Collections.Generic;
using Models;
using Inputs;
using Outputs;
using NameSorter;
using Sorters;
using Formatters;

namespace GlobalNameSorter
{
    class GlobalNameSorter
    {
        static void Main(string[] args)
        {
          if (args.Length == 0)
          {
              // No argument given... print usage and exit
              Console.WriteLine("GlobalNameSorter requires at least one argument. Example usage:\n    GlobalNameSorter <./unsorted-names-list.txt>");
              Environment.Exit(-1);
          }
          NameSort name_sorter = new NameSort();
          // Input Processing
          name_sorter.SetInputModule(new FileInput());
          name_sorter.ProcessInput(args[0]);

          // Sorting
          name_sorter.SetSortModule(new LastNameAscendingSorter());
          List<Person> sorted_people = name_sorter.SortPeople();

          // Formatting and Processing Output
          name_sorter.SetFormatModule(new PlainTextFormatter());
          string output = name_sorter.OutputString();
          name_sorter.AddOutputModule(new ConsoleOutput());
          name_sorter.AddOutputModule(new FileOutput());
          name_sorter.GenerateOutputs();
        }
    }
}
