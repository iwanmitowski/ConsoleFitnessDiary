using FitnessDiary.Core.Contracts;
using FitnessDiary.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDiary.Core
{
    public class Engine : IEngine
    {
        private readonly IController controller;

        private readonly IConsoleReader consoleInputReader;
        private readonly IConsoleWriter consoleInputWriter;

        public Engine(IController controller,
            IConsoleReader consoleInputReader,
            IConsoleWriter consoleInputWriter)
        {
            this.controller = controller;
            this.consoleInputReader = consoleInputReader;
            this.consoleInputWriter = consoleInputWriter;
        }
        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}
