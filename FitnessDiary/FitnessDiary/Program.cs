using FitnessDiary.Models;
using System;
using System.Collections.Generic;

namespace FitnessDiary
{
    class Program
    {
        static void Main(string[] args)
        {
            //Playground
            List<Exercise> exercises = new List<Exercise>();

            string name = "Bench press";
            int series = 3;
            int min = 6;
            int max = 8;
            double maxLifted = 160.25;

            var ex = new Exercise(name,series,min,max);

            ex.SetMaxLiftedWeight(maxLifted);

            Console.WriteLine(ex);
        }
    }
}
