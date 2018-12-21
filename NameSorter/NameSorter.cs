using System;
using System.Linq;
using System.Collections.Generic;
using Models;
using Inputs;
using Outputs;

namespace NameSorter
{
    public class NameSorter
    {
      private List<Person> inputNames;
      private List<Person> sortedNames;
      private IInput input_module;
      private List<IOutput> output_modules;

      public NameSorter() {
        inputNames = new List<Person>();
        output_modules = new List<IOutput>();
      }

      public void addPerson(Person newPerson) {
        inputNames.Add(newPerson);
      }

      public List<Person> sortPeople() {
        sortedNames = inputNames.OrderBy(person => person.getOrderingName()).ToList();
        return sortedNames;
      }

      public string outputString() {
        return String.Join("\n", sortedNames.Select(person => person.getFullName()).ToArray()) + "\n";
      }

      public void set_input_module(IInput newInputModule) {
          input_module = newInputModule;
      }

      public void process_input(NameSorter name_sorter, string input_target) {
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

    }
}
