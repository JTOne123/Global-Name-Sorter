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
          name_sorter.set_input_module(new FileInput());
          name_sorter.process_input(args[0]);

          // Sorting
          name_sorter.set_sort_module(new LastNameAscendingSorter());
          List<Person> sorted_people = name_sorter.SortPeople();

          // Formatting and Processing Output
          name_sorter.set_format_module(new PlainTextFormatter());
          string output = name_sorter.outputString();
          name_sorter.add_output_module(new ConsoleOutput());
          name_sorter.add_output_module(new FileOutput());
          name_sorter.generate_outputs();
        }
    }
}
