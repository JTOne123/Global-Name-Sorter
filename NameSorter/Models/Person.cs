using System;
using System.Collections.Generic;

namespace Models
{
    public class Person
    {
        private string firstNames;
        private string lastName;

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
    }
}
