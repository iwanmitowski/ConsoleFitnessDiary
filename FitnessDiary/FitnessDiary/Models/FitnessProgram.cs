using FitnessDiary.Models.Contracts;
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
            int numberToAdd = number - 1;
            CheckNumber(numberToAdd);
            CheckNumberIfItsBiggerThanTheListCapacity(day, number);

            if (this.exercises[day].Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoExercisesInTheProgram);
            }
            this.exercises[day].RemoveAt(numberToAdd);
        }

        public void ShowDaily()
        {
            WeekDays today = (WeekDays)Enum.Parse(typeof(WeekDays), DateTime.Now.DayOfWeek.ToString());

            int longestExerciseName = GetLongestExerciseName("daily");
            int rowCounter = 1;

            Table.SetWindowSize();
            //Console.Clear();
            Table.SetTableWidth(longestExerciseName * 2 + 7);
            Table.PrintLine();
            Table.PrintRow("Number", $"{today}");
            Table.PrintLine();

            foreach (var exercise in this.exercises[today])
            {
                Table.PrintRow($"{rowCounter++}", $"{exercise}");
                Table.PrintRow("", $"{exercise.Sets} Sets x {exercise.MinimumRepetitions}-{exercise.MaximumRepetitions} Reps");
                Table.PrintLine();
            }

            Table.ShowTheBeginningOfTheTable();

        }

        public void ShowWeekly()
        {
            int longestExerciseName = GetLongestExerciseName("weekly");
            int biggestExerciseCountAmongAllDays = GetBiggestExerciseCount();
            int rowCounter = 1;

            Table.SetWindowSize();
            //Console.Clear();
            Table.SetTableWidth(longestExerciseName * 8 + 9);
            Table.PrintLine();
            Table.PrintRow("Number", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday");
            Table.PrintLine();

            string exerciseMonToString = string.Empty;
            string exerciseTueToString = string.Empty;
            string exerciseWedToString = string.Empty;
            string exerciseThrToString = string.Empty;
            string exerciseFriToString = string.Empty;
            string exerciseSatToString = string.Empty;
            string exerciseSunToString = string.Empty;

            string exerciseMonFormating = string.Empty;
            string exerciseTueFormating = string.Empty;
            string exerciseWedFormating = string.Empty;
            string exerciseThrFormating = string.Empty;
            string exerciseFriFormating = string.Empty;
            string exerciseSatFormating = string.Empty;
            string exerciseSunFormating = string.Empty;

            for (int i = 0; i < biggestExerciseCountAmongAllDays; i++)
            {
                bool isValidMon = IsItValidDay(WeekDays.Monday, i);
                bool isValidTue = IsItValidDay(WeekDays.Tuesday, i);
                bool isValidWed = IsItValidDay(WeekDays.Wednesday, i);
                bool isValidThr = IsItValidDay(WeekDays.Thursday, i);
                bool isValidFri = IsItValidDay(WeekDays.Friday, i);
                bool isValidSat = IsItValidDay(WeekDays.Saturday, i);
                bool isValidSun = IsItValidDay(WeekDays.Sunday, i);

                exerciseMonToString = SetExerciseToString(isValidMon, WeekDays.Monday, i);
                exerciseTueToString = SetExerciseToString(isValidTue, WeekDays.Tuesday, i);
                exerciseWedToString = SetExerciseToString(isValidWed, WeekDays.Wednesday, i);
                exerciseThrToString = SetExerciseToString(isValidThr, WeekDays.Thursday, i);
                exerciseFriToString = SetExerciseToString(isValidFri, WeekDays.Friday, i);
                exerciseSatToString = SetExerciseToString(isValidSat, WeekDays.Saturday, i);
                exerciseSunToString = SetExerciseToString(isValidSun, WeekDays.Sunday, i);

                exerciseMonFormating = SetExerciseFormating(isValidMon,WeekDays.Monday,i);
                exerciseTueFormating = SetExerciseFormating(isValidTue,WeekDays.Tuesday,i);
                exerciseWedFormating = SetExerciseFormating(isValidWed,WeekDays.Wednesday,i);
                exerciseThrFormating = SetExerciseFormating(isValidThr,WeekDays.Thursday,i);
                exerciseFriFormating = SetExerciseFormating(isValidFri,WeekDays.Friday,i);
                exerciseSatFormating = SetExerciseFormating(isValidSat,WeekDays.Saturday, i);
                exerciseSunFormating = SetExerciseFormating(isValidSun, WeekDays.Sunday,i);

                Table.PrintRow($"{rowCounter++}",
                    exerciseMonToString,
                    exerciseTueToString,
                    exerciseWedToString,
                    exerciseThrToString,
                    exerciseFriToString,
                    exerciseSatToString,
                    exerciseSunToString
                    );

                Table.PrintRow("",
                    exerciseMonFormating,
                    exerciseTueFormating,
                    exerciseWedFormating,
                    exerciseThrFormating,
                    exerciseFriFormating,
                    exerciseSatFormating,
                    exerciseSunFormating
                    );

                Table.PrintLine();

            }

            Table.ShowTheBeginningOfTheTable();

        }
               
        //Table helper methods

        private bool IsItValidDay(WeekDays day, int i)
        {
            return this.exercises[day].Count() >= i + 1;
        }

        private string SetExerciseFormating(bool isValidDay, WeekDays day, int i)
        {
            if (isValidDay)
            {
                IExercise exerciseDay = this.exercises[day][i];

                return $"{$"{exerciseDay.Sets} Sets x {exerciseDay.MinimumRepetitions}-{exerciseDay.MaximumRepetitions} Reps"}";
            }

            return string.Empty;
        }
        private string SetExerciseToString(bool isValidDay, WeekDays day, int i)
        {
            if (isValidDay)
            {
                IExercise exerciseDay = this.exercises[day][i];

                return $"{exerciseDay}";
            }

            return string.Empty;
        }

        private int GetBiggestExerciseCount()
        {
            int biggest = 0;

            foreach (var day in this.exercises)
            {
                int current = day.Value.Count();

                if (current > biggest)
                {
                    biggest = current;
                }
            }

            return biggest;
        }

        private int GetLongestExerciseName(string condition)
        {
            int minLength = 20;
            switch (condition)
            {
                case "daily":

                    WeekDays today = (WeekDays)Enum.Parse(typeof(WeekDays), DateTime.Now.DayOfWeek.ToString());
                    return Math.Max(minLength, this.exercises[(WeekDays)today].OrderByDescending(x => x.Name.Length).First().Name.Length);

                case "weekly":

                    int longest = 0;

                    foreach ((WeekDays day, List<IExercise> ex) in this.exercises)
                    {
                        int current = this.exercises[day].OrderByDescending(x => x.Name.Length).First().Name.Length;

                        if (current > longest)
                        {
                            longest = current;
                        }
                    }

                    return Math.Max(minLength, longest);
            }

            return 0;
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
