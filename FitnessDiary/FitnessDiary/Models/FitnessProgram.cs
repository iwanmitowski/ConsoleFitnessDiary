using FitnessDiary.Models.Contracts;
using FitnessDiary.Models.TableUtilities;
using FitnessDiary.Utilities.Enums;
using FitnessDiary.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessDiary.Models
{
    public class FitnessProgram : IFitnessProgram
    {

        private readonly Dictionary<WeekDays, List<IExercise>> exercises;
        public FitnessProgram()
        {
            this.exercises = new Dictionary<WeekDays, List<IExercise>>();
            CreateListForEachWeekDay();
        }

        public IReadOnlyDictionary<WeekDays, List<IExercise>> Exercises => exercises;

        public void Add(WeekDays day, IExercise exercise)
        {
            this.exercises[day].Add(exercise);
        }

        public void Insert(WeekDays day, int number, IExercise exercise)
        {
            int numberToAdd = number - 1;
            CheckNumber(numberToAdd);
            CheckNumberIfItsBiggerThanTheListCapacity(day, number);

            this.exercises[day].Insert(numberToAdd, exercise);
        }


        public void Change(WeekDays day, int number, IExercise exercise)
        {
            int numberToAdd = number - 1;
            CheckNumber(numberToAdd);
            CheckNumberIfItsBiggerThanTheListCapacity(day, number);

            this.exercises[day][numberToAdd] = exercise;
        }

        public void Remove(WeekDays day, int number)
        {
            if (this.exercises[day].Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoExercisesInTheProgram);
            }

            int numberToAdd = number - 1;
            CheckNumber(numberToAdd);
            CheckNumberIfItsBiggerThanTheListCapacity(day, number);

            
            this.exercises[day].RemoveAt(numberToAdd);
        }


        //Preparation methods

        private void CreateListForEachWeekDay()
        {
            exercises.Add(WeekDays.Monday, new List<IExercise>());
            exercises.Add(WeekDays.Tuesday, new List<IExercise>());
            exercises.Add(WeekDays.Wednesday, new List<IExercise>());
            exercises.Add(WeekDays.Thursday, new List<IExercise>());
            exercises.Add(WeekDays.Friday, new List<IExercise>());
            exercises.Add(WeekDays.Saturday, new List<IExercise>());
            exercises.Add(WeekDays.Sunday, new List<IExercise>());
        }

        private void CheckNumber(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException(ExceptionMessages.InvalidNumber);
            }
        }

        private void CheckNumberIfItsBiggerThanTheListCapacity(WeekDays day, int numberToAdd)
        {
            int currentDayEx = this.exercises[day].Count;

            if (numberToAdd>currentDayEx)
            {
                throw new ArgumentException(ExceptionMessages.InvalidNumberUpperBorder);
            }

            
        }

    }
}
