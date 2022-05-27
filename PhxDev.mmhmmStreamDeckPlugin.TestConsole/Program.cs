using System;
using PhxDev.mmhmmStreamDeckPlugin.Common;
namespace PhxDev.mmhmmStreamDeckPlugin.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            mmhmmUI UI = new mmhmmUI();
            //UI.ToggleAway();
            UI.ToggleCamera();
        }
    }
}
