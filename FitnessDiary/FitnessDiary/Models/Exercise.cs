using FitnessDiary.Utilities.Messages;
using System;
using System.Text;

namespace FitnessDiary.Models
{
    public class Exercise : IExercise
    {
        private string name;
        private double maxLiftedWeight;
        private int sets;
        private int minimumRepetitions;
        private int maximumRepetitions;

        public Exercise(string name, int sets, int minimumRepetitions, int maximumRepetitions)
        {
            Name = name;
            MaxLiftedWeight = 0;
            Sets = sets;
            MinimumRepetitions = minimumRepetitions;
            MaximumRepetitions = maximumRepetitions;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidName);
                }
                this.name = value;
            }
        }

        ///No upper restriction, because records could be broken, or strongman can use this app.
        public double MaxLiftedWeight
        {
            get
            {
                return this.maxLiftedWeight;
            }
            private set
            {
                if (value < this.MaxLiftedWeight)
                {
                    if (value <= 0)
                    {
                        throw new InvalidOperationException(ExceptionMessages.InvalidMaxLiftedWeightZeroOrLess);
                    }

                    throw new InvalidOperationException(ExceptionMessages.InvalidMaxLiftedWeightLessThanCurrent);
                }

                this.maxLiftedWeight = value;
            }
        }

        public int Sets
        {
            get
            {
                return this.sets;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidSeries);
                }
                this.sets = value;
            }
        }

        public int MinimumRepetitions
        {
            get
            {
                return this.minimumRepetitions;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRepetitions);
                }
                this.minimumRepetitions = value;
            }
        }

        public int MaximumRepetitions
        {
            get
            {
                return this.maximumRepetitions;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRepetitions);
                }
                this.maximumRepetitions = value;
            }
        }

        public void SetMaxLiftedWeight(double liftedWeight)
        {
            this.MaxLiftedWeight = liftedWeight;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"E: {this.Name}");
            sb.AppendLine($"{this.Sets} x {this.MinimumRepetitions}-{this.MaximumRepetitions} Reps");
            return sb.ToString().Trim();
        }
    }
}
