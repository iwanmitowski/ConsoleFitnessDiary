using System;
using System.IO;
using FitnessDiary.Core;
using FitnessDiary.Core.Factories;
using FitnessDiary.Core.Factories.Contracts;
using FitnessDiary.Core.Factory;
using FitnessDiary.IO.FileIO;
using FitnessDiary.Models;
using FitnessDiary.Utilities.Messages;
using FitnessDiary.Utilities.Parsers;
using NUnit.Framework;

namespace FitnessDiary.Tests
{
    public class ControllerTests
    {
        private const string PlaceholderName1 = "Bench Press";
        private const string PlaceholderName2 = "Biceps Curl";
        private const string PlaceholderName3 = "Lat pulldown";
        private const int Sets = 3;
        private const int MinReps = 4;
        private const int MaxReps = 5;
        private const string SetsAsString = "3";
        private const string MinRepsAsString = "4";
        private const string MaxRepsAsString = "5";

        Controller controller;

        FitnessProgramFactory fitnessProgramFactory;
        FitnessProgram fitnessProgram;

        ExerciseFactory exerciseFactory;
        ExerciseHistory exerciseHistory;

        TableBuilderFactory tableBuilderFactory;

        Exercise exercise1;
        Exercise exercise2;

        FitnessProgramIO fitnessProgramIO;
        ExerciseIO exerciseIO;
        UserFileIO userFileIO;

        [SetUp]
        public void SetUp()
        {
            this.exerciseFactory = new ExerciseFactory();
            this.exerciseHistory = new ExerciseHistory();
            this.fitnessProgramFactory = new FitnessProgramFactory();
            this.fitnessProgram = new FitnessProgram();
            this.fitnessProgramIO = new FitnessProgramIO(Path.Combine("..", "..", "..", "DataBase", "FitnessProgram.txt"));
            this.exerciseIO = new ExerciseIO(Path.Combine("..", "..", "..", "DataBase", "CreatedExercises.txt"));
            this.userFileIO = new UserFileIO(Path.Combine("..", "..", "..", "DataBase", "User.txt"));

            exercise1 = new Exercise(PlaceholderName1, Sets, MinReps, MaxReps);
            exercise2 = new Exercise(PlaceholderName2, Sets, MinReps, MaxReps);
            controller = new Controller(exerciseFactory,
                exerciseHistory,
                fitnessProgramFactory,
                tableBuilderFactory,
                fitnessProgramIO,
                exerciseIO,
                userFileIO);

            this.controller.CreateExercise(PlaceholderName1, SetsAsString, MinRepsAsString, MaxRepsAsString);
            this.controller.CreateFitnessProgram();
            this.controller.AddExerciseAtTheEndOfTheProgram("Monday", PlaceholderName1);
        }
        [Test]
        public void CreateFitnessProgramCreatesCorectly()
        {
            string expected = OutputMessages.FitnessProgramCreated;
            Assert.AreEqual(expected, this.controller.CreateFitnessProgram());
        }

        [Test]
        public void CreateExerciseCreatesCorectly()
        {
            string expected = string.Format(OutputMessages.ExerciseCreated, PlaceholderName2, Sets, MinReps, MaxReps);
            Assert.AreEqual(expected, this.controller.CreateExercise(PlaceholderName2, SetsAsString, MinRepsAsString, MaxRepsAsString));
        }

        [Test]
        public void CreateExerciseThrowsInvalidOperationExceptionIfExerciseExistsInTheHistory()
        {
            this.exerciseHistory.Add(exercise1);

            Assert.Throws<InvalidOperationException>(() => this.controller.CreateExercise(PlaceholderName1, SetsAsString, MinRepsAsString, MaxRepsAsString));

        }

        [TestCase(PlaceholderName1, "10")]
        [TestCase(PlaceholderName2, "20")]
        [TestCase(PlaceholderName2, "20.5")]
        public void SetMaxLiftedWeightToExerciseShouldWorkCorrectly(string name, string lifted)
        {
            this.exerciseHistory.Add(exercise1);
            this.exerciseHistory.Add(exercise2);
            string expected = string.Format(OutputMessages.LiftedWeightSet, name, lifted);

            Assert.AreEqual(expected, this.controller.SetMaxLiftedWeightToExercise(name, lifted));
        }

        [TestCase("Bicarka", "10")]
        [TestCase("Triceps", "20")]
        [TestCase("Triceps", "alo")]
        public void SetMaxLiftedWeightToExerciseThrowsExceptionIfExerciseIsMissing(string name, string lifted)
        {
            Assert.Throws<InvalidOperationException>(() => this.controller.SetMaxLiftedWeightToExercise(name, lifted));
        }

        [TestCase(PlaceholderName1, "2")]
        [TestCase(PlaceholderName2, "2")]
        public void UpdateExerciseSetsShouldWorkCorrectly(string name, string sets)
        {
            this.controller.CreateExercise(PlaceholderName2, SetsAsString, MinRepsAsString, MaxRepsAsString);

            string expected = string.Format(OutputMessages.ExerciseSetsUpdated, name, sets);

            Assert.AreEqual(expected, this.controller.UpdateExerciseSets(name, sets));
        }

        [TestCase(PlaceholderName1, "1", "2")]
        [TestCase(PlaceholderName2, "2", "3")]
        public void UpdateRepsSetsShouldWorkCorrectly(string name, string minReps, string maxReps)
        {
            this.controller.CreateExercise(PlaceholderName2, SetsAsString, MinRepsAsString, MaxRepsAsString);

            string expected = string.Format(OutputMessages.ExerciseRepsUpdated, name, minReps, maxReps);

            Assert.AreEqual(expected, this.controller.UpdateExerciseReps(name, minReps, maxReps));

        }

        [TestCase("monday", PlaceholderName1)]
        [TestCase("monDay", PlaceholderName1)]
        [TestCase("MonDay", PlaceholderName1)]
        [TestCase("MONDAY", PlaceholderName1)]
        [TestCase("Sunday", PlaceholderName1)]
        public void AddExerciseToTheEndOfTheProgramShouldWorkCorrectly(string weekDay, string exerciseName)
        {
            string expected = string.Format(OutputMessages.ExerciseAddedAtTheEnd, WeekDaysParser.Parse(weekDay).ToString(), exerciseName);

            Assert.AreEqual(expected, this.controller.AddExerciseAtTheEndOfTheProgram(weekDay, exerciseName));
        }

        [TestCase("monday", "1", PlaceholderName1)]


        public void InsertExerciseSomewhereInTheProgramShouldWorkCorrectly(string weekDay, string position, string exerciseName)
        {
            this.controller.CreateExercise(PlaceholderName2, SetsAsString, MinRepsAsString, MaxRepsAsString);

            string expected1 = string.Format(OutputMessages.ExerciseInsertedAtGivenPosition, WeekDaysParser.Parse(weekDay).ToString(), PlaceholderName2, position);
            string expected = string.Format(OutputMessages.ExerciseInsertedAtGivenPosition, WeekDaysParser.Parse(weekDay).ToString(), exerciseName, position);

            Assert.AreEqual(expected1, this.controller.InsertExerciseSomewhereInTheProgram(weekDay, position, PlaceholderName2));
            Assert.AreEqual(expected, this.controller.InsertExerciseSomewhereInTheProgram(weekDay, position, exerciseName));
        }

        [TestCase("MonDay", "3", PlaceholderName1)]
        [TestCase("MONDAY", "4", PlaceholderName1)]
        [TestCase("Sunday", "5", PlaceholderName1)]
        [TestCase("Sunday", "0", PlaceholderName1)]

        public void ShouldNotInsertExerciseSomewhereInTheProgramIfThePositionIsInvalid(string weekDay, string position, string exerciseName)
        {
            Assert.Throws<ArgumentException>(() => this.controller.InsertExerciseSomewhereInTheProgram(weekDay, position, exerciseName));
        }

        [TestCase("MonDay", "alo", PlaceholderName1)]
        [TestCase("MONDAY", "gosho", PlaceholderName1)]
        [TestCase("Sunday", "pesho", PlaceholderName1)]
        [TestCase("Sunday", "tosho", PlaceholderName1)]

        public void ShouldNotInsertExerciseSomewhereInTheProgramIfThePositionIsString(string weekDay, string position, string exerciseName)
        {
            Assert.Throws<InvalidOperationException>(() => this.controller.InsertExerciseSomewhereInTheProgram(weekDay, position, exerciseName));
        }
        [TestCase("monday", "1", PlaceholderName2)]
        [TestCase("monday", "2", PlaceholderName1)]
        public void ChangeExerciseSomewhereInTheProgramWithAnother(string weekDay, string position, string exerciseName)
        {
            this.controller.CreateExercise(PlaceholderName2, SetsAsString, MinRepsAsString, MaxRepsAsString);
            this.controller.CreateExercise(PlaceholderName3, SetsAsString, MinRepsAsString, MaxRepsAsString);
            this.controller.AddExerciseAtTheEndOfTheProgram("monday", PlaceholderName3);

            string expected = string.Format(OutputMessages.ExerciseChangedAtGivenPosition, WeekDaysParser.Parse(weekDay).ToString(), position, exerciseName);

            Assert.AreEqual(expected, this.controller.ChangeExerciseSomewhereInTheProgramWithAnother(weekDay, position, exerciseName));
        }

        [TestCase("MonDay", "3", PlaceholderName2)]
        [TestCase("MONDAY", "4", PlaceholderName3)]
        [TestCase("Sunday", "5", PlaceholderName3)]
        [TestCase("Sunday", "0", PlaceholderName2)]

        public void ShouldNotChangeExerciseSomewhereInTheProgramWithAnotherIfThePositionIsInvalid(string weekDay, string position, string exerciseName)
        {
            this.controller.CreateExercise(PlaceholderName2, SetsAsString, MinRepsAsString, MaxRepsAsString);
            this.controller.CreateExercise(PlaceholderName3, SetsAsString, MinRepsAsString, MaxRepsAsString);

            Assert.Throws<ArgumentException>(() => this.controller.ChangeExerciseSomewhereInTheProgramWithAnother(weekDay, position, exerciseName));
        }

        [TestCase("MonDay", "alo", PlaceholderName2)]
        [TestCase("MONDAY", "gosho", PlaceholderName3)]
        [TestCase("Sunday", "pesho", PlaceholderName3)]
        [TestCase("Sunday", "tosho", PlaceholderName2)]

        public void ShouldNotChangeExerciseSomewhereInTheProgramWithAnotherIfThePositionIsString(string weekDay, string position, string exerciseName)
        {
            this.controller.CreateExercise(PlaceholderName2, SetsAsString, MinRepsAsString, MaxRepsAsString);
            this.controller.CreateExercise(PlaceholderName3, SetsAsString, MinRepsAsString, MaxRepsAsString);

            Assert.Throws<InvalidOperationException>(() => this.controller.ChangeExerciseSomewhereInTheProgramWithAnother(weekDay, position, exerciseName));
        }
        [TestCase("monday", "1")]
        [TestCase("monday", "2")]

        public void RemoveExerciseFromPositionInTheProgramShouldWorkCorrectly(string weekDay, string position)
        {
            this.controller.CreateExercise(PlaceholderName2, SetsAsString, MinRepsAsString, MaxRepsAsString);
            this.controller.AddExerciseAtTheEndOfTheProgram("monday", PlaceholderName2);

            string expected = string.Format(OutputMessages.ExerciseRemovedFromTheProgram, WeekDaysParser.Parse(weekDay).ToString(), position);

            Assert.AreEqual(expected, this.controller.RemoveExerciseFromPositionInTheProgram(weekDay, position));
        }

        [TestCase("MonDay", "3")]
        [TestCase("MONDAY", "4")]
        [TestCase("Sunday", "5")]
        [TestCase("Sunday", "0")]
        [TestCase("Sunday", "-1")]
        public void ShouldNotRemoveExerciseFromPositionInTheProgramIfThePositionIsInvalid(string weekDay, string position)
        {
            this.controller.CreateExercise(PlaceholderName2, SetsAsString, MinRepsAsString, MaxRepsAsString);
            this.controller.AddExerciseAtTheEndOfTheProgram(weekDay, PlaceholderName2);

            Assert.Throws<ArgumentException>(() => this.controller.RemoveExerciseFromPositionInTheProgram(weekDay, position));
        }
    }
}
