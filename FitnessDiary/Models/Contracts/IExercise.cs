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
        void UpdateSets(int sets);
        void UpdateReps(int minReps, int maxReps);
    }
}
