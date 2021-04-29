using FitnessDiary.Core.Factories.Contracts;
using FitnessDiary.Models.TableUtilities.TableBuilders.Contracts;
using FitnessDiary.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FitnessDiary.Core.Factories
{
    public class TableBuilderFactory : ITableBuilderFactory
    {
        public ITableBuilder CreateTableBuilder(string type, IReadOnlyDictionary<WeekDays, List<IExercise>> exercises)
        {
            var tableType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(x => x.Name.StartsWith(type) && !x.IsAbstract)
                .FirstOrDefault();

            if (tableType == null)
            {
                throw new ArgumentException("Invalid Table Type!");
            }

            ITableBuilder tableBuilder = null;

            try
            {
                tableBuilder = (ITableBuilder)Activator.CreateInstance(tableType, (Dictionary<WeekDays, List<IExercise>>)exercises);
            }
            catch (TargetInvocationException ex)
            {
                throw new ArgumentException(ex.InnerException.Message);
            }
            
            return tableBuilder; 
        }
    }
}
