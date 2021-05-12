using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDiary.IO.FileIO.Contracts
{
    public interface IUserFileIO :IFileReader,IFileWriter,IUserValidator
    {
        string Path { get; }
        string User { get; }
        void SetUser();
        void Register(string name);
    }
}
