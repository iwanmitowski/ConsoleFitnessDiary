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

        //In Controller the number should be reduced by 1
        public void Insert(WeekDays day, int number, IExercise exercise)
        {
            CheckNumber(number);

            this.exercises[day].Insert(number, exercise);

        }

        public void Update(WeekDays day, int number, IExercise exercise)
        {
            CheckNumber(number);
            this.exercises[day][number] = exercise;
        }

        public void Remove(WeekDays day, int number)
        {
            CheckNumber(number);
            if (this.exercises[day].Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoExercisesInTheProgram);
            }
            this.exercises[day].RemoveAt(number);
        }

        public void ShowDaily()
        {
            WeekDays today = (WeekDays)Enum.Parse(typeof(WeekDays),DateTime.Now.DayOfWeek.ToString());

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


            for (int i = 0; i < biggestExerciseCountAmongAllDays; i++)
            {
                int colCounter = 0;
                WeekDays monday = WeekDays.Monday;

                bool isValidMon = this.exercises[monday + colCounter++].Count() >= i + 1 ;
                bool isValidTue = this.exercises[monday + colCounter++].Count() >=i + 1;
                bool isValidWed = this.exercises[monday + colCounter++].Count() >=i + 1;
                bool isValidThr = this.exercises[monday + colCounter++].Count() >=i + 1;
                bool isValidFri = this.exercises[monday + colCounter++].Count() >=i + 1;
                bool isValidSat = this.exercises[monday + colCounter++].Count() >=i + 1;
                bool isValidSun = this.exercises[monday + colCounter++].Count() >=i + 1;
                               
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

                if (isValidMon)
                {
                    IExercise exerciseMon = this.exercises[monday][i];
                    exerciseMonToString = $"{exerciseMon}";
                    exerciseMonFormating = $"{$"{exerciseMon.Sets} Sets x {exerciseMon.MinimumRepetitions}-{exerciseMon.MaximumRepetitions} Reps"}";
                }
                if (isValidTue)
                {
                    IExercise exerciseTue = this.exercises[WeekDays.Tuesday][i];
                    exerciseTueToString = $"{exerciseTue}";
                    exerciseTueFormating = $"{$"{exerciseTue.Sets} Sets x {exerciseTue.MinimumRepetitions}-{exerciseTue.MaximumRepetitions} Reps"}";
                }
                if (isValidWed)
                {
                    IExercise exerciseWed = this.exercises[WeekDays.Wednesday][i];
                    exerciseWedToString = $"{exerciseWed}";
                    exerciseWedFormating = $"{$"{exerciseWed.Sets} Sets x {exerciseWed.MinimumRepetitions}-{exerciseWed.MaximumRepetitions} Reps"}";
                }
                if (isValidThr)
                {
                    IExercise exerciseThr = this.exercises[WeekDays.Thursday][i];
                    exerciseThrToString = $"{exerciseThr}";
                    exerciseThrFormating = $"{$"{exerciseThr.Sets} Sets x {exerciseThr.MinimumRepetitions}-{exerciseThr.MaximumRepetitions} Reps"}";
                }
                if (isValidFri)
                {
                    IExercise exerciseFri = this.exercises[WeekDays.Friday][i];
                    exerciseFriToString = $"{exerciseFri}";
                    exerciseFriFormating = $"{$"{exerciseFri.Sets} Sets x {exerciseFri.MinimumRepetitions}-{exerciseFri.MaximumRepetitions} Reps"}";
                }
                if (isValidSat)
                {
                    IExercise exerciseSat = this.exercises[WeekDays.Saturday][i];
                    exerciseSatToString = $"{exerciseSat}";
                    exerciseSatFormating = $"{$"{exerciseSat.Sets} Sets x {exerciseSat.MinimumRepetitions}-{exerciseSat.MaximumRepetitions} Reps"}";
                }
                if (isValidSun)
                {
                    IExercise exerciseSun = this.exercises[WeekDays.Sunday][i];
                    exerciseSunToString = $"{exerciseSun}";
                    exerciseSunFormating = $"{$"{exerciseSun.Sets} Sets x {exerciseSun.MinimumRepetitions}-{exerciseSun.MaximumRepetitions} Reps"}";
                }

                Table.PrintRow($"{rowCounter++}",
                    $"{exerciseMonToString}",
                    $"{exerciseTueToString}",
                    $"{exerciseWedToString}",
                    $"{exerciseThrToString}",
                    $"{exerciseFriToString}",
                    $"{exerciseSatToString}",
                    $"{exerciseSunToString}");

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
                    return Math.Max(minLength,this.exercises[(WeekDays)today].OrderByDescending(x => x.Name.Length).First().Name.Length);

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

                    return Math.Max(minLength,longest);
            }

            return 0;
        }
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


    }
}
