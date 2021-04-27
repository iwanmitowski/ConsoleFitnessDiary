using FitnessDiary.Core.Contracts;
using FitnessDiary.IO.Contracts;
using FitnessDiary.Models;
using FitnessDiary.Utilities.Messages;
using System;
using System.Linq;

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
            this.controller.ChangeAppearence();
            this.controller.DisableMaximizingAndResizing();

            this.controller.CreateFitnessProgram();
            this.controller.ExerciseFiller();
            this.controller.ProgramFiller();
            this.controller.SetCollectionToExerciseIO();
            this.controller.SetCollectionToFitnesProgramIO();

            string name = string.Empty;

            try
            {
                if (!this.controller.CheckIfTheUserIsRegistered())
                {
                    this.consoleInputWriter.WriteLine(UIMessagesInvoker.PleaseRegister());
                    name = consoleInputReader.ReadLine();
                    this.consoleInputWriter.WriteLine(this.controller.Register(name));
                    this.consoleInputWriter.WriteLine(UIMessagesInvoker.CreateYourFirstExercise());

                }
                else
                {
                    this.controller.SetUserName();
                    name = this.controller.GetName();
                    this.consoleInputWriter.WriteLine(UIMessagesInvoker.WelcomeMessage(name));
                    this.consoleInputWriter.WriteLine(this.controller.ShowDailyProgram());
                    //this.consoleInputWriter.WriteLine(this.controller.ShowWeeklyProgram());
                }



                string input = this.consoleInputReader.ReadLine();

                while (input != "3")
                {
                    this.consoleInputWriter.WriteLine(UIMessagesInvoker.OptionExercise());
                    this.consoleInputWriter.WriteLine(UIMessagesInvoker.OptionFitnessProgram());
                    var message = this.ExecuteCommand(input);

                    input = this.consoleInputReader.ReadLine();
                    //Console.Clear(); ???
                }

                this.consoleInputWriter.WriteLine(UIMessagesInvoker.SeeYouTomorrow(name));

                //string name = "Single Leg Deadlift";
                //string name1 = "Bench ";
                //string name2 = "bicarki";
                //string name3 = "triceps";
                //string name4 = "alo sashko";
                //int sets = 20;
                //int sets1 = 20;
                //int min = 20;
                //int min1 = 20;
                //int max = 20;
                //int max1 = 20;
                //double maxLifted = 160.25;

                ////this.controller.AddExerciseToTheEndOfTheProgram("saturday", name4);


                //this.controller.WriteTheFitnessProgramInFile();// накрая на итерацията трябва да слагам това !!!!!!!!!!!!!!!!!
                //this.controller.WriteAllExercisesFromTheExerciseHistoryInFile();// накрая на итерацията трябва да слагам това !!!!!!!!!!!!!!!!!


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

        //to show the messages
        private string ExecuteCommand(string input)
        {

            string message = string.Empty;

            if (input == "1")
            {
                this.consoleInputWriter.WriteLine(UIMessagesInvoker.ExerciseOptions());

                input = this.consoleInputReader.ReadLine();

                if (input == "A")
                {
                    string[] arguments = this.consoleInputReader.
                        ReadLine().
                        Split(" ", StringSplitOptions.RemoveEmptyEntries).
                        ToArray();

                    int number = 0;

                    string name = arguments[0];
                    int sets = int.TryParse(arguments[1], out number) ? number : -1;
                    int minReps = int.TryParse(arguments[2], out number) ? number : -1;
                    int maxReps = int.TryParse(arguments[3], out number) ? number : -1;

                    message = this.controller.CreateExercise(name, sets, minReps, maxReps);
                }
                else if (input == "B")
                {
                    string[] arguments = this.consoleInputReader.
                        ReadLine().
                        Split(" ", StringSplitOptions.RemoveEmptyEntries).
                        ToArray();

                    string name = arguments[0];
                    double liftedWeight = double.TryParse(arguments[1], out double number) ? number : -1;

                    message = this.controller.SetMaxLiftedWeightToExercise(name, liftedWeight);
                }
                else if (input == "C")
                {
                    string[] arguments = this.consoleInputReader.
                        ReadLine().
                        Split(" ", StringSplitOptions.RemoveEmptyEntries).
                        ToArray();

                    string name = arguments[0];
                    int sets = int.TryParse(arguments[1], out int number) ? number : -1;

                    message = this.controller.UpdateExerciseSets(name, sets);
                }
                else if (input == "D")
                {
                    string[] arguments = this.consoleInputReader.
                        ReadLine().
                        Split(" ", StringSplitOptions.RemoveEmptyEntries).
                        ToArray();

                    int number = 0;

                    string name = arguments[0];
                    int minReps = int.TryParse(arguments[1], out number) ? number : -1;
                    int maxReps = int.TryParse(arguments[2], out number) ? number : -1;

                    message = this.controller.UpdateExerciseReps(name, minReps, maxReps);
                }
                else
                {
                    message = UIMessagesInvoker.InvalidInput();
                }
            }
            else if (input == "2")
            {
                this.consoleInputWriter.WriteLine(UIMessagesInvoker.FitnessProgramOptions());

                input = this.consoleInputReader.ReadLine();

                if (input == "A")
                {
                    message = this.controller.ShowWeeklyProgram();
                }
                else if (input == "B")
                {
                    string[] arguments = this.consoleInputReader.
                          ReadLine().
                          Split(" ", StringSplitOptions.RemoveEmptyEntries).
                          ToArray();

                    string weekDay = arguments[0];
                    string exerciseName = arguments[1];

                    message = this.controller.AddExerciseToTheEndOfTheProgram(weekDay, exerciseName);
                }
                else if (input == "C")
                {
                    string[] arguments = this.consoleInputReader.
                          ReadLine().
                          Split(" ", StringSplitOptions.RemoveEmptyEntries).
                          ToArray();

                    string weekDay = arguments[0];
                    int position = int.TryParse(arguments[1], out int number) ? number : -1;
                    string exerciseName = arguments[2];

                    message = this.controller.InsertExerciseSomewhereInTheProgram(weekDay, position, exerciseName);
                }
                else if (input == "D")
                {
                    string[] arguments = this.consoleInputReader.
                          ReadLine().
                          Split(" ", StringSplitOptions.RemoveEmptyEntries).
                          ToArray();

                    string weekDay = arguments[0];
                    int position = int.TryParse(arguments[1], out int number) ? number : -1;
                    string exerciseName = arguments[2];

                    message = this.controller.ChangeExerciseSomewhereInTheProgramWithAnother(weekDay, position, exerciseName);
                }
                else if (input == "E")
                {
                    string[] arguments = this.consoleInputReader.
                          ReadLine().
                          Split(" ", StringSplitOptions.RemoveEmptyEntries).
                          ToArray();

                    string weekDay = arguments[0];
                    int position = int.TryParse(arguments[1], out int number) ? number : -1;

                    message = this.controller.RemoveExerciseFromPositionInTheProgram(weekDay, position);
                }
                else
                {
                    message = UIMessagesInvoker.InvalidInput();
                }
            }
            else
            {
                message = UIMessagesInvoker.InvalidInput();
            }

            return message;
        }
    }
}
