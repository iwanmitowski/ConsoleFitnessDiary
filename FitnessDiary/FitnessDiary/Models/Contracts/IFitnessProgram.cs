using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDiary.Models.Contracts
{
    interface IFitnessProgram
    {
        IExercise[,] exercises { get; }
        void Add();

        void Remove();

        void Update();

        void ShowWeekly();

        void ShowDaily();

    }
}
