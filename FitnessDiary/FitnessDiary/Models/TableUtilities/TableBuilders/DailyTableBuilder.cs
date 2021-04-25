using FitnessDiary.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessDiary.Models.TableUtilities
{
    public class DailyTableBuilder : TableBuilder
    {
        public DailyTableBuilder(Dictionary<WeekDays, List<IExercise>> exercises) : base(exercises)
        {

        }

        public override string BuildTable()
        {
            WeekDays today = (WeekDays)Enum.Parse(typeof(WeekDays), DateTime.Now.DayOfWeek.ToString());

            int longestExerciseName = GetLongestExerciseName();
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
            return Table.ReturnTheReadyTable();
        }

        protected override int GetLongestExerciseName()
        {
            int minLength = 20;

            WeekDays today = (WeekDays)Enum.Parse(typeof(WeekDays), DateTime.Now.DayOfWeek.ToString());
            return Math.Max(minLength, this.exercises[(WeekDays)today].OrderByDescending(x => x.Name.Length).First().Name.Length);
        }

    }
}
