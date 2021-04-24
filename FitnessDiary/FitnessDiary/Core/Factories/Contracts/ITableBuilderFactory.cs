using FitnessDiary.Models.TableUtilities.TableBuilders.Contracts;
using FitnessDiary.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDiary.Core.Factories.Contracts
{
    public interface ITableBuilderFactory
    {
        ITableBuilder CreateTableBuilder(string type, IReadOnlyDictionary<WeekDays, List<IExercise>> exercises);
    }
}
