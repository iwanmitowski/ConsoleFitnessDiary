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
                }

                while (true)
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        this.consoleInputWriter.WriteLine(UIMessagesInvoker.MainMenu());

                        string input = this.consoleInputReader.ReadLine();
                        if (input == "3")
                        {
                            break;
                        }

                        var message = this.ExecuteCommand(input);

                        this.controller.NormalTextColor();

                        if (message == "BACK")
                        {
                            continue;
                        }

                        this.consoleInputWriter.WriteLine(message);
                        this.consoleInputWriter.WriteLine(string.Empty);
                    }
                    catch (ArgumentException ae)
                    {
                        this.controller.ExceptionTextColor();

                        this.consoleInputWriter.WriteLine(ae.Message);
                    }
                    catch (InvalidOperationException ioe)
                    {
                        this.controller.ExceptionTextColor();

                        this.consoleInputWriter.WriteLine(ioe.Message);
                    }
                    catch (Exception missedex)
                    {
                        this.controller.ExceptionTextColor();

                        this.consoleInputWriter.WriteLine(missedex.Message);
                    }
                    finally
                    {
                        this.controller.NormalTextColor();
                    }
                }

                this.consoleInputWriter.WriteLine(UIMessagesInvoker.SeeYouTomorrow(name));

                this.controller.WriteTheFitnessProgramInFile();
                this.controller.WriteAllExercisesFromTheExerciseHistoryInFile();
            }
            catch (ArgumentException ae)
            {
                this.controller.ExceptionTextColor();

                this.consoleInputWriter.WriteLine(ae.Message);
            }
            catch (InvalidOperationException ioe)
            {
                this.controller.ExceptionTextColor();

                this.consoleInputWriter.WriteLine(ioe.Message);
            }
            catch (Exception missedex)
            {
                this.controller.ExceptionTextColor();

                this.consoleInputWriter.WriteLine(missedex.Message);
            }
            finally
            {
                this.controller.NormalTextColor();
            }
        }

        private string ExecuteCommand(string input)
        {
            string message = string.Empty;

            if (input == "1")
            {
                this.consoleInputWriter.WriteLine(UIMessagesInvoker.ExerciseOptions());

                input = this.consoleInputReader.ReadLine().ToUpper();

                if (input == "A")
                {
                    this.consoleInputWriter.WriteLine(UIMessagesInvoker.CreateExerciseInstructions());

                    string[] arguments = this.consoleInputReader.
                          ReadLine().
                          Split(",", StringSplitOptions.RemoveEmptyEntries).
                          Select(x => x.Trim()).
                          ToArray();

                    this.controller.CheckTheNeededLength(arguments.Length, 4);

                    string name = arguments[0];
                    string sets = arguments[1];
                    string minReps = arguments[2];
                    string maxReps = arguments[3];

                    message = this.controller.CreateExercise(name, sets, minReps, maxReps);
                }
                else if (input == "B")
                {
                    this.consoleInputWriter.WriteLine(UIMessagesInvoker.SetMaxLiftedWeightInstructions());

                    string[] arguments = this.consoleInputReader.
                          ReadLine().
                          Split(",", StringSplitOptions.RemoveEmptyEntries).
                          Select(x => x.Trim()).
                          ToArray();

                    this.controller.CheckTheNeededLength(arguments.Length, 2);

                    string name = arguments[0];
                    string liftedWeight = arguments[1];

                    message = this.controller.SetMaxLiftedWeightToExercise(name, liftedWeight);
                }
                else if (input == "C")
                {
                    this.consoleInputWriter.WriteLine(UIMessagesInvoker.UpdateExerciseSetsInstructions());

                    string[] arguments = this.consoleInputReader.
                          ReadLine().
                          Split(",", StringSplitOptions.RemoveEmptyEntries).
                          Select(x => x.Trim()).
                          ToArray();

                    this.controller.CheckTheNeededLength(arguments.Length, 2);

                    string name = arguments[0];
                    string sets = arguments[1];

                    message = this.controller.UpdateExerciseSets(name, sets);
                }
                else if (input == "D")
                {
                    this.consoleInputWriter.WriteLine(UIMessagesInvoker.UpdateExerciseRepsInstructions());

                    string[] arguments = this.consoleInputReader.
                           ReadLine().
                           Split(",", StringSplitOptions.RemoveEmptyEntries).
                           Select(x => x.Trim()).
                           ToArray();

                    this.controller.CheckTheNeededLength(arguments.Length, 3);

                    string name = arguments[0];
                    string minReps = arguments[1];
                    string maxReps = arguments[2];

                    message = this.controller.UpdateExerciseReps(name, minReps, maxReps);
                }
                else if (input == "BACK")
                {
                    message = "BACK";
                }
                else
                {
                    message = UIMessagesInvoker.InvalidInput();
                }
            }
            else if (input == "2")
            {
                this.consoleInputWriter.WriteLine(UIMessagesInvoker.FitnessProgramOptions());

                input = this.consoleInputReader.ReadLine().ToUpper();

                if (input == "A")
                {
                    Console.Clear();
                    message = this.controller.ShowWeeklyProgram();
                }
                else if (input == "B")
                {
                    this.consoleInputWriter.WriteLine(UIMessagesInvoker.AddExerciseAtTheEndOfTheProgramInstructions());

                    string[] arguments = this.consoleInputReader.
                          ReadLine().
                          Split(",", StringSplitOptions.RemoveEmptyEntries).
                          Select(x => x.Trim()).
                          ToArray();

                    this.controller.CheckTheNeededLength(arguments.Length, 3);

                    string weekDay = arguments[0];
                    string exerciseName = arguments[1];

                    message = this.controller.AddExerciseAtTheEndOfTheProgram(weekDay, exerciseName);
                }
                else if (input == "C")
                {
                    this.consoleInputWriter.WriteLine(UIMessagesInvoker.InsertAndChangeExerciseInstructions());

                    string[] arguments = this.consoleInputReader.
                          ReadLine().
                          Split(",", StringSplitOptions.RemoveEmptyEntries).
                          Select(x => x.Trim()).
                          ToArray();

                    this.controller.CheckTheNeededLength(arguments.Length, 3);

                    string weekDay = arguments[0];
                    string position = arguments[1];
                    string exerciseName = arguments[2];

                    message = this.controller.InsertExerciseSomewhereInTheProgram(weekDay, position, exerciseName);
                }
                else if (input == "D")
                {
                    this.consoleInputWriter.WriteLine(UIMessagesInvoker.InsertAndChangeExerciseInstructions());

                    string[] arguments = this.consoleInputReader.
                          ReadLine().
                          Split(",", StringSplitOptions.RemoveEmptyEntries).
                          Select(x => x.Trim()).
                          ToArray();

                    this.controller.CheckTheNeededLength(arguments.Length, 3);

                    string weekDay = arguments[0];
                    string position = arguments[1];
                    string exerciseName = arguments[2];

                    message = this.controller.ChangeExerciseSomewhereInTheProgramWithAnother(weekDay, position, exerciseName);
                }
                else if (input == "E")
                {
                    this.consoleInputWriter.WriteLine(UIMessagesInvoker.RemoveExerciseInstructions());

                    string[] arguments = this.consoleInputReader.
                          ReadLine().
                          Split(",", StringSplitOptions.RemoveEmptyEntries).
                          Select(x => x.Trim()).
                          ToArray();

                    this.controller.CheckTheNeededLength(arguments.Length, 2);

                    string weekDay = arguments[0];
                    string position = arguments[1];

                    message = this.controller.RemoveExerciseFromPositionInTheProgram(weekDay, position);
                }
                else if (input == "BACK")
                {
                    message = "BACK";
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

            this.controller.WriteTheFitnessProgramInFile();
            this.controller.WriteAllExercisesFromTheExerciseHistoryInFile();

            return message;
        }
    }
}
