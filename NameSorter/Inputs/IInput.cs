using NameSorter;

namespace Inputs
{
    public interface IInput
    {
        void process_input(NameSort name_sorter, string input_target);
    }
}
