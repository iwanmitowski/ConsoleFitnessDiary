using FitnessDiary.Core.Contracts;
using FitnessDiary.Core.Factories.Contracts;
using FitnessDiary.Core.Factory.Contracts;
using FitnessDiary.IO.FileIO.Contracts;
using FitnessDiary.Models.Contracts;
using FitnessDiary.Models.TableUtilities.TableBuilders.Contracts;
using FitnessDiary.Utilities.Enums;
using FitnessDiary.Utilities.Messages;
using FitnessDiary.Utilities.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace FitnessDiary.Core
{
    public class Controller : IController
    {
        private const int mfByCommand = 0x00000000;
        public const int scClose = 0xF060;
        public const int scMaximize = 0xF030;
        public const int scResize = 0xF000;

        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();


        private readonly IExerciseFactory exerciseFactory;
        private readonly IExerciseHistory exerciseHistory;
        private readonly IFitnessProgramFactory fitnessProgramFactory;
        private ITableBuilderFactory tableBuilderFactory;
        private ITableBuilder dailyTableBuilder;
        private ITableBuilder weeklyTableBuilder;

        IFileIO fitnessProgramIO;
        IFileIO exerciseIO;

        private IFitnessProgram fitnessProgram;
        public Controller(IExerciseFactory exerciseFactory,
            IExerciseHistory exerciseHistory,
            IFitnessProgramFactory fitnessProgramFactory,
            ITableBuilderFactory tableBuilderFactory,
            IFileIO fitnessProgramIO,
            IFileIO exerciseIO)
        {
            this.exerciseFactory = exerciseFactory;
            this.exerciseHistory = exerciseHistory;
            this.fitnessProgramFactory = fitnessProgramFactory;
            this.tableBuilderFactory = tableBuilderFactory;
            this.fitnessProgramIO = fitnessProgramIO;
            this.exerciseIO = exerciseIO;
        }

        //SetUp Methods
        public void DisableMaximizingAndResizing()
        {
            IntPtr handle = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(handle, false);

            if (handle != IntPtr.Zero)
            {
                DeleteMenu(sysMenu, scMaximize, mfByCommand);
                DeleteMenu(sysMenu, scResize, mfByCommand);
            }
        }

        public void ChangeAppearence()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
        }

        public string CreateFitnessProgram()
        {
            this.fitnessProgram = fitnessProgramFactory.CreateFitnessProgram();

            return OutputMessages.FitnessProgramCreated;
        }

        public string CreateExercise(string name, int sets, int minimumRepetitions, int maximumRepetitions)
        {
            if (this.exerciseHistory.GetAll().Any(x => x.Name == name))
            {
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionMessages.ExerciseExists,
                        name));
            }

            var exercise = this.exerciseFactory.CreateExercise(name, sets, minimumRepetitions, maximumRepetitions);
            this.exerciseHistory.Add(exercise);

            return string.Format(
                OutputMessages.ExerciseCreated,
                name,
                sets,
                minimumRepetitions,
                maximumRepetitions
                );
        }

        public string SetMaxLiftedWeightToExercise(string name, double liftedWeight)
        {
            var exercise = this.exerciseHistory.GetByName(name);

            CheckIfTheExerciseIsNotPresent(exercise, name);

            exercise.SetMaxLiftedWeight(liftedWeight);

            return string.Format(
                OutputMessages.LiftedWeightSet,
                name,
                liftedWeight
                );
        }

        public string UpdateExerciseSets(string name, int sets)
        {
            var exercise = this.exerciseHistory.GetByName(name);

            CheckIfTheExerciseIsNotPresent(exercise, name);

            exercise.UpdateSets(sets);

            return string.Format(
                OutputMessages.ExerciseSetsUpdated,
                name,
                sets);
        }

        public string UpdateExerciseReps(string name, int minReps, int maxReps)
        {
            var exercise = this.exerciseHistory.GetByName(name);

            CheckIfTheExerciseIsNotPresent(exercise, name);

            exercise.UpdateReps(minReps, maxReps);

            return string.Format(
                OutputMessages.ExerciseRepsUpdated,
                name,
                minReps,
                maxReps);

        }

        //Add EXCEPTION IF NOT REGISTERED! AND UNIT TESTS!

        public string AddExerciseToTheEndOfTheProgram(string weekDay, string exerciseName)
        {
            WeekDays currentDay = WeekDaysParser.Parse(weekDay);

            var exercise = this.exerciseHistory.GetByName(exerciseName);

            CheckIfTheExerciseIsNotPresent(exercise, exerciseName);

            this.fitnessProgram.Add(currentDay, exercise);

            return string.Format(
               OutputMessages.ExerciseAddedAtTheEnd,
               weekDay,
               exerciseName);
        }
        //Add EXCEPTION IF NOT REGISTERED! AND UNIT TESTS!

        public string InsertExerciseSomewhereInTheProgram(string weekDay, int position, string exerciseName)
        {
            WeekDays currentDay = WeekDaysParser.Parse(weekDay);

            var exercise = this.exerciseHistory.GetByName(exerciseName);

            CheckIfTheExerciseIsNotPresent(exercise, exerciseName);

            this.fitnessProgram.Insert(currentDay, position, exercise);

            return string.Format(
               OutputMessages.ExerciseInsertedAtGivenPosition,
               weekDay,
               exerciseName,
               position);
        }
        //Add EXCEPTION IF NOT REGISTERED! AND UNIT TESTS!

        public string ChangeExerciseSomewhereInTheProgramWithAnother(string weekDay, int position, string exerciseName)
        {
            WeekDays currentDay = WeekDaysParser.Parse(weekDay);

            var exercise = this.exerciseHistory.GetByName(exerciseName);

            CheckIfTheExerciseIsNotPresent(exercise, exerciseName);

            this.fitnessProgram.Change(currentDay, position, exercise);

            return string.Format(
                OutputMessages.ExerciseChangedAtGivenPosition,
                weekDay,
                position,
                exerciseName);
        }
        //Add EXCEPTION IF NOT REGISTERED! AND UNIT TESTS!

        public string RemoveExerciseFromPositionInTheProgram(string weekDay, int position)
        {
            WeekDays currentDay = WeekDaysParser.Parse(weekDay);

            this.fitnessProgram.Remove(currentDay, position);

            return string.Format(
                OutputMessages.ExerciseRemovedFromTheProgram,
                weekDay,
                position);
        }
        public string ShowDailyProgram()
        {
            this.dailyTableBuilder = tableBuilderFactory.
                CreateTableBuilder(
                "Daily",
                this.fitnessProgram.Exercises);

            return this.dailyTableBuilder.BuildTable();
        }

        public string ShowWeeklyProgram()
        {
            this.weeklyTableBuilder = tableBuilderFactory.
                CreateTableBuilder(
                "Weekly",
                this.fitnessProgram.Exercises);
            
            return this.weeklyTableBuilder.BuildTable();
        }
       

        //Fitness Program IO
        public void SetCollectionToFitnesProgramIO()
        {
            this.fitnessProgramIO.SetCollection(this.fitnessProgram.Exercises);
        }

        public void WriteTheFitnessProgramInFile()
        {
            this.fitnessProgramIO.WriteAllText();
        }


        //Exercises IO
        public void SetCollectionToExerciseIO()
        {
            this.exerciseIO.SetCollection(this.exerciseHistory.GetAll());
        }
        public void WriteAllExercisesFromTheExerciseHistoryInFile()
        {
            this.exerciseIO.WriteAllText();
        }
        
        //Fillers
        public void ExerciseFiller()
        {
            string[] input = this.exerciseIO.ReadAllLines();

            foreach (var line in input)
            {
                string[] exerciseArguments = line.
                    Split(",", StringSplitOptions.RemoveEmptyEntries).
                    ToArray();

                string name = exerciseArguments[0];
                int sets = int.Parse(exerciseArguments[1]);
                int minReps = int.Parse(exerciseArguments[2]);
                int maxReps = int.Parse(exerciseArguments[3]);
                double maxLifted = double.Parse(exerciseArguments[3]);

                if (this.exerciseHistory.GetAll().Any(x=>x.Name==name))
                {  
                    continue;
                }

                this.CreateExercise(name, sets, minReps, maxReps);
                if (maxLifted != 0) this.SetMaxLiftedWeightToExercise(name, maxLifted);

            }
        }

        public void ProgramFiller()
        {
            string[] input = this.fitnessProgramIO.ReadAllLines();

            foreach (var line in input)
            {
                string[] exerciseArguments = line.
                    Split(",", StringSplitOptions.RemoveEmptyEntries).
                    ToArray();

                string weekDay = exerciseArguments[0];

                foreach (var exerciseName in exerciseArguments.Skip(1))
                {
                    this.AddExerciseToTheEndOfTheProgram(weekDay, exerciseName);
                }
            }

        }













        //Helpers
        private void CheckIfTheExerciseIsNotPresent(IExercise exercise, string name)
        {
            if (exercise == null)
            {
                throw new InvalidOperationException(
                    string.Format(
                    ExceptionMessages.ExerciseNotFound,
                    name));
            }
        }






    }
}
