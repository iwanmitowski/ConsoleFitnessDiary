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
        public void Setup()
        {
            name = "Bench press";
            sets = 3;
            min = 6;
            max = 8;
            maxLifted = 160.25;

            exercise = new Exercise(name, sets, min, max);
        }

        [Test]
        public void ConstructorShouldSetCorectly()
        {
            Assert.IsNotNull(exercise);
        }

        [Test]
        public void AddingMaxLiftedWeightShouldSetCorectly()
        {
            double expected = 160.25;
            exercise.SetMaxLiftedWeight(maxLifted);

            Assert.AreEqual(expected, exercise.MaxLiftedWeight);
        }
    }
}
