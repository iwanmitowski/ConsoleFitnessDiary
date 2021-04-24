using FitnessDiary.Core.Contracts;
using FitnessDiary.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDiary.Core
{
    public class Engine : IEngine
    {
        private readonly IController controller;

        private readonly IConsoleReader consoleInputReader;
        private readonly IConsoleWriter consoleInputWriter;

        public Engine(IController controller,
            IConsoleReader consoleInputReader,
            IConsoleWriter consoleInputWriter)
        {
            this.controller = controller;
            this.consoleInputReader = consoleInputReader;
            this.consoleInputWriter = consoleInputWriter;
        }
        public void Run()
        {
            try
            {
                this.controller.DisableMaximizingAndResizing();//important!

                string name = "Single Leg Deadlift";
                string name1 = "Bench ";
                string name2 = "bicarki";
                int sets = 20;
                int sets1 = 20;
                int min = 20;
                int min1 = 20;
                int max = 20;
                int max1 = 20;
                double maxLifted = 160.25;

                this.controller.CreateFitnessProgram();
                this.controller.CreateExercise(name, sets, min, max);
                this.controller.CreateExercise(name1, sets1, min1, max1);
                this.controller.CreateExercise(name2, sets1, min1, max1);

                this.controller.AddExerciseToTheEndOfTheProgram("monday", name);
                this.controller.AddExerciseToTheEndOfTheProgram("monday", name2);
                this.controller.AddExerciseToTheEndOfTheProgram("monday", name);
                this.controller.AddExerciseToTheEndOfTheProgram("monday", name);
                this.controller.AddExerciseToTheEndOfTheProgram("monday", name2);
                this.controller.AddExerciseToTheEndOfTheProgram("monday", name);
                this.controller.AddExerciseToTheEndOfTheProgram("monday", name);
                this.controller.AddExerciseToTheEndOfTheProgram("monday", name1);
                this.controller.AddExerciseToTheEndOfTheProgram("monday", name);
                this.controller.AddExerciseToTheEndOfTheProgram("monday", name);
                this.controller.AddExerciseToTheEndOfTheProgram("tuesday", name);
                this.controller.AddExerciseToTheEndOfTheProgram("wednesday", name);
                this.controller.AddExerciseToTheEndOfTheProgram("wednesday", name);
                this.controller.AddExerciseToTheEndOfTheProgram("thursday", name);
                this.controller.AddExerciseToTheEndOfTheProgram("friday", name);
                this.controller.AddExerciseToTheEndOfTheProgram("friday", name);
                this.controller.AddExerciseToTheEndOfTheProgram("friday", name);
                this.controller.AddExerciseToTheEndOfTheProgram("saturday", name2);
                this.controller.AddExerciseToTheEndOfTheProgram("sunday", name);
                this.controller.AddExerciseToTheEndOfTheProgram("sunday", name);
                this.controller.AddExerciseToTheEndOfTheProgram("sunday", name);
                this.controller.AddExerciseToTheEndOfTheProgram("sunday", name);

                this.consoleInputWriter.WriteLine(this.controller.ShowDailyProgram());
                this.consoleInputWriter.WriteLine(this.controller.SetMaxLiftedWeightToExercise(name,maxLifted));
                this.consoleInputWriter.WriteLine(this.controller.SetMaxLiftedWeightToExercise(name,10));

            }
            catch(ArgumentException ae)
            {
                this.consoleInputWriter.WriteLine(ae.Message);
            }
            catch (InvalidOperationException ioe)
            {
                this.consoleInputWriter.WriteLine(ioe.Message);
            }
        }
    }
}
