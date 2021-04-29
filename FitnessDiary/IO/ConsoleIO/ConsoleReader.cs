using FitnessDiary.IO.Contracts;
using System;

namespace FitnessDiary.IO
{
    public class ConsoleReader : IConsoleReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
