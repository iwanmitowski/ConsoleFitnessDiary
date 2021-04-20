using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessDiary.Core;
using FitnessDiary.Core.Factory;
using FitnessDiary.Models;
using FitnessDiary.Models.Contracts;
using FitnessDiary.Utilities.Messages;
using NUnit.Framework;
namespace FitnessDiary.Tests
{
    public class ControllerTests
    {
        private const string PlaceholderName1 = "Bench Press";
        private const string PlaceholderName2 = "Biceps Curl";
        private const int Sets = 3;
        private const int MinReps = 4;
        private const int MaxReps = 5;

        Controller controller;
        ExerciseFactory exerciseFactory;
        ExerciseHistory exerciseHistory;
        Exercise exercise1;
        Exercise exercise2;

        [SetUp]
        public void SetUp()
        {
            this.exerciseFactory = new ExerciseFactory();
            this.exerciseHistory = new ExerciseHistory();
            exercise1 = new Exercise(PlaceholderName1,Sets,MinReps,MaxReps);
            exercise2 = new Exercise(PlaceholderName2,Sets,MinReps,MaxReps);
            controller = new Controller(exerciseFactory,exerciseHistory);
        }

        [Test]
        public void CreateExerciseCreatesCorectly()
        {
            string expected = string.Format(OutputMessages.ExerciseCreated,PlaceholderName1,Sets,MinReps,MaxReps);
            Assert.AreEqual(expected, this.controller.CreateExercise(PlaceholderName1, Sets, MinReps, MaxReps));
        }

        [Test]
        public void CreateExerciseThrowsInvalidOperationExceptionIfExerciseExistsInTheHistory()
        {
            this.exerciseHistory.Add(exercise1);

            Assert.Throws<InvalidOperationException>(() => this.controller.CreateExercise(PlaceholderName1, Sets, MinReps, MaxReps));

        }

        [TestCase(PlaceholderName1,10)]
        [TestCase(PlaceholderName2,20)]
        public void SetMaxLiftedWeightToExerciseShouldWorkCorrectly(string name, double lifted)
        {
            this.exerciseHistory.Add(exercise1);
            this.exerciseHistory.Add(exercise2);
            string expected = string.Format(OutputMessages.LiftedWeightSet ,name, lifted);

            Assert.AreEqual(expected, this.controller.SetMaxLiftedWeightToExercise(name, lifted));
        }

        [TestCase("Bicarka",10)]
        [TestCase("Triceps",20)]
        public void SetMaxLiftedWeightToExerciseThrowsExceptionIfExerciseIsMissing(string name, double lifted)
        {
            Assert.Throws<InvalidOperationException>(() => this.controller.SetMaxLiftedWeightToExercise(name, lifted));

        }
    }
}
