namespace FitnessDiary.Core.Contracts
{
    public interface IController
    {
        void DisableMaximizingAndResizing();
        void ChangeAppearence();
        void NormalTextColor();
        void ExceptionTextColor();
        void MenuTextColor();
        string CreateExercise(string name, string sets, string minimumRepetitions, string maximumRepetitions);
        string SetMaxLiftedWeightToExercise(string name, string liftedWeight);
        string UpdateExerciseSets(string name, string sets);
        string UpdateExerciseReps(string name, string minReps, string maxReps);
        string ShowDetailedExerciseInfo();
        string CreateFitnessProgram();
        string AddExerciseAtTheEndOfTheProgram(string weekDay, string exerciseName);
        string InsertExerciseSomewhereInTheProgram(string weekDay, string position, string exerciseName);
        string ChangeExerciseSomewhereInTheProgramWithAnother(string weekDay, string position, string exerciseName);
        string RemoveExerciseFromPositionInTheProgram(string weekDay, string position);
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
        void CheckTheNeededLength(int current, int expected);
    }
}

