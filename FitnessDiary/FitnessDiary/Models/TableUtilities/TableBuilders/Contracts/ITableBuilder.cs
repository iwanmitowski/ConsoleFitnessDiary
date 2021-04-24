using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDiary.Models.TableUtilities.TableBuilders.Contracts
{
    public interface ITableBuilder
    {
        abstract string BuildTable();
    }
}
