using FitnessDiary.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDiary.Models.TableUtilities
{
    public class WeeklyTableBuilder : TableBuilder
    {
        public WeeklyTableBuilder(Dictionary<WeekDays, List<IExercise>> exercises) : base(exercises)
        {
        }

        public override string BuildTable()
        {
            int longestExerciseName = GetLongestExerciseName();
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

                exerciseMonFormating = SetExerciseFormating(isValidMon, WeekDays.Monday, i);
                exerciseTueFormating = SetExerciseFormating(isValidTue, WeekDays.Tuesday, i);
                exerciseWedFormating = SetExerciseFormating(isValidWed, WeekDays.Wednesday, i);
                exerciseThrFormating = SetExerciseFormating(isValidThr, WeekDays.Thursday, i);
                exerciseFriFormating = SetExerciseFormating(isValidFri, WeekDays.Friday, i);
                exerciseSatFormating = SetExerciseFormating(isValidSat, WeekDays.Saturday, i);
                exerciseSunFormating = SetExerciseFormating(isValidSun, WeekDays.Sunday, i);

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
            return Table.ReturnTheReadyTable();
        }

        protected override int GetLongestExerciseName()
        {
            int minLength = 20;
            int longest = 0;

            foreach ((WeekDays day, List<IExercise> ex) in this.exercises)
            {
                int current = exercises[day].OrderByDescending(x => x.Name.Length).First().Name.Length;

                if (current > longest)
                {
                    longest = current;
                }
            }

            return Math.Max(minLength, longest);
        }

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



    }
}
