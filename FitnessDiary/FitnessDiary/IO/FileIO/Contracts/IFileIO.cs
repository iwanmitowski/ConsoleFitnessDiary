namespace FitnessDiary.IO.FileIO.Contracts
{
    public interface IFileIO:IFileReader, IFileWriter, ICollectionSetter
    {
        string GetText();
    }
}
