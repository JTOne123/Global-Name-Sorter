using System;
using System.Linq;
using System.Collections.Generic;
using Models;
using Inputs;
using Outputs;
using Sorters;
using Formatters;

namespace NameSorter
{
    public class NameSort
    {
      private List<Person> inputNames;
      private List<Person> sortedNames;
      private IInput input_module;
      private List<IOutput> output_modules;
      private ISorter sort_module;
      private IFormatter format_module;

      public NameSort() {
        inputNames = new List<Person>();
        output_modules = new List<IOutput>();
      }

      public void addPerson(Person newPerson) {
        inputNames.Add(newPerson);
      }

      public List<Person> sortPeople() {
        sortedNames = sort_module.sort_people(inputNames);
        return sortedNames;
      }

      public string outputString() {
        return format_module.format_output(sortedNames);
      }

      public void set_input_module(IInput newInputModule) {
          input_module = newInputModule;
      }

      public void process_input(NameSort name_sorter, string input_target) {
        input_module.process_input(name_sorter, input_target);
      }

      public void add_output_module(IOutput new_output_module) {
        output_modules.Add(new_output_module);
      }

      public void generate_outputs() {
          foreach(IOutput this_module in output_modules){
            this_module.generate_output(String.Join("\n", sortedNames.Select(person => person.getFullName()).ToArray()) + "\n");
          }
      }

      public void set_format_module(IFormatter new_format) {
        format_module = new_format;
      }

      public void set_sort_module(ISorter new_sorter) {
        sort_module = new_sorter;
      }

    }
}
