using System;
using StreamingContentUI.Consoles;

namespace StreamingContentUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //What Console I want to use
            IConsole console = new FunConsole();
            //Pass that to my UI
            UserInterface ui = new UserInterface(console);
            ui.Run();
        }
    }
}
