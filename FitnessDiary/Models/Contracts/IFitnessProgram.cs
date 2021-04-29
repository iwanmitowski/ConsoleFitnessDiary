using FitnessDiary.Utilities.Enums;
using System.Collections.Generic;

namespace FitnessDiary.Models.Contracts
{
    public interface IFitnessProgram
    {
        IReadOnlyDictionary<WeekDays, List<IExercise>> Exercises { get; }
        void Add(WeekDays day, IExercise exercise);

        void Insert(WeekDays day, int number, IExercise exercise);

        void Remove(WeekDays day, int number);

        void Change(WeekDays day, int number, IExercise exercise);

    }
}
