using FitnessDiary.Core.Contracts;
using FitnessDiary.Core.Factories.Contracts;
using FitnessDiary.Core.Factory;
using FitnessDiary.Core.Factory.Contracts;
using FitnessDiary.Models.Contracts;
using FitnessDiary.Utilities.Enums;
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
        private readonly IFitnessProgramFactory fitnessProgramFactory;
        private IFitnessProgram fitnessProgram;
        public Controller(IExerciseFactory exerciseFactory,
            IExerciseHistory exerciseHistory,
            IFitnessProgramFactory fitnessProgramFactory)
        {
            this.exerciseFactory = exerciseFactory;
            this.exerciseHistory = exerciseHistory;
            this.fitnessProgramFactory = fitnessProgramFactory;
        }
        public string CreateFitnessProgram()
        {
            this.fitnessProgram = fitnessProgramFactory.CreateFitnessProgram();

            return OutputMessages.FitnessProgramCreated;
        }

        public string CreateExercise(string name, int sets, int minimumRepetitions, int maximumRepetitions)
        {
            if (this.exerciseHistory.GetAll().Any(x => x.Name == name))
            {
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionMessages.ExerciseExists,
                        name));
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

            CheckIfTheExerciseIsNotPresent(exercise, name);

            exercise.SetMaxLiftedWeight(liftedWeight);

            return string.Format(
                OutputMessages.LiftedWeightSet,
                name,
                liftedWeight
                );
        }

        public string UpdateExerciseSets(string name, int sets)
        {
            var exercise = this.exerciseHistory.GetByName(name);

            CheckIfTheExerciseIsNotPresent(exercise, name);

            exercise.UpdateSets(sets);

            return string.Format(
                OutputMessages.ExerciseSetsUpdated,
                name,
                sets);
        }

        public string UpdateExerciseReps(string name, int minReps, int maxReps)
        {
            var exercise = this.exerciseHistory.GetByName(name);

            CheckIfTheExerciseIsNotPresent(exercise, name);

            exercise.UpdateReps(minReps, maxReps);

            return string.Format(
                OutputMessages.ExerciseRepsUpdated,
                name,
                minReps,
                maxReps);

        }

        //Add EXCEPTION IF NOT REGISTERED! AND UNIT TESTS!

        public string AddExerciseToTheEndOfTheProgram(string weekDay, string exerciseName)
        {
            WeekDays currentDay = WeekDaysParser(weekDay);

            var exercise = this.exerciseHistory.GetByName(exerciseName);

            CheckIfTheExerciseIsNotPresent(exercise, exerciseName);

            this.fitnessProgram.Add(currentDay, exercise);

            return string.Format(
               OutputMessages.ExerciseAddedAtTheEnd,
               weekDay,
               exerciseName);
        }
        //Add EXCEPTION IF NOT REGISTERED! AND UNIT TESTS!

        public string InsertExerciseSomewhereInTheProgram(string weekDay, int position, string exerciseName)
        {
            WeekDays currentDay = WeekDaysParser(weekDay);

            var exercise = this.exerciseHistory.GetByName(exerciseName);

            CheckIfTheExerciseIsNotPresent(exercise, exerciseName);

            this.fitnessProgram.Insert(currentDay, position, exercise);

            return string.Format(
               OutputMessages.ExerciseInsertedAtGivenPosition,
               weekDay,
               exerciseName,
               position);
        }
        //Add EXCEPTION IF NOT REGISTERED! AND UNIT TESTS!

        public string ChangeExerciseSomewhereInTheProgramWithAnother(string weekDay, int position, string exerciseName)
        {
            WeekDays currentDay = WeekDaysParser(weekDay);

            var exercise = this.exerciseHistory.GetByName(exerciseName);

            CheckIfTheExerciseIsNotPresent(exercise, exerciseName);

            this.fitnessProgram.Change(currentDay, position, exercise);

            return string.Format(
                OutputMessages.ExerciseChangedAtGivenPosition,
                weekDay,
                position,
                exerciseName);
        }
        //Add EXCEPTION IF NOT REGISTERED! AND UNIT TESTS!

        public string RemoveExerciseFromPositionInTheProgram(string weekDay, int position)
        {
            WeekDays currentDay = WeekDaysParser(weekDay);
            this.fitnessProgram.Remove(currentDay, position);

            return string.Format(
                OutputMessages.ExerciseRemovedFromTheProgram,
                weekDay,
                position);
        }


        //Helpers
        private void CheckIfTheExerciseIsNotPresent(IExercise exercise, string name)
        {
            if (exercise == null)
            {
                throw new InvalidOperationException(
                    string.Format(
                    ExceptionMessages.ExerciseNotFound,
                    name));
            }
        }

        private WeekDays WeekDaysParser(string weekDay)
        {
            switch (weekDay.ToLower())
            {
                case "monday":
                case "tuesday":
                case "wednesday":
                case "thursday":
                case "friday":
                case "saturday":
                case "sunday":
                    return (WeekDays)Enum.Parse(typeof(WeekDays), MakeTheFirstLetterToUpper(weekDay.ToLower()));

                default:

                    throw new InvalidOperationException(string.Format(
                        ExceptionMessages.InvalidWeekDay,
                        weekDay));
            }
        }

        private string MakeTheFirstLetterToUpper(string word)
        {
            return word.First().ToString().ToUpper() + word.Substring(1);
        }
    }
}
