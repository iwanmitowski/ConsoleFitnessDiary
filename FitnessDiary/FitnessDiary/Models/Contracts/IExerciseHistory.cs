using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
