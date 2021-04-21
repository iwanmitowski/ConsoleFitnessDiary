using FitnessDiary.Models;
using FitnessDiary.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
