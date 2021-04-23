using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDiary.IO.Contracts
{
    public interface IConsoleWriter
    {
        void WriteLine(string message);
        void Write(string message);
    }
}
