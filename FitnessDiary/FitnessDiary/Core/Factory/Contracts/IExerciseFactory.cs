using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDiary.Core.Factory.Contracts
{
    public interface IExerciseFactory
    {
        IExercise CreateExercise(string name, int sets, int minimumRepetitions, int maximumRepetitions);
    }
}
