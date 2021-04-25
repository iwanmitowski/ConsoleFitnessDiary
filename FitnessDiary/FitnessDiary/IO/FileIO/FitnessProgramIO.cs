using FitnessDiary.IO.FileIO.Contracts;
using FitnessDiary.Utilities.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitnessDiary.IO.FileIO
{
    public class FitnessProgramIO:FileIO,ICollectionSetter
    {
        private IReadOnlyDictionary<WeekDays, List<IExercise>> exercises;
        public FitnessProgramIO(string path) : base(path)
        {
        }

        override public string GetText()
        {
            StringBuilder sb = new StringBuilder();

            foreach ((WeekDays weekDay, List<IExercise> ex) in this.exercises)
            {
                sb.AppendLine($"{weekDay}," + string.Join(",", ex.Select(x => x.Name)));
            }

            return sb.ToString();
        }

        override public void SetCollection<T>(T collection)
        {
            this.exercises = (IReadOnlyDictionary<WeekDays, List<IExercise>>)collection;
        }


       
    }
}
