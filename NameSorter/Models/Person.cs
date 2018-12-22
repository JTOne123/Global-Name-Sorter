using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    // The Person class handles names and ordering methods
    public class Person
    {
        private string first_names;
        private string last_name;

        public Person(string names = "")
        {
          string[] split_names = names.Split(' ');
          if(split_names.Length > 1)
          {
            last_name = split_names.Last();
          } else {
            last_name = null;
          }
          first_names = String.Join(" ", split_names.Take(split_names.Length - 1).ToArray());
        }

        public void SetLastName(string newLast_name = "")
        {
          last_name = newLast_name;
        }

        public void SetFirstNames(string new_first_name = "", string new_second_name = "", string new_third_name = "") {
          List<string> names = new List<string>();
          if(new_first_name != "")
          {
            names.Add(new_first_name);
          }
          if(new_second_name != "")
          {
            names.Add(new_second_name);
          }
          if(new_third_name != "")
          {
            names.Add(new_third_name);
          }
          first_names = String.Join(" ", names);
        }

        public string GetFullName() {
          if(last_name != null)
          {
            return first_names + " " + last_name;
          } else {
            return first_names;
          }
        }

        public string getOrderingName() {
          if(last_name != null)
          {
            return last_name + " " + first_names;
          } else {
            return first_names;
          }
        }
    }
}
