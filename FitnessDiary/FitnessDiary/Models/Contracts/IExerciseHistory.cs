using System.Collections.Generic;

namespace FitnessDiary.Models.Contracts
{
    public interface IExerciseHistory
    {
        IExercise GetByName(string name);

        void Add(IExercise exercise);
        IReadOnlyCollection<IExercise> GetAll();
        void UpdateFileWithExercises();
        void FillExercisesFromFile();
    }
}
