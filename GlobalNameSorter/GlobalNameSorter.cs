using System;
using Models;
using Inputs;

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
          NameSorter.NameSorter name_sorter = new NameSorter.NameSorter();
          // Input Processing
          name_sorter.set_input_module(new FileInput());
          name_sorter.process_input(name_sorter, args[0]);

          // Sorting
          name_sorter.sortPeople();

          // Formatting Output
          string output = name_sorter.outputString();

          // Output Processing
          Console.Write(output);
          //File output
          System.IO.File.WriteAllText(@"sorted-names-list.txt", output);
        }
    }
}
