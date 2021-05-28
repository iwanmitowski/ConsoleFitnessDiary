using FitnessDiary.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDiary.Models.TableUtilities.Contracts
{
    public interface ITableBuilder
    {
        void BuildTable(Dictionary<WeekDays, List<IExercise>> exercises);
    }
}
