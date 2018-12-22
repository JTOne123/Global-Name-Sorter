using NameSorter;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Formatters
{
    public class PlainTextFormatter : IFormatter
    {
        public string format_output(List<Person> people){
          return String.Join("\n", people.Select(person => person.getFullName()).ToArray()) + "\n";
        }
    }
}
