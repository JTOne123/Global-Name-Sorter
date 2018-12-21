
namespace Outputs
{
    public class FileOutput : IOutput
    {
        public void generate_output(string output_string){
          System.IO.File.WriteAllText(@"sorted-names-list.txt", output_string);
        }
    }
}
