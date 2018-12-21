using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    public class Person
    {
        private string firstNames;
        private string lastName;

        public Person(string names = "") {
          string[] splitNames = names.Split(' ');
          if(splitNames.Length > 1){
            lastName = splitNames.Last();
          } else {
            lastName = null;
          }
          firstNames = String.Join(" ", splitNames.Take(splitNames.Length - 1).ToArray());
        }

        public void setLastName(string newLastName = "") {
          lastName = newLastName;
        }

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
          if(lastName != null){
            return firstNames + " " + lastName;
          } else {
            return firstNames;
          }
        }

        public string getOrderingName() {
          if(lastName != null){
            return lastName + " " + firstNames;
          } else {
            return firstNames;
          }
        }
    }
}
