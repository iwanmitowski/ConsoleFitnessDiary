using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDiary.Core.Contracts
{
    //BONUS: Registering name on first opening and showing Welcome, back {name}?

    //ExerciseHistory   (done)
    //adding exercises, reading the exercises   (done)


    //Create exercise or update if existing (reps/sets)  (done)
    //Setting max lifted weight     (done)
    //List with registered exercises    (done)

    //Create fitness program (done) if the file is empty!!!!!!!!!

    //AddExercise
    //InsertExercise
    //RemoveExercise
    //Update

    // The input number should be decreased with 1!!!!!     (done)

    //ShowDaily if registered
    //ShowWeekly if chosen option

    //Writting the program in file.
    //Writting all the exercises registered

    //Understandable UI

    //Move the maximizing restriction in Method ?
    public interface IController
    {
        public string CreateExercise(string name, int sets, int minimumRepetitions, int maximumRepetitions);
        public string SetMaxLiftedWeightToExercise(string name, double liftedWeight);
        public string UpdateExerciseSets(string name, int sets);
        public string UpdateExerciseReps(string name, int minReps, int maxReps);
        public string CreateFitnessProgram();
        public string AddExerciseToTheEndOfTheProgram(string weekDay, string exerciseName);
        public string InsertExerciseSomewhereInTheProgram(string weekDay, int position, string exerciseName);
        public string ChangeExerciseSomewhereInTheProgramWithAnother(string weekDay, int position, string exerciseName);
        public string RemoveExerciseFromPositionInTheProgram(string weekDay, int position);

        //public string ShowDailyProgram();
        //public string ShowWeeklyProgram();



        //To think about these more:
        //void WriteDailyProgramInFile();
        //void ReadDailyProgramFromFile();
        //void WriteWeeklyProgramFromFile();
        //void ReadWeeklyProgramFromFile();
        //void UpdateExerciseMaxInFile();
        //void ReadExerciseMaxFromFile();

    }

}

