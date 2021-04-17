using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDiary.Models.Contracts
{
    interface IFitnessProgram
    {
        IReadOnlyDictionary<DayOfWeek, List<IExercise>> Exercises { get; }
        void Add(DayOfWeek day,IExercise exercise);

        void Insert(DayOfWeek day, int number, IExercise exercise);

        void Remove(DayOfWeek day, int number);

        void Update(DayOfWeek day, int number, IExercise exercise);

        void ShowWeekly();

        void ShowDaily();

    }
}
