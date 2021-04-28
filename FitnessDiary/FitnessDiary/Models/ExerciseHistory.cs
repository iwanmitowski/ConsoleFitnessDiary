using FitnessDiary.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessDiary.Models
{
    public class ExerciseHistory : IExerciseHistory
    {
        private readonly List<IExercise> exercises;
        
        public ExerciseHistory()
        {
            this.exercises = new List<IExercise>();
        }
        public void Add(IExercise exercise)
        {
            this.exercises.Add(exercise);
            
        }
        public IReadOnlyCollection<IExercise> GetAll()
        {
            return this.exercises.AsReadOnly();
        }
        public IExercise GetByName(string name)
        {
            var exercise = this.exercises.FirstOrDefault(e => e.Name == name);

            return exercise;
        }
        
    }
}
