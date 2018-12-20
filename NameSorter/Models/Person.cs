using System;

namespace Models
{
    public class Person
    {
        private string firstName;

        public void setFirstName(string newName) {
          firstName = newName;
        }

        public string getFullName() {
          return firstName;
        }
    }
}
