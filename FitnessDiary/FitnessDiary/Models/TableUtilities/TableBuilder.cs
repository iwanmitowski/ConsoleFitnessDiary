
using FitnessDiary.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDiary.Models.TableUtilities
{
    public abstract class TableBuilder
    {
        //To think how to divide teh logic
        protected abstract void BuildTable(Dictionary<WeekDays, List<IExercise>> exercises);

    }
}
