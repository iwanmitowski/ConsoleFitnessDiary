using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDiary.Utilities.Messages
{
    public static class UIMessagesInvoker
    {
        static public string PleaseRegister()
        {
            return OutputMessages.PleaseRegister;
        }

        static public string WelcomeMessage(string name)
        {
            return string.Format(
                OutputMessages.Welcome,
                name);
        }
        static public string SeeYouTomorrow(string name)
        {
            return string.Format(
                OutputMessages.SeeYouTomorrow,
                name);
        }
        static public string InvalidInput()
        {
            return OutputMessages.InvalidInput;
        }

        static public string OptionExercise()
        {
            return OutputMessages.ExerciseOptions;
        }
        static public string OptionFitnessProgram()
        {
            return OutputMessages.FitnessProgramOptions;
        }

        static public string OptionExit()
        {
            return OutputMessages.OptionExit;
        }
        static public string OptionBack()
        {
            return OutputMessages.OptionBack;
        }

        static public string MainMenu()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine(OutputMessages.ExerciseOptions);
            sb.AppendLine(OutputMessages.FitnessProgramOptions);
            sb.AppendLine(OutputMessages.OptionExit);

            return sb.ToString();
        }
        static public string ExerciseOptions()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine(OutputMessages.ExerciseOptionsA);
            sb.AppendLine(OutputMessages.ExerciseOptionsB);
            sb.AppendLine(OutputMessages.ExerciseOptionsC);
            sb.AppendLine(OutputMessages.ExerciseOptionsD);
            sb.AppendLine(OutputMessages.ExerciseOptionsE);
            sb.AppendLine(OutputMessages.OptionBack);

            return sb.ToString();
        }

        static public string FitnessProgramOptions()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine(OutputMessages.FitnessProgramOptionsA);
            sb.AppendLine(OutputMessages.FitnessProgramOptionsB);
            sb.AppendLine(OutputMessages.FitnessProgramOptionsC);
            sb.AppendLine(OutputMessages.FitnessProgramOptionsD);
            sb.AppendLine(OutputMessages.FitnessProgramOptionsE);
            sb.AppendLine(OutputMessages.OptionBack);

            return sb.ToString();
        }

        static public string CreateYourFirstExercise()
        {
            return OutputMessages.CreateYourFirstExercise;

        }

        static public string CreateExerciseInstructions()
        {
            return OutputMessages.CreateExerciseInstructions;
        }
        static public string SetMaxLiftedWeightInstructions()
        {
            return OutputMessages.SetMaxLiftedWeightInstructions;
        }
        static public string UpdateExerciseSetsInstructions()
        {
            return OutputMessages.UpdateExerciseSetsInstructions;
        }
        static public string UpdateExerciseRepsInstructions()
        {
            return OutputMessages.UpdateExerciseRepsInstructions;
        }
        static public string AddExerciseAtTheEndOfTheProgramInstructions()
        {
            return OutputMessages.AddExerciseAtTheEndOfTheProgramInstructions;
        }
        static public string InsertAndChangeExerciseInstructions()
        {
            return OutputMessages.InsertAndChangeExerciseInstructions;
        }
        static public string RemoveExerciseInstructions()
        {
            return OutputMessages.RemoveExerciseInstructions;
        }
    }
}