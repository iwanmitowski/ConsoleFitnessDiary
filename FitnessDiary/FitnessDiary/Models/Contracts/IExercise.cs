using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDiary
{
    public interface IExercise
    {
        public string Name { get; }
        public double MaxLiftedWeight { get; }
        public int Sets { get; }
        public int MinimumRepetitions { get; }
        public int MaximumRepetitions { get; }
        void SetMaxLiftedWeight(double liftedWeight);
    }
}
