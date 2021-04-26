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

        static public string ExerciseOptions()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(OutputMessages.ExerciseOptions);
            sb.AppendLine(OutputMessages.ExerciseOptionsA);
            sb.AppendLine(OutputMessages.ExerciseOptionsB);
            sb.AppendLine(OutputMessages.ExerciseOptionsC);
            sb.AppendLine(OutputMessages.ExerciseOptionsD);
            return sb.ToString();
        }

        static public string FitnessProgramOptions()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(OutputMessages.FitnessProgramOptions);
            sb.AppendLine(OutputMessages.FitnessProgramOptionsA);
            sb.AppendLine(OutputMessages.FitnessProgramOptionsB);
            sb.AppendLine(OutputMessages.FitnessProgramOptionsC);
            sb.AppendLine(OutputMessages.FitnessProgramOptionsD);
            sb.AppendLine(OutputMessages.FitnessProgramOptionsE);

            return sb.ToString();
        }
    }
} 