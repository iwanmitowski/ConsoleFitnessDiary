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
        public string Path { get; private set; }

        public abstract void SetCollection<T>(T collection);

        public abstract string GetText();
        //write
        public void AppendAllText()
        {
            File.AppendAllText(Path, GetText());

        }

        public void WriteAllText()
        {
            File.WriteAllText(this.Path, GetText());
        }

        //read
        public string[] ReadAllLines()
        {
            return File.ReadAllLines(this.Path);
        }
    }
}
