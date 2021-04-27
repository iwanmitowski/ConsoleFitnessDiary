namespace FitnessDiary.Core.Contracts
{
    public interface IController
    {
        void DisableMaximizingAndResizing();
        void ChangeAppearence();
        string CreateExercise(string name, int sets, int minimumRepetitions, int maximumRepetitions);
        string SetMaxLiftedWeightToExercise(string name, double liftedWeight);
        string UpdateExerciseSets(string name, int sets);
        string UpdateExerciseReps(string name, int minReps, int maxReps);
        string CreateFitnessProgram();
        string AddExerciseToTheEndOfTheProgram(string weekDay, string exerciseName);
        string InsertExerciseSomewhereInTheProgram(string weekDay, int position, string exerciseName);
        string ChangeExerciseSomewhereInTheProgramWithAnother(string weekDay, int position, string exerciseName);
        string RemoveExerciseFromPositionInTheProgram(string weekDay, int position);
        string ShowDailyProgram();
        string ShowWeeklyProgram();
        void SetCollectionToFitnesProgramIO();
        void WriteTheFitnessProgramInFile();
        void SetCollectionToExerciseIO();
        void WriteAllExercisesFromTheExerciseHistoryInFile();
        void ExerciseFiller();
        void ProgramFiller();
        string Register(string name);
        bool CheckIfTheUserIsRegistered();
        void SetUserName();
        string GetName();
    }
}

