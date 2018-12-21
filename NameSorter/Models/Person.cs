using System;
using System.Collections.Generic;

namespace Models
{
    public class Person
    {
        private string firstNames;

        public void setFirstNames(string newFirstName = "", string newSecondName = "", string newThirdName = "") {
          List<string> names = new List<string>();
          if(newFirstName != "") {
            names.Add(newFirstName);
          }
          if(newSecondName != "") {
            names.Add(newSecondName);
          }
          if(newThirdName != "") {
            names.Add(newThirdName);
          }
          firstNames = String.Join(" ", names);
        }

        public string getFullName() {
          return firstNames;
        }
    }
}
