namespace FitnessDiary.Utilities.Messages
{
    public static class ExceptionMessages
    {
        public const string InvalidName = "The name cannot be null, white space or over {0} symbols!";
        public const string InvalidSeries = "Series cannot be less or equal to zero!";
        public const string InvalidRepetitions = "Repetitions cannot be less or equal to zero!";
        public const string InvalidMaxRepsCantBeLessThanMinReps = "Maximum Repetitions cannot be less than minimum repetitions!";
        public const string InvalidMaxLiftedWeightZeroOrLess = "Max lifted weight cannot be less or equal to zero!";
        public const string InvalidMaxLiftedWeightLessThanCurrent= "Max lifted weight cannot be less than the current maximum lifted weight!";
        public const string InvalidNumber = "The number cannot be less or equal to zero!";
        public const string InvalidNumberUpperBorder = "The number cannot be greater than the exercise count!";
        public const string NoExercisesInTheProgram = "There are no exercises to remove!";
        public const string InvalidWeekDay = "{0} is not a valid week day!";
        public const string ExerciseExists = "Exercise {0} already exists!";
        public const string ExerciseNotFound = "Exercise {0} not found. Create it first!";
        public const string UserNameNotSet = "There is not set username!";
        public const string InvalidInputType = "The input was not correct! Try again!";
        public const string InvalidParametersInput = "The parameters are less than expected. Ensure you haven't missed something!";
        public const string TooBigNumber = "Chill! Even Arnold didn't train like that. The input number is too big!";
    }
}
