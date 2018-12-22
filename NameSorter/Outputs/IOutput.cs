namespace Outputs
{
    // The IOutput module provides an interface for consuming data from NameSorter
    public interface IOutput
    {
        void GenerateOutput(string output_string);
    }
}
