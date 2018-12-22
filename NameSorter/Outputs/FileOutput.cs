
namespace Outputs
{
    // The FileOutput module writes the generated data to a file
    public class FileOutput : IOutput
    {
        public void GenerateOutput(string output_string)
        {
          System.IO.File.WriteAllText(@"sorted-names-list.txt", output_string);
        }
    }
}
