using FitnessDiary.Models.TableUtilities.TableBuilders.Contracts;
using FitnessDiary.Utilities.Enums;
using System.Collections.Generic;

namespace FitnessDiary.Models.TableUtilities
{
    public abstract class TableBuilder:ITableBuilder
    {
        protected readonly IReadOnlyDictionary<WeekDays, List<IExercise>> exercises;

        public TableBuilder(IReadOnlyDictionary<WeekDays, List<IExercise>> exercises)
        {
            this.exercises = exercises;
        }
        public abstract string BuildTable();
        protected abstract int GetLongestExerciseName();
    }
}
