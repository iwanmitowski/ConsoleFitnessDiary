using FitnessDiary.Models;
using FitnessDiary.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace FitnessDiary
{
    class Program
    {
        //Removing the maximizing and resizing options (so the user cant break the table view)
        private const int MF_BYCOMMAND = 0x00000000;
        public const int SC_CLOSE = 0xF060;
        public const int SC_MINIMIZE = 0xF020;
        public const int SC_MAXIMIZE = 0xF030;
        public const int SC_SIZE = 0xF000;

        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);


        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        static void Main(string[] args)
        {

            IntPtr handle = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(handle, false);

            if (handle != IntPtr.Zero)
            {
                DeleteMenu(sysMenu, SC_MAXIMIZE, MF_BYCOMMAND);
                DeleteMenu(sysMenu, SC_SIZE, MF_BYCOMMAND);
            }


            ////////////////////////////////////////////////

            //Console.WriteLine(DayOfWeek.Monday+5);
            
            try
            {
                string name = "Single-leg deadliftsss";
                string name1 = "Bench presssssssssssssss";
                int maxExerciseNameLength = 24;
                string name2 = "bicarki";
                int sets = 20;
                int sets1 = 20;
                int min = 20;
                int min1 = 20;
                int max = 20;
                int max1 = 20;
                double maxLifted = 160.25;
                Exercise ex = new Exercise(name, sets, min, max);
                Exercise ex1 = new Exercise(name1, sets1, min1, max1);
                Exercise ex2 = new Exercise(name2, sets1, min1, max1);

                FitnessProgram fb = new FitnessProgram();
                DayOfWeek dw = DateTime.Now.DayOfWeek;
               
                fb.Add(WeekDays.Monday, ex);
                fb.Add(WeekDays.Tuesday, ex);
                fb.Add(WeekDays.Wednesday, ex);
                fb.Add(WeekDays.Thursday, ex);
                fb.Add(WeekDays.Friday, ex);
                fb.Add(WeekDays.Saturday, ex);
                fb.Add(WeekDays.Sunday, ex);

                fb.Add(WeekDays.Monday, ex1);
                fb.Add(WeekDays.Tuesday, ex1);
                fb.Add(WeekDays.Wednesday, ex1);
                fb.Add(WeekDays.Wednesday, ex1);
                fb.Insert(WeekDays.Wednesday, 1, ex2);
                fb.Add(WeekDays.Wednesday, ex1);
                fb.Add(WeekDays.Thursday, ex1);
                fb.Add(WeekDays.Friday, ex1);
                fb.Add(WeekDays.Saturday, ex1);
                fb.Add(WeekDays.Sunday, ex1);
                fb.Add(WeekDays.Sunday, ex1);
                fb.Add(WeekDays.Sunday, ex1);
                fb.Add(WeekDays.Sunday, ex2);
                fb.Add(WeekDays.Sunday, ex2);
                fb.Add(WeekDays.Sunday, ex1);
                fb.Add(WeekDays.Sunday, ex1);
                fb.Add(WeekDays.Sunday, ex1);
                fb.Add(WeekDays.Sunday, ex1);
                fb.Add(WeekDays.Sunday, ex1);
                fb.Add(WeekDays.Sunday, ex1);


                fb.ShowWeekly();
                //fb.ShowDaily();
                Table.ShowTheBeginningOfTheTable();
                Console.ReadLine();

            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                
            }
            

           
            
            //fb.Add(DayOfWeek.Sunday, ex);
            //fb.Add(DayOfWeek.Sunday, ex);
            //fb.Add(DayOfWeek.Sunday, ex);
            //fb.Add(DayOfWeek.Sunday, ex);
            //fb.Add(DayOfWeek.Sunday, ex);
            //fb.Add(DayOfWeek.Sunday, ex1);


            
            
            
            //int counter = 1;
            //Console.Clear();
            //Table.PrintLine();
            //Table.PrintRow("Number", "Monday", " Tuesday ", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday");
            //Table.PrintLine();
            //Table.PrintRow($"{counter++}", $"{ex}", $"{ex}", $"{ex}", $"{ex}", $"{ex}", $"{ex}", $"{ex}");
            //Table.PrintRow("", $"{ex.Sets} Sets x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps");
            //Table.PrintLine();
            //Table.PrintRow($"{counter++}", $"{ex}", $"{ex}", $"{ex}", $"{ex}", $"{ex}", $"{ex}", $"{ex}");
            //Table.PrintRow("", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps");
            //Table.PrintLine();
            //Table.PrintRow($"{counter++}", $"{ex}", $"{ex}", $"{ex}", $"{ex}", $"{ex}", $"{ex}", $"{ex}");
            //Table.PrintRow("", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps");
            //Table.PrintLine();
            //Table.PrintRow($"{counter++}", $"{ex}", $"{ex}", $"{ex}", $"{ex}", $"{ex}", $"{ex}", $"{ex}");
            //Table.PrintRow("", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps");
            //Table.PrintLine();
            //Table.PrintRow($"{counter++}", $"{ex}", $"{ex}", $"{ex}", $"{ex}", $"{ex}", $"{ex}", $"{ex}");
            //Table.PrintRow("", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps");
            //Table.PrintLine();
            //Table.PrintRow($"{counter++}", $"{ex}", $"{ex}", $"{ex}", $"{ex}", $"{ex}", $"{ex}", $"{ex}");
            //Table.PrintRow("", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps");
            //Table.PrintLine();
            //Table.PrintRow($"{counter++}", $"{ex}", $"{ex}", $"{ex}", $"{ex}", $"{ex}", $"{ex}", $"{ex}");
            //Table.PrintRow("", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps");
            //Table.PrintLine();
            //Table.PrintRow($"{counter++}", $"{ex}", $"{ex}", $"{ex}", $"{ex}", $"{ex}", $"{ex}", $"{ex}");
            //Table.PrintRow("", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps");
            //Table.PrintLine();
            //Table.PrintRow($"{counter++}", $"{ex}", $"{ex}", $"{ex}", $"{ex}", $"{ex}", $"{ex}", $"{ex}");
            //Table.PrintRow("", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps");
            //Table.PrintLine();
            //Table.PrintRow($"{counter++}", $"{ex}", $"{ex}", $"{ex}", $"{ex}", $"{ex}", $"{ex}", $"{ex}");
            //Table.PrintRow("", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps");
            //Table.PrintLine();
            //Table.PrintRow($"{counter++}", $"{ex}", $"{ex}", $"{ex}", $"{ex}", $"{ex}", $"{ex}", $"{ex}");
            //Table.PrintRow("", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps", $"{ex.Sets} x {ex.MinimumRepetitions}-{ex.MaximumRepetitions} Reps");
            //Table.PrintLine();
            //Table.ShowTheBeginningOfTheTable();
            //Console.ReadLine();
        }

    }
}
