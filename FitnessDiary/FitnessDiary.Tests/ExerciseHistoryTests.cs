using System.Linq;
using FitnessDiary.Models;
using NUnit.Framework;

namespace FitnessDiary.Tests
{
    public class ExerciseHistoryTests
    {
        private const string PlaceholderName1 = "Bench Press";
        private const string PlaceholderName2 = "Biceps Curl";
        private const int Sets = 3;
        private const int MinReps = 4;
        private const int MaxReps = 5;

        Exercise exercise1;
        Exercise exercise2;
        ExerciseHistory exerciseHistory;

        [SetUp]
        public void SetUp()
        {
            exercise1 = new Exercise(PlaceholderName1, Sets, MinReps, MaxReps);
            exercise2 = new Exercise(PlaceholderName2, Sets, MinReps, MaxReps);
            this.exerciseHistory = new ExerciseHistory();


        }

        [Test]
        public void ConstructorShouldSetCorrectly()
        {
            Assert.IsNotNull(exerciseHistory);
        }
        [Test]
        public void AddShouldAddCorrectly()
        {
            this.exerciseHistory.Add(exercise1);
            int expectedExCount = 1;

            Assert.AreEqual(1, this.exerciseHistory.GetAll().Count());
        }

        [TestCase(PlaceholderName1)]
        [TestCase(PlaceholderName2)]
        public void GetByNameShouldReturnCorrectExercise(string name)
        {
            this.exerciseHistory.Add(exercise1);
            this.exerciseHistory.Add(exercise2);
            string expected = name;

            Assert.AreEqual(expected, this.exerciseHistory.GetByName(name).Name);
        }
    }
}
