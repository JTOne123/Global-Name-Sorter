using System;

namespace Models
{
    public class Person
    {
        private string firstNames;

        public void setFirstNames(string newFirstName = "", string newSecondName = "", string newThirdName = "") {
          firstNames = String.Join(" ", new string[]{newFirstName, newSecondName, newThirdName});
        }

        public string getFullName() {
          return firstNames;
        }
    }
}
