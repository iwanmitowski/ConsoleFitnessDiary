using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDiary.Core.Contracts
{
    //BONUS: Registering name on first opening and showing Welcome, back {name}?

    //ExerciseRepository
    //adding exercises, reading the exercises


    //Create exercise or update if existing (reps/sets)
    //Setting max lifted weight
    //List with registered exercises ?!

    //Create fitness program if the file is empty

    //AddExercise
    //InsertExercise
    //RemoveExercise
    //Update

    // The input number should be decreased with 1!!!!!

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

        //public string UpdateExerciseSets(string name, int sets);

        //public string UpdateExerciseReps(string name, int reps);

        //public string AddExerciseToTheEndOfTheProgram(string week, string exerciseName);
        //public string InsertExerciseSomewhereInTheProgram(string week, int position ,string exerciseName);
        //public string ChangeExerciseSomewhereInTheProgram(string week, int position ,string exerciseName);//Update
        //public string RemoveExerciseFromPositionFromTheProgram(string week, int position ,string exerciseName);

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

