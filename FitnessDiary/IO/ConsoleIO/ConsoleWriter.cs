using FitnessDiary.IO.Contracts;
using System;

namespace FitnessDiary.IO
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void Write(string message)
        {
            Console.Write(message);
        }
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
