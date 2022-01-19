using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamingContentUI.Consoles
{
    //Define what a console needs to be able to do
    public interface IConsole
    {
        //Clear
        void Clear();

        //WriteLine
        void WriteLine(string s);

        void WriteLine(object o);

        //Write
        void Write(string s);

        void Write(object o);

        //ReadLine
        string ReadLine();

        //ReadKey
        ConsoleKeyInfo ReadKey();
    }
}