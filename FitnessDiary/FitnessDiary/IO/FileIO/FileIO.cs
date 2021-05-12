using FitnessDiary.IO.FileIO.Contracts;
using System.IO;

namespace FitnessDiary.IO.FileIO
{
    public abstract class FileIO : IFileIO
    {
        private string path;
        public FileIO(string path)
        {
            this.Path = path;
        }
        public string Path
        {
            get
            {
                return this.path;
            }
            private set
            {
                this.path = value;
            }
            
        }

        public abstract void SetCollection<T>(T collection);

        public abstract string GetText();

        public void AppendAllText(string text)
        {
            File.AppendAllText(Path, text);
        }

        public void WriteAllText()
        {
            File.WriteAllText(this.Path, GetText());
        }

        public string[] ReadAllLines()
        {
            return File.ReadAllLines(this.Path);
        }
    }
}
