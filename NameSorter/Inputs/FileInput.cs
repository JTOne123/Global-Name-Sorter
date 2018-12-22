using Models;
using NameSorter;

namespace Inputs
{
    public class FileInput : IInput
    {
        public void ProcessInput(NameSort name_sorter, string input_target) {

            if (System.IO.File.Exists(input_target))
            {
                 string[] names = System.IO.File.ReadAllLines(input_target);
                 foreach(string name in names) {
                   name_sorter.AddPerson(new Person(name));
                 }
            }
        }
    }
}
