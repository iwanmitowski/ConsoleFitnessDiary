using FitnessDiary.Models.Contracts;
using FitnessDiary.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDiary.Models
{
    class FitnessProgram : IFitnessProgram
    {
        private readonly Dictionary<DayOfWeek, List<IExercise>> exercises;

        public FitnessProgram()
        {
            this.exercises = new Dictionary<DayOfWeek, List<IExercise>>();
            CreateListForEachWeekDay();
        }


        public IReadOnlyDictionary<DayOfWeek, List<IExercise>> Exercises => exercises;

        public void Add(DayOfWeek day, IExercise exercise)
        {
            this.exercises[day].Add(exercise);
        }

        public void Insert(DayOfWeek day, int number, IExercise exercise)
        {
            CheckNumber(number);

            this.exercises[day].Insert(number, exercise);

        }

        public void Update(DayOfWeek day, int number, IExercise exercise)
        {
            CheckNumber(number);
            this.exercises[day][number] = exercise;
        }

        public void Remove(DayOfWeek day, int number)
        {
            CheckNumber(number);
            this.exercises[day].RemoveAt(number);
        }

        public void ShowDaily()
        {
            DayOfWeek today = DateTime.Now.DayOfWeek;

            for (int i = 0; i < this.exercises[today].Count; i++)
            {
                var exercise = this.exercises[today][i];
                Console.WriteLine($"{i+1}. {exercise}");
            }
            
        }

        public void ShowWeekly()
        {
            //TO-DO
            throw new NotImplementedException();
        }

        private void CreateListForEachWeekDay()
        {
            exercises.Add(DayOfWeek.Monday, new List<IExercise>());
            exercises.Add(DayOfWeek.Tuesday, new List<IExercise>());
            exercises.Add(DayOfWeek.Wednesday, new List<IExercise>());
            exercises.Add(DayOfWeek.Thursday, new List<IExercise>());
            exercises.Add(DayOfWeek.Friday, new List<IExercise>());
            exercises.Add(DayOfWeek.Saturday, new List<IExercise>());
            exercises.Add(DayOfWeek.Sunday, new List<IExercise>());
        }

        private void CheckNumber(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException(ExceptionMessages.InvalidNumber);
            }
        }


    }
}
