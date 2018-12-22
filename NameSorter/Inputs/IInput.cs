using NameSorter;

namespace Inputs
{
    // IInput is an interface for inputing data into NameSorter
    public interface IInput
    {
        void ProcessInput(NameSort name_sorter, string input_target);
    }
}
