using System;
using Models;

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
          //input
          if (System.IO.File.Exists(args[0]))
          {
               string[] names = System.IO.File.ReadAllLines(args[0]);
               foreach(string name in names) {
                 name_sorter.addPerson(new Person(name));
               }
          }
          // Sort data
          name_sorter.sortPeople();
          //formatting
          string output = name_sorter.outputString();
          //output
          Console.Write(output);
          //File output
          System.IO.File.WriteAllText(@"sorted-names-list.txt", output);
        }
    }
}
