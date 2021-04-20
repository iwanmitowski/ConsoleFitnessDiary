using FitnessDiary.Core.Contracts;
using FitnessDiary.Core.Factory;
using FitnessDiary.Core.Factory.Contracts;
using FitnessDiary.Models.Contracts;
using FitnessDiary.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDiary.Core
{
    public class Controller : IController
    {
        private readonly IExerciseFactory exerciseFactory;
        private readonly IExerciseHistory exerciseHistory;
        public Controller(IExerciseFactory exerciseFactory, IExerciseHistory exerciseHistory)
        {
            this.exerciseFactory = exerciseFactory;
            this.exerciseHistory = exerciseHistory;

        }
        public string CreateExercise(string name, int sets, int minimumRepetitions, int maximumRepetitions)
        {
            if (this.exerciseHistory.GetAll().Any(x => x.Name == name))
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.ExerciseExists, name));
            }

            var exercise = this.exerciseFactory.CreateExercise(name, sets, minimumRepetitions, maximumRepetitions);
            this.exerciseHistory.Add(exercise);

            return string.Format(
                OutputMessages.ExerciseCreated,
                name,
                sets,
                minimumRepetitions,
                maximumRepetitions
                );
        }

        public string SetMaxLiftedWeightToExercise(string name, double liftedWeight)
        {
            var exercise = this.exerciseHistory.GetByName(name);

            if (exercise == null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionMessages.ExerciseNotFound,
                        name));
            }

            exercise.SetMaxLiftedWeight(liftedWeight);

            return string.Format(
                OutputMessages.LiftedWeightSet,
                name,
                liftedWeight
                );
        }
    }
}
