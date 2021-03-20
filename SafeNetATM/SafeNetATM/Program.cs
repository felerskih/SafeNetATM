using System;

namespace SafeNetATM
{
    //This class creates the Cmd line interface and then calls the main
    //method.
    //Author: Henry Felerski
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleIO io = new ConsoleIO();
            io.Run();
        }
    }
}
