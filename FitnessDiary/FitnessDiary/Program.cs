using FitnessDiary.Models;
using System;
using System.Collections.Generic;

namespace FitnessDiary
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Bench press";
            string name1 = "Bench pressss";
            int sets = 3;
            int sets1 = 20;
            int min = 6;
            int min1 = 20;
            int max = 8;
            int max1 = 20;
            double maxLifted = 160.25;
            Exercise ex = new Exercise(name, sets, min, max);
            Exercise ex1 = new Exercise(name1, sets1, min1, max1);

            FitnessProgram fb = new FitnessProgram();
            DayOfWeek dw = DateTime.Now.DayOfWeek;

            fb.Add(DayOfWeek.Monday, ex);
            fb.Add(DayOfWeek.Tuesday, ex);
            fb.Add(DayOfWeek.Wednesday, ex);
            fb.Add(DayOfWeek.Thursday, ex);
            fb.Add(DayOfWeek.Friday, ex);
            fb.Add(DayOfWeek.Saturday, ex);
            fb.Add(DayOfWeek.Sunday, ex);

            Console.WriteLine(dw);
            
            fb.ShowDaily();
            fb.ShowWeekly();
        }
    }
}
