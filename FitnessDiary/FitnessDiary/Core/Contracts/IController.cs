namespace FitnessDiary.Core.Contracts
{
    //BONUS: Registering name on first opening and showing Welcome, back {name}?

    //ExerciseHistory   (done)
    //adding exercises, reading the exercises   (done)


    //Create exercise or update if existing (reps/sets)  (done)
    //Setting max lifted weight     (done)
    //List with registered exercises    (done)

    //Create fitness program (done) if the file is empty!!!!!!!!!

    //AddExercise     (done) 
    //InsertExercise     (done)
    //RemoveExercise     (done)
    //Update     (done)

    // The input number should be decreased with 1!!!!!     (done)

    //ShowDaily if registered      (50% done)
    //ShowWeekly if chosen option      (done)

    //Writting the program in file.     (done)
    //Writting all the exercises registered     (done)




    //Reading and creating

    //Understandable UI

    //Console colors and font change

    public interface IController
    {
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
        void DisableMaximizingAndResizing();
        //IO
        void SetCollectionToFitnesProgramIO();
        void WriteTheFitnessProgramInFile();

        void SetCollectionToExerciseIO();
        void WriteAllExercisesFromTheExerciseHistoryInFile();

        void ExerciseFiller();
        void ProgramFiller();

        //To think about these more:
        //void WriteDailyProgramInFile();
        //void ReadDailyProgramFromFile();
        //void WriteWeeklyProgramFromFile();
        //void ReadWeeklyProgramFromFile();
        //void UpdateExerciseMaxInFile();
        //void ReadExerciseMaxFromFile();

    }

}

