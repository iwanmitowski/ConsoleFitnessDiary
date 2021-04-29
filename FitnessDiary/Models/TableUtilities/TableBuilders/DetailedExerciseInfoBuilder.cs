using FitnessDiary.Utilities.Enums;
using FitnessDiary.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDiary.Models.TableUtilities.TableBuilders
{
    public class DetailedExerciseInfoBuilder
    {
        List<IExercise> exercises;
        public DetailedExerciseInfoBuilder(List<IExercise> exercises)
        {
            this.exercises = exercises;
        }
        public bool IsEmpty => this.exercises.Count == 0;

        public string BuildTable()
        {
            if (IsEmpty)
            {
                return OutputMessages.CreateExercises;
            }

            int longestExerciseName = GetLongestExerciseName();

            Table.SetTableWidth(longestExerciseName * 8 + 9);
            Table.SetWindowSize();
            Table.ClearTableBuilder();
            Table.PrintTop();
            Table.PrintRow("Exercise Name", "Sets", "Min Reps", "Max Reps", "Max Lifted");

            foreach (var ex in this.exercises)
            {
                Table.PrintRow(
                    ex.Name,
                    $"{ex.Sets}",
                    $"{ex.MinimumRepetitions}",
                    $"{ex.MaximumRepetitions}",
                    $"{ex.MaxLiftedWeight}");
            }

            Table.PrintBot();
            Table.ShowTheBeginningOfTheTable();
            return Table.ReturnTheReadyTable();
        }
        private int GetLongestExerciseName()
        {
            int minLength = 20;
            int longest = 0;

            foreach (var ex in this.exercises)
            {
                int current = ex.Name.Length;

                if (current > longest)
                {
                    longest = current;
                }
            }

            return Math.Max(minLength, longest);
        }
    }
}
