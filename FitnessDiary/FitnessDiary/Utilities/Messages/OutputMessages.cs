using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDiary.Utilities.Messages
{
    public static class OutputMessages
    {
        public const string FitnessProgramCreated = "Fitness program is created.";
        public const string ExerciseCreated = "{0} with {1} Sets x {2}-{3} reps is created.";
        public const string LiftedWeightSet = "{0} maximum lifted weight set to {1}.";
        public const string ExerciseSetsUpdated = "{0} sets updated to {1}.";
        public const string ExerciseRepsUpdated = "{0} reps updated to {1}-{2}.";
        public const string ExerciseRemovedFromTheProgram = "At day {0} exercise at position {1} is successfully removed.";
        public const string ExerciseChangedAtGivenPosition = "At day {0} exercise at position {1} is successfully changed to {2}.";
        public const string ExerciseInsertedAtGivenPosition = "At day {0} exercise {1} is successfully inserted at {2} position.";
        public const string ExerciseAddedAtTheEnd = "At day {0} exercise {1} is successfully at the end of the program.";
    }
}
