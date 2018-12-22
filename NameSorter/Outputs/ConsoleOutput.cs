using System;

namespace Outputs
{
    public class ConsoleOutput : IOutput
    {
        public void GenerateOutput(string output_string){
          Console.Write(output_string);
        }
    }
}
