using FitnessDiary.Models;
using FitnessDiary.Models.Contracts;

namespace FitnessDiary.Core.Factories.Contracts
{
    public class FitnessProgramFactory : IFitnessProgramFactory
    {
        public IFitnessProgram CreateFitnessProgram()
        {
            var fitnessProgram = new FitnessProgram();
            return fitnessProgram;
        }
    }
}
