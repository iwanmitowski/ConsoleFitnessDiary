using FitnessDiary.Core.Contracts;
using FitnessDiary.IO.Contracts;
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
                this.controller.DisableMaximizingAndResizing();//important!
                this.controller.CreateFitnessProgram();//Registration form here?
                this.controller.ExerciseFiller();//To write the created exercise in the file
                this.controller.ProgramFiller();//To write the added exercises in the file.

                string name = "Single Leg Deadlift";
                string name1 = "Bench ";
                string name2 = "bicarki";
                string name3 = "triceps";
                int sets = 20;
                int sets1 = 20;
                int min = 20;
                int min1 = 20;
                int max = 20;
                int max1 = 20;
                double maxLifted = 160.25;

                //this.controller.CreateExercise(name, sets, min, max);
                this.controller.CreateExercise(name3, sets1, min1, max1);
                //this.controller.CreateExercise(name2, sets1, min1, max1);

                //this.controller.AddExerciseToTheEndOfTheProgram("monday", name);
                //this.controller.AddExerciseToTheEndOfTheProgram("monday", name2);
                //this.controller.AddExerciseToTheEndOfTheProgram("monday", name);
                //this.controller.AddExerciseToTheEndOfTheProgram("monday", name);
                //this.controller.AddExerciseToTheEndOfTheProgram("monday", name2);
                //this.controller.AddExerciseToTheEndOfTheProgram("monday", name);
                //this.controller.AddExerciseToTheEndOfTheProgram("monday", name);
                //this.controller.AddExerciseToTheEndOfTheProgram("monday", name1);
                //this.controller.AddExerciseToTheEndOfTheProgram("monday", name);
                //this.controller.AddExerciseToTheEndOfTheProgram("monday", name);
                //this.controller.AddExerciseToTheEndOfTheProgram("tuesday", name3);
                //this.controller.AddExerciseToTheEndOfTheProgram("wednesday", name);
                //this.controller.AddExerciseToTheEndOfTheProgram("wednesday", name);
                //this.controller.AddExerciseToTheEndOfTheProgram("thursday", name);
                //this.controller.AddExerciseToTheEndOfTheProgram("friday", name);
                //this.controller.AddExerciseToTheEndOfTheProgram("friday", name);
                //this.controller.AddExerciseToTheEndOfTheProgram("friday", name);
                //this.controller.AddExerciseToTheEndOfTheProgram("saturday", name2);
                //this.controller.AddExerciseToTheEndOfTheProgram("sunday", name);
                //this.controller.AddExerciseToTheEndOfTheProgram("sunday", name);
                //this.controller.AddExerciseToTheEndOfTheProgram("sunday", name);
                //this.controller.AddExerciseToTheEndOfTheProgram("sunday", name);


                //this.consoleInputWriter.WriteLine(this.controller.ShowDailyProgram());
                this.consoleInputWriter.WriteLine(this.controller.ShowWeeklyProgram());
               
                this.consoleInputWriter.WriteLine(this.controller.SetMaxLiftedWeightToExercise(name,10));
                //IO playground

                this.controller.SetCollectionToFitnesProgramIO();
                this.controller.WriteTheFitnessProgramInFile();

                this.controller.SetCollectionToExerciseIO();
                this.controller.WriteAllExercisesFromTheExerciseHistoryInFile();
               


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
