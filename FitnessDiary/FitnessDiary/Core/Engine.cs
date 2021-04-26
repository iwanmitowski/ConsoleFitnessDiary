using FitnessDiary.Core.Contracts;
using FitnessDiary.IO.Contracts;
using FitnessDiary.Models;
using FitnessDiary.Utilities.Messages;
using System;

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
                this.controller.ChangeAppearence();
                this.controller.DisableMaximizingAndResizing();//important!

                this.controller.CreateFitnessProgram();
                this.controller.ExerciseFiller();
                this.controller.ProgramFiller();
                this.controller.SetCollectionToExerciseIO();
                this.controller.SetCollectionToFitnesProgramIO();

                this.consoleInputWriter.WriteLine(UIMessagesInvoker.WelcomeMessage("Ivan"));
                this.consoleInputWriter.WriteLine(UIMessagesInvoker.ExerciseOptions());
                this.consoleInputWriter.WriteLine(UIMessagesInvoker.FitnessProgramOptions());
                this.consoleInputWriter.WriteLine(UIMessagesInvoker.PleaseRegister());

                string name = "Single Leg Deadlift";
                string name1 = "Bench ";
                string name2 = "bicarki";
                string name3 = "triceps";
                string name4 = "alo sashko";
                int sets = 20;
                int sets1 = 20;
                int min = 20;
                int min1 = 20;
                int max = 20;
                int max1 = 20;
                double maxLifted = 160.25;

                //this.controller.CreateExercise(name, sets, min, max);
                //this.controller.CreateExercise(name4, sets1, min1, max1);
                
                this.controller.SetMaxLiftedWeightToExercise(name4, 150);
                this.controller.SetMaxLiftedWeightToExercise(name4, 360);
                this.controller.UpdateExerciseSets(name4, 60);

                //this.controller.AddExerciseToTheEndOfTheProgram("saturday", name4);

                //this.consoleInputWriter.WriteLine(this.controller.ShowWeeklyProgram());
                this.consoleInputWriter.WriteLine(this.controller.ShowDailyProgram());


                this.controller.WriteTheFitnessProgramInFile();// накрая на итерацията трябва да слагам това !!!!!!!!!!!!!!!!!
                this.controller.WriteAllExercisesFromTheExerciseHistoryInFile();// накрая на итерацията трябва да слагам това !!!!!!!!!!!!!!!!!

                
            }
            catch (ArgumentException ae)
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
