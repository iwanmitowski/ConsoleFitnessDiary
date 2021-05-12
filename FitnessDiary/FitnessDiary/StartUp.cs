using FitnessDiary.Core;
using FitnessDiary.Core.Factories;
using FitnessDiary.Core.Factories.Contracts;
using FitnessDiary.Core.Factory;
using FitnessDiary.IO;
using FitnessDiary.IO.FileIO;
using FitnessDiary.Models;
using System.IO;

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

            var fitnessProgramIO = new FitnessProgramIO(Path.Combine("..", "..", "..", "DataBase", "FitnessProgram.txt"));
            var exerciseIO = new ExerciseIO(Path.Combine("..", "..", "..", "DataBase", "CreatedExercises.txt"));
            var userFileIO = new UserFileIO(Path.Combine("..", "..", "..", "DataBase", "User.txt"));

            var controller = new Controller(exerciseFactory,
                exerciseHistory,
                fitnessProgramFactory,
                tableBuilderFactory,
                fitnessProgramIO,
                exerciseIO,
                userFileIO);


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
