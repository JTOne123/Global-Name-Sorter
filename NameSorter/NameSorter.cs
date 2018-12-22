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

      public void AddPerson(Person newPerson) {
        inputNames.Add(newPerson);
      }

      public List<Person> SortPeople() {
        sortedNames = sort_module.SortPeople(inputNames);
        return sortedNames;
      }

      public string OutputString() {
        return format_module.FormatOutput(sortedNames);
      }

      public void SetInputModule(IInput newInputModule) {
          input_module = newInputModule;
      }

      public void ProcessInput(string input_target) {
        input_module.ProcessInput(this, input_target);
      }

      public void AddOutputModule(IOutput new_output_module) {
        output_modules.Add(new_output_module);
      }

      public void GenerateOutputs() {
          foreach(IOutput this_module in output_modules){
            this_module.GenerateOutput(String.Join("\n", sortedNames.Select(person => person.GetFullName()).ToArray()) + "\n");
          }
      }

      public void SetFormatModule(IFormatter new_format) {
        format_module = new_format;
      }

      public void SetSortModule(ISorter new_sorter) {
        sort_module = new_sorter;
      }

    }
}
