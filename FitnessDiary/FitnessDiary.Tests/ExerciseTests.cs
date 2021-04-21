using FitnessDiary.Models;
using NUnit.Framework;
using System;

namespace FitnessDiary.Tests
{
    public class ExerciseTests
    {
        Exercise exercise;
        string name;
        int sets;
        int min;
        int max;
        double maxLifted;

        [SetUp]
        public void SetUp()
        {
            name = "Bench press";
            sets = 3;
            min = 6;
            max = 8;
            maxLifted = 160.25;

            exercise = new Exercise(name, sets, min, max);
        }

        [Test]
        public void ConstructorShouldSetCorrectly()
        {
            Assert.IsNotNull(exercise);
        }

        [Test]
        public void AddingMaxLiftedWeightShouldSetCorrectly()
        {
            double expected = 160.25;
            exercise.SetMaxLiftedWeight(maxLifted);

            Assert.AreEqual(expected, exercise.MaxLiftedWeight);
        }

        [TestCase(4)]
        [TestCase(5)]
        public void UpdatingSetsShouldUpdateCorrectly(int reps)
        {
            int expected = reps;
            this.exercise.UpdateSets(reps);

            Assert.AreEqual(expected, this.exercise.Sets);
        }

        [TestCase(4,5)]
        [TestCase(5,6)]
        public void UpdatingRepsShouldUpdateThemCorrectly(int min, int max)
        {
            int expectedMin = min;
            int expectedMax = max;
            this.exercise.UpdateReps(min, max);
            Assert.AreEqual(expectedMin, this.exercise.MinimumRepetitions);
            Assert.AreEqual(expectedMax, this.exercise.MaximumRepetitions);
        }

    }
}
