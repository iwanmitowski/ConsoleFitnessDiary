using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessDiary.Models;
using NUnit.Framework;

namespace FitnessDiary.Tests
{
    class FitnessProgramTests
    {
        Exercise exercise1;
        Exercise exercise2;
        Exercise exercise3;
        FitnessProgram fitnessProgram;

        [SetUp]
        public void SetUp()
        {
            exercise1 = new Exercise("Bench press", 3, 4, 5);
            exercise2 = new Exercise("Lat pulldown", 3, 4, 5);
            exercise3 = new Exercise("Biceps curl", 3, 4, 5);
            fitnessProgram = new FitnessProgram();
        }

        [Test]
        public void ConstructorShouldSetCorectly()
        {
            Assert.IsNotNull(fitnessProgram);
        }

        [Test]
        public void AddShouldAddCorectly()
        {
            fitnessProgram.Add(DayOfWeek.Monday, exercise1);

            Assert.That(fitnessProgram.Exercises[DayOfWeek.Monday].Contains(exercise1));
        }

        [Test]
        public void InsertShouldInsertCorectlyBetween()
        {
            fitnessProgram.Add(DayOfWeek.Monday, exercise1);
            fitnessProgram.Add(DayOfWeek.Monday, exercise3);
            fitnessProgram.Insert(DayOfWeek.Monday, 1, exercise2);

            Assert.AreEqual(fitnessProgram.Exercises[DayOfWeek.Monday][1], exercise2);
        }

        [Test]
        public void UpdatingShouldChangeTheExercise()
        {
            fitnessProgram.Add(DayOfWeek.Monday, exercise1);
            fitnessProgram.Update(DayOfWeek.Monday, 0, exercise2);

            Assert.AreEqual(fitnessProgram.Exercises[DayOfWeek.Monday][0], exercise2);
        }

        [Test]
        public void RemoveShouldRemoveTheGivenExerciseNumber()
        {
            fitnessProgram.Add(DayOfWeek.Monday, exercise1);
            fitnessProgram.Remove(DayOfWeek.Monday, 0);

            Assert.That(fitnessProgram.Exercises[DayOfWeek.Monday].Contains(exercise1)==false);
        }

        [Test]
        public void RemoveShouldThrowExceptionIfThereAreNoExercsisesToRemove()
        {
            Assert.Throws<InvalidOperationException>(() => fitnessProgram.Remove(DayOfWeek.Monday,1));
        }

    }
}
