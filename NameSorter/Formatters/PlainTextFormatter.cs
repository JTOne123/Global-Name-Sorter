using NameSorter;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Formatters
{
    public class PlainTextFormatter : IFormatter
    {
        public string FormatOutput(List<Person> people){
          return String.Join("\n", people.Select(person => person.GetFullName()).ToArray()) + "\n";
        }
    }
}
