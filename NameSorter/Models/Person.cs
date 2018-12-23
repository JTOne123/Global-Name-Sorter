using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    // The Person class handles names and ordering methods
    public class Person
    {
        private List<string> names;

        public Person(string new_names = "")
        {
          string[] split_names = new_names.Split(' ');
          names = split_names.ToList();
        }

        public void SetNames(string new_names = "") {
          string[] split_names = new_names.Split(' ');
          names = split_names.ToList();
        }

        public string GetFullName() {
            return String.Join(" ", names);
        }

        public string getOrderingName() {
          if(names.Count > 1)
          {
            return names.Last() + " " + String.Join(" ", names.Take(names.Count - 1).ToArray());
          } else {
            return names.Last();
          }
        }
    }
}
