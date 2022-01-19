using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamingContentUI.Consoles
{
    //Mock console will be used to test UI
    public class MockConsole : IConsole
    {
        //Some way of giving input commands
        public Queue<string> UserInput;

        //Some way of tracking output
        //Visable from outside but can only be altered internally
        public string Output { get; private set; }

        public MockConsole(IEnumerable<string> input)
        {
            UserInput = new Queue<string>(input);

            Output = "";
        }


        public void Clear()
        {
            //Tracking that Console clear was called
            Output += "Console Clear was Called\n";
        }

        public ConsoleKeyInfo ReadKey()
        {
            Output += "Readkey called\n";
            return new ConsoleKeyInfo();
        }

        public string ReadLine()
        {
            Output += "ReadLine called\n";
            return UserInput.Dequeue();
        }

        public void Write(string s)
        {
            Output += s;
        }

        public void Write(object o)
        {
            Output += o;
        }

        public void WriteLine(string s)
        {
            Output += s + "\n";
        }

        public void WriteLine(object o)
        {
            Output += o + "\n";
        }
    }
}