using FitnessDiary.Core.Factory.Contracts;
using FitnessDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDiary.Core.Factory
{
    public class ExerciseFactory : IExerciseFactory
    {
        public IExercise CreateExercise(string name, int sets, int minimumRepetitions, int maximumRepetitions)
        {
            var exercise = new Exercise(name, sets, minimumRepetitions, maximumRepetitions);

            return exercise;
        }
    }
}
