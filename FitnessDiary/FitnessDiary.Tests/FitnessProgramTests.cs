using System;
using FitnessDiary.Models;
using NUnit.Framework;
using FitnessDiary.Utilities.Enums;

namespace FitnessDiary.Tests
{
    public class FitnessProgramTests
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
        public void ConstructorShouldSetCorrectly()
        {
            Assert.IsNotNull(fitnessProgram);
        }

        [Test]
        public void AddShouldAddCorrectly()
        {
            fitnessProgram.Add(WeekDays.Monday, exercise1);

            Assert.That(fitnessProgram.Exercises[WeekDays.Monday].Contains(exercise1));
        }

        [Test]
        public void InsertShouldInsertCorrectlyBetween()
        {
            fitnessProgram.Add(WeekDays.Monday, exercise1);
            fitnessProgram.Add(WeekDays.Monday, exercise3);
            fitnessProgram.Insert(WeekDays.Monday, 1, exercise2);

            Assert.AreEqual(fitnessProgram.Exercises[WeekDays.Monday][1], exercise1);
        }

        [Test]
        public void ChangeShouldChangeTheExercise()
        {
            fitnessProgram.Add(WeekDays.Monday, exercise1);
            fitnessProgram.Change(WeekDays.Monday, 1, exercise2);

            Assert.AreEqual(fitnessProgram.Exercises[WeekDays.Monday][0], exercise2);
        }

        [Test]
        public void RemoveShouldRemoveTheGivenExerciseNumber()
        {
            fitnessProgram.Add(WeekDays.Monday, exercise1);
            fitnessProgram.Remove(WeekDays.Monday, 1);

            Assert.That(fitnessProgram.Exercises[WeekDays.Monday].Contains(exercise1)==false);
        }

        [Test]
        public void RemoveShouldThrowExceptionIfThereAreNoExercsisesToRemove()
        {
            Assert.Throws<InvalidOperationException>(() => fitnessProgram.Remove(WeekDays.Monday, 1));
        }
    }
}
