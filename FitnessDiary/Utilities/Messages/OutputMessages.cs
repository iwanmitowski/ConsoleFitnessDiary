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
        public const string UserRegisteredSuccessfully = "{0}, you are registered successfully!";
        public const string TodayIsARestDay = "Today is a rest day!";
        public const string AddExercisesToTheProgram = "Add some exercises to the program!";
        public const string PleaseRegister = "Please, register by entering your name!";
        public const string InvalidInput = "Invalid input! Please, try something else";
        public const string Welcome = "Welcome, {0}! What muscles shall we train today ?";
        public const string SeeYouTomorrow = "See you tomorrow, {0}! BEASTMODE ON !!!";
        public const string ExerciseOptions = "1 - Exercise Options";
        public const string ExerciseOptionsA = "   A - Create exercise ";
        public const string ExerciseOptionsB = "   B - Set maximum lifted weight to specific exercise by it's name";
        public const string ExerciseOptionsC = "   C - Update specifit exercise sets";
        public const string ExerciseOptionsD = "   D - Update specifit exercise minimum and maximum repetitions";
        public const string ExerciseOptionsE = "   E - Show detailed exercise information";
        public const string FitnessProgramOptions = "2 - Fitness Program Options";
        public const string FitnessProgramOptionsA = "   A - Show the weekly program";
        public const string FitnessProgramOptionsB = "   B - Add exercise at the end of the program";
        public const string FitnessProgramOptionsC = "   C - Insert specific exercise in the program";
        public const string FitnessProgramOptionsD = "   D - Change exercise in the program";
        public const string FitnessProgramOptionsE = "   E - Remove exercise from position in the program";
        public const string OptionExit = "3 - Exit";
        public const string OptionBack = "   Back - to return to the previous menu";
        public const string CreateYourFirstExercise = "It's time to create your first exercise!";
        public const string CreateExerciseInstructions = "Please enter: Exercise name, sets, minimum repetitions, maximum repetitions.";
        public const string SetMaxLiftedWeightInstructions = "Please enter: Exercise name, maximum lifted weight. ";
        public const string UpdateExerciseSetsInstructions = "Please enter: Exercise name, new sets";
        public const string UpdateExerciseRepsInstructions = "Please enter: Exercise name, new minimum and maximum repetitions.";
        public const string AddExerciseAtTheEndOfTheProgramInstructions = "Please enter: Day of week, exercise name.";
        public const string InsertAndChangeExerciseInstructions = "Please enter: Day of week, position, exercise name.";
        public const string RemoveExerciseInstructions = "Please enter: Day of week, position.";
        public const string CreateExercises = "The file is empty, create some exercises";
    }
}
