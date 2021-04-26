namespace FitnessDiary.Core.Factory.Contracts
{
    public interface IExerciseFactory
    {
        IExercise CreateExercise(string name, int sets, int minimumRepetitions, int maximumRepetitions);
    }
}
