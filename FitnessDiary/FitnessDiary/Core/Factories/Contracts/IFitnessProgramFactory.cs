using FitnessDiary.Models.Contracts;

namespace FitnessDiary.Core.Factories.Contracts
{
    public interface IFitnessProgramFactory
    {
        IFitnessProgram CreateFitnessProgram();
    }
}
