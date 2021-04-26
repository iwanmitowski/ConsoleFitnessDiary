using FitnessDiary.Models.TableUtilities.TableBuilders.Contracts;
using FitnessDiary.Utilities.Enums;
using System.Collections.Generic;

namespace FitnessDiary.Core.Factories.Contracts
{
    public interface ITableBuilderFactory
    {
        ITableBuilder CreateTableBuilder(string type, IReadOnlyDictionary<WeekDays, List<IExercise>> exercises);
    }
}
