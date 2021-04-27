using FitnessDiary.IO.FileIO.Contracts;
using FitnessDiary.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDiary.IO.FileIO
{
    public class UserFileIO : IUserFileIO
    {
        private const int MaxNameLength = 24;

        private string user;
        public UserFileIO(string path)
        {
            this.Path = path;
        }

        public string Path { get; private set; }
        public string User
        {
            get
            {
                return this.user;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, MaxNameLength));
                }
                
                this.user = value;
            }
        }

        public void AppendAllText(string text)
        {
            File.AppendAllText(this.Path, text);
        }

        public bool IsTheUserExisting()
        {
            return ReadAllLines().Length != 0;
        }

        public string[] ReadAllLines()
        {
            return File.ReadAllLines(this.Path);
        }

        public void WriteAllText()
        {
            File.WriteAllText(this.Path, this.user);
        }

        public void SetUser()
        {
            var lines = ReadAllLines();

            if (lines.Length==0)
            {
                throw new ArgumentException(ExceptionMessages.UserNameNotSet);
            }

            this.user = lines[0];

        }

        public void Register(string username)
        {
            this.User = username;
            WriteAllText();
        }

        
    }
}
