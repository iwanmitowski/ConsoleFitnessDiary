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
using System.Text;

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
        IUserFileIO userFileIO;
        private IFitnessProgram fitnessProgram;
        public Controller(IExerciseFactory exerciseFactory,
            IExerciseHistory exerciseHistory,
            IFitnessProgramFactory fitnessProgramFactory,
            ITableBuilderFactory tableBuilderFactory,
            IFileIO fitnessProgramIO,
            IFileIO exerciseIO,
            IUserFileIO userFileIO)
        {
            this.exerciseFactory = exerciseFactory;
            this.exerciseHistory = exerciseHistory;
            this.fitnessProgramFactory = fitnessProgramFactory;
            this.tableBuilderFactory = tableBuilderFactory;
            this.fitnessProgramIO = fitnessProgramIO;
            this.exerciseIO = exerciseIO;
            this.userFileIO = userFileIO;
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
            NormalTextColor();
        }
        public void ExceptionTextColor()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
        }
        public void NormalTextColor()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;

        }public void MenuTextColor()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;

        }
        public string CreateFitnessProgram()
        {
            this.fitnessProgram = fitnessProgramFactory.CreateFitnessProgram();

            return OutputMessages.FitnessProgramCreated;
        }


        //Business logic
        public string CreateExercise(string name, string setsAsString, string minimumRepetitionsAsString, string maximumRepetitionsAsString)
        {
            int sets = NumberParser.TryParse<int>(setsAsString, int.TryParse);
            int minimumRepetitions = NumberParser.TryParse<int>(minimumRepetitionsAsString, int.TryParse);
            int maximumRepetitions = NumberParser.TryParse<int>(maximumRepetitionsAsString, int.TryParse);

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

        public string SetMaxLiftedWeightToExercise(string name, string liftedWeightAsString)
        {
            double liftedWeight = NumberParser.TryParse<double>(liftedWeightAsString, double.TryParse);

            var exercise = this.exerciseHistory.GetByName(name);

            CheckIfTheExerciseIsNotPresent(exercise, name);

            exercise.SetMaxLiftedWeight(liftedWeight);

            return string.Format(
                OutputMessages.LiftedWeightSet,
                name,
                liftedWeight);
        }

        public string UpdateExerciseSets(string name, string setsAsString)
        {
            int sets = NumberParser.TryParse<int>(setsAsString, int.TryParse);

            var exercise = this.exerciseHistory.GetByName(name);

            CheckIfTheExerciseIsNotPresent(exercise, name);

            exercise.UpdateSets(sets);

            return string.Format(
                OutputMessages.ExerciseSetsUpdated,
                name,
                sets);
        }

        public string UpdateExerciseReps(string name, string minRepsAsString, string maxRepsAsString)
        {
            int minReps = NumberParser.TryParse<int>(minRepsAsString, int.TryParse);
            int maxReps = NumberParser.TryParse<int>(maxRepsAsString, int.TryParse);

            var exercise = this.exerciseHistory.GetByName(name);

            CheckIfTheExerciseIsNotPresent(exercise, name);

            exercise.UpdateReps(minReps, maxReps);

            return string.Format(
                OutputMessages.ExerciseRepsUpdated,
                name,
                minReps,
                maxReps);
        }

        //To Do as table
        public string ShowDetailedExerciseInfo()
        {
            throw new NotImplementedException();
        }
        public string AddExerciseAtTheEndOfTheProgram(string weekDay, string exerciseName)
        {
            WeekDays currentDay = WeekDaysParser.Parse(weekDay);

            var exercise = this.exerciseHistory.GetByName(exerciseName);

            CheckIfTheExerciseIsNotPresent(exercise, exerciseName);

            this.fitnessProgram.Add(currentDay, exercise);

            return string.Format(
               OutputMessages.ExerciseAddedAtTheEnd,
               currentDay,
               exerciseName);
        }

        public string InsertExerciseSomewhereInTheProgram(string weekDay, string positionAsString, string exerciseName)
        {
            int position = NumberParser.TryParse<int>(positionAsString, int.TryParse);

            WeekDays currentDay = WeekDaysParser.Parse(weekDay);

            var exercise = this.exerciseHistory.GetByName(exerciseName);

            CheckIfTheExerciseIsNotPresent(exercise, exerciseName);

            this.fitnessProgram.Insert(currentDay, position, exercise);

            return string.Format(
               OutputMessages.ExerciseInsertedAtGivenPosition,
               currentDay,
               exerciseName,
               position);
        }

        public string ChangeExerciseSomewhereInTheProgramWithAnother(string weekDay, string positionAsString, string exerciseName)
        {
            int position = NumberParser.TryParse<int>(positionAsString, int.TryParse);

            WeekDays currentDay = WeekDaysParser.Parse(weekDay);

            var exercise = this.exerciseHistory.GetByName(exerciseName);

            CheckIfTheExerciseIsNotPresent(exercise, exerciseName);

            this.fitnessProgram.Change(currentDay, position, exercise);

            return string.Format(
                OutputMessages.ExerciseChangedAtGivenPosition,
                currentDay,
                position,
                exerciseName);
        }

        public string RemoveExerciseFromPositionInTheProgram(string weekDay, string positionAsString)
        {
            int position = NumberParser.TryParse<int>(positionAsString, int.TryParse);

            WeekDays currentDay = WeekDaysParser.Parse(weekDay);

            this.fitnessProgram.Remove(currentDay, position);

            return string.Format(
                OutputMessages.ExerciseRemovedFromTheProgram,
                currentDay,
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
                string sets = exerciseArguments[1];
                string minReps = exerciseArguments[2];
                string maxReps = exerciseArguments[3];
                string maxLifted = exerciseArguments[3];

                if (this.exerciseHistory.GetAll().Any(x => x.Name == name))
                {
                    continue;
                }

                this.CreateExercise(name, sets, minReps, maxReps);
                if (maxLifted != "0") this.SetMaxLiftedWeightToExercise(name, maxLifted);

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
                    this.AddExerciseAtTheEndOfTheProgram(weekDay, exerciseName);
                }
            }

        }


        //UserIO
        public string Register(string name)
        {
            this.userFileIO.Register(name);

            return string.Format(
               OutputMessages.UserRegisteredSuccessfully,
               name);
        }
        public bool CheckIfTheUserIsRegistered()
        {
            return this.userFileIO.IsTheUserExisting();
        }
        public void SetUserName()
        {
            this.userFileIO.SetUser();
        }
        public string GetName()
        {
            return this.userFileIO.User;
        }
        

        //Helpers
        private void CheckIfTheExerciseIsNotPresent(IExercise exercise, string name)
        {
            if (exercise == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new InvalidOperationException(
                    string.Format(
                    ExceptionMessages.ExerciseNotFound,
                    name));
            }
        }
        public void CheckTheNeededLength(int current, int expected)
        {
            if (current<expected)
            {

                throw new InvalidOperationException(ExceptionMessages.InvalidParametersInput);
            }
        }
    }
}
