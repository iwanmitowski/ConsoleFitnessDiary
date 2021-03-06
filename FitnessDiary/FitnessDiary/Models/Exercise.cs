using FitnessDiary.Utilities.Messages;
using System;
using System.Text;

namespace FitnessDiary.Models
{
    public class Exercise : IExercise
    {
        private const int MaxNameLength = 24;

        private string name;
        private double maxLiftedWeight;
        private int sets;
        private int minimumRepetitions;
        private int maximumRepetitions;
        
        public Exercise(string name, 
            int sets,
            int minimumRepetitions,
            int maximumRepetitions)
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
                if (string.IsNullOrWhiteSpace(value)||value.Length>MaxNameLength)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName,MaxNameLength));
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
                else if (value>=100)
                {
                    throw new ArgumentException(ExceptionMessages.TooBigNumber);
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
                else if (value >= 100)
                {
                    throw new ArgumentException(ExceptionMessages.TooBigNumber);
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
                else if (value >= 100)
                {
                    throw new ArgumentException(ExceptionMessages.TooBigNumber);
                }
                else if (value < this.MinimumRepetitions)
                {
                    throw new InvalidOperationException(ExceptionMessages.InvalidMaxRepsCantBeLessThanMinReps);
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
            return $"{this.Name}";
        }

        public void UpdateReps(int minReps,int maxReps)
        {
            this.MinimumRepetitions = minReps;
            this.MaximumRepetitions = maxReps;
        }

        public void UpdateSets(int sets)
        {
            this.Sets = sets;
        }
    }
}
