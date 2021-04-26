namespace FitnessDiary.IO.FileIO.Contracts
{
    public interface IFileWriter
    {
        void WriteAllText();
        void AppendAllText(string exercise);
    }
}
