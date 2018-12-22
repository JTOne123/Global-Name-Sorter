using System;

namespace Outputs
{
    // The ConsoleOutput module displays the generated list to the termnal screen
    public class ConsoleOutput : IOutput
    {
        public void GenerateOutput(string output_string)
        {
          Console.Write(output_string);
        }
    }
}
