using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamingContentUI.Consoles
{
    public class FunConsole : IConsole
    {
        private Random _random = new Random();
        public void Clear()
        {
            Console.Clear();
            Console.BackgroundColor = (ConsoleColor)_random.Next(0, 16);
        }

        public ConsoleKeyInfo ReadKey()
        {
            Console.Beep();
            return Console.ReadKey();
        }

        public string ReadLine()
        {
            Console.Beep();
            return Console.ReadLine();
        }

        public void Write(string s)
        {
            Console.ForegroundColor = (ConsoleColor)_random.Next(0,16);
            Console.Write(s);
        }

        public void Write(object o)
        {
            Console.ForegroundColor = (ConsoleColor)_random.Next(0,16);
            Console.Write(o);
        }

        public void WriteLine(string s)
        {
            Console.ForegroundColor = (ConsoleColor)_random.Next(0,16);
            Console.WriteLine(s);
        }

        public void WriteLine(object o)
        {
            Console.ForegroundColor = (ConsoleColor)_random.Next(0,16);
            Console.WriteLine(o);
        }
    }
}