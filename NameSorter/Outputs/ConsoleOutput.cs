using System;

namespace Outputs
{
    public class ConsoleOutput : IOutput
    {
        public void generate_output(string output_string){
          Console.Write(output_string);
        }
    }
}
