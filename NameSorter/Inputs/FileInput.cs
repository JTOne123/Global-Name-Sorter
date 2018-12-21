using Models;

namespace Inputs
{
    public class FileInput : IInput
    {
        public void process_input(NameSorter.NameSorter name_sorter, string input_target) {

            if (System.IO.File.Exists(input_target))
            {
                 string[] names = System.IO.File.ReadAllLines(input_target);
                 foreach(string name in names) {
                   name_sorter.addPerson(new Person(name));
                 }
            }
        }
    }
}
