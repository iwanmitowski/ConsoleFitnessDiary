using System.Collections.Generic;
using System.Text;

namespace FitnessDiary.IO.FileIO
{
    public class ExerciseIO : FileIO
    {
        private IReadOnlyCollection<IExercise> exercises;
        public ExerciseIO(string path) : base(path)
        {
        }

        override public string GetText()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IExercise ex in this.exercises)
            {
                sb.AppendLine($"{ex.Name},{ex.Sets},{ex.MinimumRepetitions},{ex.MaximumRepetitions},{ex.MaxLiftedWeight}");
            }

            return sb.ToString();
        }

        override public void SetCollection<T>(T collection)
        {
            this.exercises = (IReadOnlyCollection<IExercise>)collection;
        }
    }
}
