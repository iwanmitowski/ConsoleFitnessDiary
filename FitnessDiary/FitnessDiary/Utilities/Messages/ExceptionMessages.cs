using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDiary.Utilities.Messages
{
    public static class ExceptionMessages
    {
        public const string InvalidName = "The name cannot be null, white space or over {0} symbols!";
        public const string InvalidSeries = "Series cannot be less or equal to zero!";
        public const string InvalidRepetitions = "Repetitions cannot be less or equal to zero!";
        public const string InvalidMaxLiftedWeightZeroOrLess = "Max lifted weight cannot be less or equal to zero!";
        public const string InvalidMaxLiftedWeightLessThanCurrent= "Max lifted weight cannot be less or equal to zero!";
        public const string InvalidNumber = "The number cannot be less or equal to zero!";
        public const string NoExercisesInTheProgram = "There are no exercises to remove!";

        public const string ExerciseExists = "Exercise {0} already exists.";
        public const string ExerciseNotFound = "Exercise {0} not found.";
    }
}
