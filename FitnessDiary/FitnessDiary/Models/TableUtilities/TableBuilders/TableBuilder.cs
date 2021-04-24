using FitnessDiary.Models.TableUtilities.TableBuilders.Contracts;
using FitnessDiary.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
