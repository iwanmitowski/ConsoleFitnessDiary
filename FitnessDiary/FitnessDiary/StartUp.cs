using FitnessDiary.Core;
using FitnessDiary.Core.Factories;
using FitnessDiary.Core.Factories.Contracts;
using FitnessDiary.Core.Factory;
using FitnessDiary.IO;
using FitnessDiary.Models;
using FitnessDiary.Utilities.Enums;
using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace FitnessDiary
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var exerciseFactory = new ExerciseFactory();
            var exerciseHistory = new ExerciseHistory();
            var fitnessProgramFactory = new FitnessProgramFactory();
            var tableBuilderFactory = new TableBuilderFactory();

            var controller = new Controller(exerciseFactory,
                exerciseHistory,
                fitnessProgramFactory,
                tableBuilderFactory);


            var consoleReader = new ConsoleReader();
            var consoleWriter = new ConsoleWriter();

            var engine = new Engine(
                controller,
                consoleReader,
                consoleWriter);

            engine.Run();

        }
    }
}
