using System;
using Models;
using Inputs;
using Outputs;
using NameSorter;

namespace GlobalNameSorter
{
    class GlobalNameSorter
    {
        static void Main(string[] args)
        {
          if (args.Length == 0)
          {
            // No argument given... print help and error out.
              Console.WriteLine("GlobalNameSorter requires at least one argument. Example usage:\n    GlobalNameSorter <./unsorted-names-list.txt>");
              Environment.Exit(-1);
          }
          NameSort name_sorter = new NameSort();
          // Input Processing
          name_sorter.set_input_module(new FileInput());
          name_sorter.process_input(name_sorter, args[0]);

          // Sorting
          name_sorter.sortPeople();

          // Formatting Output
          string output = name_sorter.outputString();

          // Output Processing
          name_sorter.add_output_module(new ConsoleOutput());
          name_sorter.add_output_module(new FileOutput());
          name_sorter.generate_outputs();
        }
    }
}
