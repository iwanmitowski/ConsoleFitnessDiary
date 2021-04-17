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
    public class FitnessProgram : IFitnessProgram
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

        //In Controller the number should be reduced by 1
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
            if (this.exercises[day].Count==0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoExercisesInTheProgram);
            }
            this.exercises[day].RemoveAt(number);
        }

        public void ShowDaily()
        {
            DayOfWeek today = DateTime.Now.DayOfWeek;

            int longestExerciseName = this.exercises[today].OrderByDescending(x => x.Name.Length).First().Name.Length + 9;

            Console.WriteLine($"{today}'s workout:");

            // printProgramLogic but setting the row/col

            for (int i = 0; i < this.exercises[today].Count; i++)
            {
                Console.WriteLine(new string('*', longestExerciseName));
                var exercise = this.exercises[today][i];
                Console.WriteLine($"{i + 1}. {exercise}");
                if (i == this.exercises[today].Count - 1)
                {
                    Console.WriteLine(new string('*', longestExerciseName));
                }
            }

        }

        public void ShowWeekly()
        {
            PrintProgram(FillMatrix());
        }

        private void PrintProgram(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");

                }
                Console.WriteLine();
            }
        }

        private string[,] FillMatrix()
        {
            int longestExerciseCount = exercises.OrderByDescending(x => x.Value.Count).First().Value.Count + 1;

            string[,] matrix = new string[longestExerciseCount, 8];

            matrix[0, 0] = "Numbers";
            matrix[0, 1] = "Monday" + new string(' ', this.exercises[DayOfWeek.Monday].OrderByDescending(x => x.Name.Length).First().Name.Length);
            matrix[0, 2] = "Tuesday" + new string(' ', this.exercises[DayOfWeek.Tuesday].OrderByDescending(x => x.Name.Length).First().Name.Length);
            matrix[0, 3] = "Wednesday" + new string(' ', this.exercises[DayOfWeek.Wednesday].OrderByDescending(x => x.Name.Length).First().Name.Length);
            matrix[0, 4] = "Thursday" + new string(' ', this.exercises[DayOfWeek.Thursday].OrderByDescending(x => x.Name.Length).First().Name.Length);
            matrix[0, 5] = "Friday" + new string(' ', this.exercises[DayOfWeek.Friday].OrderByDescending(x => x.Name.Length).First().Name.Length);
            matrix[0, 6] = "Saturday" + new string(' ', this.exercises[DayOfWeek.Saturday].OrderByDescending(x => x.Name.Length).First().Name.Length);
            matrix[0, 7] = "Sunday" + new string(' ', this.exercises[DayOfWeek.Sunday].OrderByDescending(x => x.Name.Length).First().Name.Length);

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (col == 0)
                    {
                        matrix[row, col] = $"{row}" + new string(' ', 7 - row.ToString().Length);
                        continue;
                    }

                    //To get the proper day starting from 0
                    DayOfWeek day = (DayOfWeek)col - 1;

                    int longestExerciseName = this.exercises[day].OrderByDescending(x => x.Name.Length).First().Name.Length + 9;
                    // col num is more tahn exercises
                    if (col >= exercises[day].Count)
                    {
                        matrix[row, col] = "=/=" + new string(' ', longestExerciseName - 3);
                    }
                    else
                    {
                        matrix[row, col] = $"{exercises[day][col]}" + new string(' ', longestExerciseName - exercises[day][col].Name.Length);
                    }
                }
                Console.WriteLine();
            }

            return matrix;
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
